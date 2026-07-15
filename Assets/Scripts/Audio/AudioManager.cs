using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnopenedEscape.Audio
{
    /// <summary>
    /// Singleton central de audio. Toca musica, SFX 2D/3D e loops posicionados,
    /// e mantem volume por canal (Master/Music/Ambience/Sfx) persistido em PlayerPrefs.
    /// Nao depende de nenhum AudioMixer criado no editor.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private const int SfxPoolSize = 8;
        private const string PrefKeyPrefix = "UnopenedEscape.Audio.Volume.";

        private AudioSource _musicSource;
        private readonly List<AudioSource> _sfxPool = new List<AudioSource>();
        private readonly List<AudioSource> _activeLoops = new List<AudioSource>();
        private readonly Dictionary<AudioChannel, float> _channelVolume = new Dictionary<AudioChannel, float>();
        private Coroutine _musicFadeRoutine;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap()
        {
            if (Instance != null)
            {
                return;
            }
            var go = new GameObject("AudioManager");
            go.AddComponent<AudioManager>();
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (AudioChannel channel in System.Enum.GetValues(typeof(AudioChannel)))
            {
                _channelVolume[channel] = PlayerPrefs.GetFloat(PrefKeyPrefix + channel, 1f);
            }

            _musicSource = gameObject.AddComponent<AudioSource>();
            _musicSource.playOnAwake = false;
            _musicSource.spatialBlend = 0f;

            for (int i = 0; i < SfxPoolSize; i++)
            {
                var sfxGo = new GameObject($"SfxVoice_{i}");
                sfxGo.transform.SetParent(transform);
                var source = sfxGo.AddComponent<AudioSource>();
                source.playOnAwake = false;
                _sfxPool.Add(source);
            }

            ApplyMasterVolume();
        }

        // ----- Musica -----

        public void PlayMusic(SfxId id, bool? loopOverride = null)
        {
            var def = SoundLibrary.GetDef(id);
            var clip = SoundLibrary.GetClip(id);
            if (clip == null)
            {
                return;
            }

            if (_musicFadeRoutine != null)
            {
                StopCoroutine(_musicFadeRoutine);
                _musicFadeRoutine = null;
            }

            _musicSource.clip = clip;
            _musicSource.loop = loopOverride ?? def.Loop;
            _musicSource.volume = def.Volume * _channelVolume[AudioChannel.Music];
            _musicSource.Play();
        }

        public void StopMusic(float fadeSeconds = 1f)
        {
            if (_musicFadeRoutine != null)
            {
                StopCoroutine(_musicFadeRoutine);
            }
            _musicFadeRoutine = StartCoroutine(FadeOutMusic(fadeSeconds));
        }

        private IEnumerator FadeOutMusic(float fadeSeconds)
        {
            float startVolume = _musicSource.volume;
            float t = 0f;
            while (t < fadeSeconds && startVolume > 0f)
            {
                t += Time.deltaTime;
                _musicSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeSeconds);
                yield return null;
            }
            _musicSource.Stop();
            _musicFadeRoutine = null;
        }

        // ----- One-shots -----

        /// <summary>Toca um som 2D (sem posicao no espaco), tipicamente UI/feedback.</summary>
        public void PlaySfx(SfxId id, float volumeScale = 1f)
        {
            var def = SoundLibrary.GetDef(id);
            var clip = SoundLibrary.GetClip(id);
            if (clip == null)
            {
                return;
            }
            var source = GetPooledSource();
            source.transform.position = transform.position;
            source.spatialBlend = 0f;
            source.volume = def.Volume * volumeScale * _channelVolume[def.Channel];
            source.PlayOneShot(clip);
        }

        /// <summary>Toca um som 3D posicionado no mundo (interacoes, eventos ambientados).</summary>
        public void PlaySfxAt(SfxId id, Vector3 position, float volumeScale = 1f)
        {
            var def = SoundLibrary.GetDef(id);
            var clip = SoundLibrary.GetClip(id);
            if (clip == null)
            {
                return;
            }
            var source = GetPooledSource();
            source.transform.position = position;
            source.spatialBlend = 1f;
            source.minDistance = def.MinDistance;
            source.maxDistance = def.MaxDistance;
            source.rolloffMode = AudioRolloffMode.Logarithmic;
            source.volume = def.Volume * volumeScale * _channelVolume[def.Channel];
            source.PlayOneShot(clip);
        }

        private AudioSource GetPooledSource()
        {
            foreach (var source in _sfxPool)
            {
                if (!source.isPlaying)
                {
                    return source;
                }
            }
            // pool esgotado: reusa o mais antigo (indice 0) para nao crescer sem limite
            return _sfxPool[0];
        }

        // ----- Loops posicionados (engrenagens, sliders, teto de espinhos, ampulheta) -----

        /// <summary>
        /// Inicia um loop 3D contínuo em uma posicao (ou seguindo um Transform). Retorna o AudioSource
        /// como handle para StopLoop. Quem chama e responsavel por guardar a referencia retornada.
        /// </summary>
        public AudioSource PlayLoop(SfxId id, Transform followOrNull, Vector3 position)
        {
            var def = SoundLibrary.GetDef(id);
            var clip = SoundLibrary.GetClip(id);
            if (clip == null)
            {
                return null;
            }

            var go = new GameObject($"Loop_{id}");
            go.transform.SetParent(followOrNull != null ? followOrNull : transform);
            go.transform.position = position;

            var source = go.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = true;
            source.playOnAwake = false;
            source.spatialBlend = 1f;
            source.minDistance = def.MinDistance;
            source.maxDistance = def.MaxDistance;
            source.rolloffMode = AudioRolloffMode.Logarithmic;
            source.volume = def.Volume * _channelVolume[def.Channel];
            source.Play();

            _activeLoops.Add(source);
            return source;
        }

        public void StopLoop(AudioSource loopSource, float fadeSeconds = 0.3f)
        {
            if (loopSource == null)
            {
                return;
            }
            _activeLoops.Remove(loopSource);
            StartCoroutine(FadeOutAndDestroy(loopSource, fadeSeconds));
        }

        private IEnumerator FadeOutAndDestroy(AudioSource source, float fadeSeconds)
        {
            float startVolume = source.volume;
            float t = 0f;
            while (t < fadeSeconds)
            {
                if (source == null)
                {
                    yield break;
                }
                t += Time.deltaTime;
                source.volume = Mathf.Lerp(startVolume, 0f, t / fadeSeconds);
                yield return null;
            }
            if (source != null)
            {
                Destroy(source.gameObject);
            }
        }

        // ----- Volume por canal -----

        public void SetChannelVolume(AudioChannel channel, float volume01)
        {
            volume01 = Mathf.Clamp01(volume01);
            _channelVolume[channel] = volume01;
            PlayerPrefs.SetFloat(PrefKeyPrefix + channel, volume01);

            if (channel == AudioChannel.Music)
            {
                _musicSource.volume = volume01;
            }
        }

        public float GetChannelVolume(AudioChannel channel)
        {
            return _channelVolume.TryGetValue(channel, out var v) ? v : 1f;
        }

        public void SetMasterVolume(float volume01)
        {
            PlayerPrefs.SetFloat(PrefKeyPrefix + "Master", Mathf.Clamp01(volume01));
            ApplyMasterVolume();
        }

        private void ApplyMasterVolume()
        {
            AudioListener.volume = PlayerPrefs.GetFloat(PrefKeyPrefix + "Master", 1f);
        }

        /// <summary>Atalho generico usado pelos futuros scripts de puzzle: AudioManager.Instance.Play(SfxId.X)</summary>
        public void Play(SfxId id, float volumeScale = 1f)
        {
            PlaySfx(id, volumeScale);
        }
    }
}
