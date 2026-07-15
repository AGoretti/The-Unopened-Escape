using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnopenedEscape.Audio;

namespace UnopenedEscape.Audio.EditorTools
{
    /// <summary>
    /// Ferramentas de editor para configurar audio na cena sem editar YAML a mao.
    /// </summary>
    public static class AudioSceneSetupEditor
    {
        [MenuItem("Tools/Audio/Setup SampleScene Ambience")]
        public static void SetupSampleSceneAmbience()
        {
            var existingRoot = GameObject.Find("-- AUDIO --");
            if (existingRoot != null)
            {
                bool replace = EditorUtility.DisplayDialog(
                    "Audio ja configurado",
                    "Ja existe um objeto '-- AUDIO --' nesta cena. Substituir?",
                    "Substituir", "Cancelar");
                if (!replace)
                {
                    return;
                }
                Object.DestroyImmediate(existingRoot);
            }

            var root = new GameObject("-- AUDIO --");
            foreach (var def in AmbienceController.SampleSceneDefaults)
            {
                var go = new GameObject(def.Name);
                go.transform.SetParent(root.transform);
                go.transform.position = def.Position;
                var emitter = go.AddComponent<AmbienceEmitter>();
                emitter.sound = def.Sound;
                emitter.intermittent = def.Intermittent;
            }

            Undo.RegisterCreatedObjectUndo(root, "Setup Sample Scene Ambience");
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            Debug.Log($"[AudioSceneSetupEditor] Criados {AmbienceController.SampleSceneDefaults.Length} emissores de ambiente sob '-- AUDIO --'. Salve a cena (Ctrl/Cmd+S).");
        }

        [MenuItem("Tools/Audio/Validate Sound Library")]
        public static void ValidateSoundLibrary()
        {
            int ok = 0;
            int missing = 0;
            foreach (var id in SoundLibrary.AllIds())
            {
                var def = SoundLibrary.GetDef(id);
                var clip = Resources.Load<AudioClip>(def.ResourcePath);
                if (clip == null)
                {
                    Debug.LogWarning($"[AudioSceneSetupEditor] FALTANDO: {id} -> Resources/{def.ResourcePath}");
                    missing++;
                }
                else
                {
                    ok++;
                }
            }
            Debug.Log($"[AudioSceneSetupEditor] Validacao concluida: {ok} OK, {missing} faltando. " +
                      (missing > 0 ? "Rode 'FREESOUND_API_KEY=... python3 tools/download_sounds.py'." : "Tudo certo!"));
        }
    }
}
