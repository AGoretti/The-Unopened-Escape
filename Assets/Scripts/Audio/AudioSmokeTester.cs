using System.Collections;
using UnityEngine;

namespace UnopenedEscape.Audio
{
    /// <summary>
    /// Ferramenta de desenvolvimento para audicionar os sons em Play Mode sem precisar de VR.
    /// Adicione este componente a um GameObject na cena, entre em Play e use os itens do
    /// menu de contexto (botao direito no componente, no Inspector).
    /// </summary>
    public class AudioSmokeTester : MonoBehaviour
    {
        public SfxId testId;
        public float gapBetweenSounds = 1.5f;

        [ContextMenu("Play Test Id")]
        public void PlayTestId()
        {
            AudioManager.Instance.PlaySfxAt(testId, transform.position);
        }

        [ContextMenu("Play All Sounds Sequentially")]
        public void PlayAllSequentially()
        {
            StartCoroutine(PlayAllRoutine());
        }

        private IEnumerator PlayAllRoutine()
        {
            foreach (var id in SoundLibrary.AllIds())
            {
                Debug.Log($"[AudioSmokeTester] Tocando {id}");
                AudioManager.Instance.PlaySfxAt(id, transform.position);
                yield return new WaitForSeconds(gapBetweenSounds);
            }
            Debug.Log("[AudioSmokeTester] Fim da lista.");
        }
    }
}
