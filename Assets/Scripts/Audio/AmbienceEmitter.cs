using System.Collections;
using UnityEngine;

namespace UnopenedEscape.Audio
{
    /// <summary>
    /// Emissor de som ambiente posicionado no cenario (goteiras, radio, vento, ratos, passos).
    /// Loop continuo por padrao; pode ser configurado como intermitente (toca, espera um
    /// intervalo aleatorio, repete) para sons que nao devem ser um drone constante, como
    /// ratos correndo ou passos no teto.
    /// </summary>
    public class AmbienceEmitter : MonoBehaviour
    {
        public SfxId sound;
        public bool playOnStart = true;
        public bool intermittent;
        public Vector2 intervalRangeSeconds = new Vector2(8f, 25f);

        private AudioSource _source;
        private Coroutine _routine;

        private void Start()
        {
            var def = SoundLibrary.GetDef(sound);
            var clip = SoundLibrary.GetClip(sound);

            _source = gameObject.AddComponent<AudioSource>();
            _source.clip = clip;
            _source.playOnAwake = false;
            _source.spatialBlend = 1f;
            _source.minDistance = def.MinDistance;
            _source.maxDistance = def.MaxDistance;
            _source.rolloffMode = AudioRolloffMode.Logarithmic;
            _source.volume = def.Volume * (AudioManager.Instance != null ? AudioManager.Instance.GetChannelVolume(AudioChannel.Ambience) : 1f);
            _source.loop = !intermittent && def.Loop;

            if (!playOnStart || clip == null)
            {
                return;
            }

            if (intermittent)
            {
                _routine = StartCoroutine(IntermittentLoop());
            }
            else
            {
                _source.Play();
            }
        }

        private IEnumerator IntermittentLoop()
        {
            while (true)
            {
                _source.Play();
                float wait = Random.Range(intervalRangeSeconds.x, intervalRangeSeconds.y);
                yield return new WaitForSeconds(wait + _source.clip.length);
            }
        }

        private void OnDestroy()
        {
            if (_routine != null)
            {
                StopCoroutine(_routine);
            }
        }
    }
}
