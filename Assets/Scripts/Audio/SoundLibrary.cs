using System.Collections.Generic;
using UnityEngine;

namespace UnopenedEscape.Audio
{
    /// <summary>
    /// Mapeia cada SfxId para seu arquivo em Resources e parametros de reproducao.
    /// Contrato unico entre os assets em Assets/Audio/Resources/Audio/ e o codigo.
    /// </summary>
    public static class SoundLibrary
    {
        public struct SoundDef
        {
            public string ResourcePath; // relativo a uma pasta Resources, sem extensao
            public AudioChannel Channel;
            public bool Loop;
            public float Volume;
            public float MinDistance;
            public float MaxDistance;

            public SoundDef(string resourcePath, AudioChannel channel, bool loop, float volume, float minDistance = 0.5f, float maxDistance = 8f)
            {
                ResourcePath = resourcePath;
                Channel = channel;
                Loop = loop;
                Volume = volume;
                MinDistance = minDistance;
                MaxDistance = maxDistance;
            }
        }

        private static readonly Dictionary<SfxId, SoundDef> Defs = new Dictionary<SfxId, SoundDef>
        {
            { SfxId.MusicaHorrorPsicologico, new SoundDef("Audio/Music/music_horror_psicologico", AudioChannel.Music, true, 0.8f) },
            { SfxId.MusicaEncerramentoVitoria, new SoundDef("Audio/Music/music_encerramento_vitoria", AudioChannel.Music, false, 0.8f) },
            { SfxId.MusicaEncerramentoDerrota, new SoundDef("Audio/Music/music_encerramento_derrota", AudioChannel.Music, false, 0.8f) },

            { SfxId.RadioChiado, new SoundDef("Audio/Ambience/amb_radio_chiado_loop", AudioChannel.Ambience, true, 0.5f) },
            { SfxId.Goteiras, new SoundDef("Audio/Ambience/amb_goteiras_loop", AudioChannel.Ambience, true, 0.6f) },
            { SfxId.FaiscasEletricas, new SoundDef("Audio/Ambience/amb_faiscas_eletricas", AudioChannel.Ambience, false, 0.7f) },
            { SfxId.PassosNoTeto, new SoundDef("Audio/Ambience/amb_passos_teto", AudioChannel.Ambience, false, 0.6f, 1f, 10f) },
            { SfxId.SotaoVento, new SoundDef("Audio/Ambience/amb_sotao_vento_loop", AudioChannel.Ambience, true, 0.4f) },
            { SfxId.RatosCorrendo, new SoundDef("Audio/Ambience/amb_ratos_correndo", AudioChannel.Ambience, false, 0.6f) },
            { SfxId.AmpulhetaAreia, new SoundDef("Audio/Ambience/amb_ampulheta_areia_loop", AudioChannel.Ambience, true, 0.4f, 0.3f, 4f) },

            { SfxId.EngrenagensCubo, new SoundDef("Audio/Interaction/sfx_engrenagens_cubo_loop", AudioChannel.Sfx, true, 0.8f, 0.3f, 5f) },
            { SfxId.FeedbackRotacao, new SoundDef("Audio/Interaction/sfx_rotacao_click", AudioChannel.Sfx, false, 0.8f, 0.3f, 5f) },
            { SfxId.SnapMagnetico, new SoundDef("Audio/Interaction/sfx_snap_magnetico", AudioChannel.Sfx, false, 0.9f, 0.3f, 5f) },
            { SfxId.CliqueAutenticacao, new SoundDef("Audio/Interaction/sfx_clique_autenticacao", AudioChannel.Sfx, false, 0.9f, 0.3f, 5f) },
            { SfxId.SliderFriccao, new SoundDef("Audio/Interaction/sfx_slider_friccao_loop", AudioChannel.Sfx, true, 0.6f, 0.3f, 5f) },

            { SfxId.RadioDesligando, new SoundDef("Audio/Events/evt_radio_desligando", AudioChannel.Sfx, false, 0.8f) },
            { SfxId.AlarmeIntruso, new SoundDef("Audio/Events/evt_alarme_intruso", AudioChannel.Sfx, true, 0.9f, 1f, 12f) },
            { SfxId.ComportasFechando, new SoundDef("Audio/Events/evt_comportas_fechando", AudioChannel.Sfx, false, 0.9f, 1f, 12f) },
            { SfxId.CadeiraArrastada, new SoundDef("Audio/Events/evt_cadeira_arrastada", AudioChannel.Sfx, false, 0.8f, 0.3f, 6f) },
            { SfxId.Escotilha, new SoundDef("Audio/Events/evt_escotilha", AudioChannel.Sfx, false, 0.8f, 0.5f, 8f) },
            { SfxId.MesaBalancando, new SoundDef("Audio/Events/evt_mesa_balancando", AudioChannel.Sfx, false, 0.9f, 0.3f, 6f) },
            { SfxId.TetoEspinhos, new SoundDef("Audio/Events/evt_teto_espinhos_loop", AudioChannel.Sfx, true, 0.8f, 0.5f, 10f) },
            { SfxId.Blackout, new SoundDef("Audio/Events/evt_blackout", AudioChannel.Sfx, false, 1f) },

            { SfxId.AreiaAcelerada, new SoundDef("Audio/Feedback/sfx_areia_acelerada", AudioChannel.Sfx, true, 0.6f, 0.3f, 4f) },
            { SfxId.EngrenagensVitoria, new SoundDef("Audio/Feedback/fb_engrenagens_vitoria", AudioChannel.Sfx, false, 0.9f) },
            { SfxId.EstruturasDerrota, new SoundDef("Audio/Feedback/fb_estruturas_derrota", AudioChannel.Sfx, false, 1f) },

            { SfxId.EntidadeSussurros, new SoundDef("Audio/Terror/terror_entidade_sussurros", AudioChannel.Sfx, false, 0.7f, 1f, 15f) },

            { SfxId.TapCurto, new SoundDef("Audio/Puzzle/puzzle_tap_curto", AudioChannel.Sfx, false, 0.8f, 0.3f, 5f) },
            { SfxId.TapLongo, new SoundDef("Audio/Puzzle/puzzle_tap_longo", AudioChannel.Sfx, false, 0.8f, 0.3f, 5f) },
        };

        private static readonly Dictionary<SfxId, AudioClip> _clipCache = new Dictionary<SfxId, AudioClip>();

        public static SoundDef GetDef(SfxId id)
        {
            return Defs[id];
        }

        public static AudioClip GetClip(SfxId id)
        {
            if (_clipCache.TryGetValue(id, out var cached))
            {
                return cached;
            }

            var def = Defs[id];
            var clip = Resources.Load<AudioClip>(def.ResourcePath);
            if (clip == null)
            {
                Debug.LogWarning($"[SoundLibrary] Nao encontrei o clip para {id} em Resources/{def.ResourcePath}. Rode 'FREESOUND_API_KEY=... python3 tools/download_sounds.py'.");
            }
            _clipCache[id] = clip;
            return clip;
        }

        public static IEnumerable<SfxId> AllIds()
        {
            foreach (var key in Defs.Keys)
            {
                yield return key;
            }
        }
    }
}
