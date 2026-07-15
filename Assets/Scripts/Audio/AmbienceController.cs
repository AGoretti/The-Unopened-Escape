using UnityEngine;

namespace UnopenedEscape.Audio
{
    /// <summary>
    /// Orquestra os emissores de ambiente da cena. Se a cena ja tiver AmbienceEmitters
    /// posicionados manualmente (ver Tools/Audio/Setup SampleScene Ambience no editor),
    /// nao faz nada. Caso contrario, cria um conjunto padrao em runtime como rede de
    /// seguranca, para que o jogo nunca rode em silencio total por falta de setup manual.
    /// </summary>
    public class AmbienceController : MonoBehaviour
    {
        public struct DefaultEmitter
        {
            public string Name;
            public SfxId Sound;
            public Vector3 Position;
            public bool Intermittent;

            public DefaultEmitter(string name, SfxId sound, Vector3 position, bool intermittent = false)
            {
                Name = name;
                Sound = sound;
                Position = position;
                Intermittent = intermittent;
            }
        }

        // Posicoes de referencia para a SampleScene: sala pequena em torno da origem,
        // ButtonVR/Interactables perto de (0.9, 1, -0.5). Ajustar via
        // Tools/Audio/Setup SampleScene Ambience apos a arte final do cenario.
        public static readonly DefaultEmitter[] SampleSceneDefaults =
        {
            new DefaultEmitter("Ambience_RadioChiado", SfxId.RadioChiado, new Vector3(-1.5f, 1.0f, 1.5f)),
            new DefaultEmitter("Ambience_Goteiras", SfxId.Goteiras, new Vector3(1.5f, 0.2f, -1.5f)),
            new DefaultEmitter("Ambience_FaiscasEletricas", SfxId.FaiscasEletricas, new Vector3(0f, 2.5f, 0f), intermittent: true),
            new DefaultEmitter("Ambience_PassosNoTeto", SfxId.PassosNoTeto, new Vector3(0f, 3.2f, 0f), intermittent: true),
            new DefaultEmitter("Ambience_SotaoVento", SfxId.SotaoVento, new Vector3(0f, 3.0f, -1.0f)),
            new DefaultEmitter("Ambience_RatosCorrendo", SfxId.RatosCorrendo, new Vector3(-1.0f, 0.1f, -1.0f), intermittent: true),
        };

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Bootstrap()
        {
            if (FindAnyObjectByType<AmbienceController>() != null)
            {
                return;
            }
            new GameObject("AmbienceController").AddComponent<AmbienceController>();
        }

        private void Awake()
        {
            if (FindAnyObjectByType<AmbienceEmitter>() != null)
            {
                return; // cena ja configurada manualmente (via Editor > Tools/Audio)
            }

            var root = new GameObject("-- AUDIO (auto) --");
            foreach (var def in SampleSceneDefaults)
            {
                var go = new GameObject(def.Name);
                go.transform.SetParent(root.transform);
                go.transform.position = def.Position;
                var emitter = go.AddComponent<AmbienceEmitter>();
                emitter.sound = def.Sound;
                emitter.intermittent = def.Intermittent;
            }
        }
    }
}
