using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace UnopenedEscape.Audio
{
    /// <summary>
    /// Toca a sequencia de batidas metalicas do Puzzle "Sons Metalicos" (docs/sgdd/puzzles.md).
    /// Padrao no formato Morse: '.' = tap curto, '-' = tap longo, ' ' = pausa entre simbolos,
    /// '|' = pausa longa. Exemplo: PlayPattern(". - . | . .")
    /// </summary>
    public class MetallicTapSequencePlayer : MonoBehaviour
    {
        [Tooltip("Duracao de uma unidade de tempo (gap entre taps curtos).")]
        public float unitDuration = 0.25f;

        [Tooltip("Multiplicador de unitDuration para a pausa longa ('|').")]
        public float longGapUnits = 3f;

        public bool loopPattern;
        public UnityEvent onPatternComplete;

        public bool IsPlaying { get; private set; }

        private Coroutine _routine;

        public void PlayPattern(string pattern)
        {
            Stop();
            _routine = StartCoroutine(PlayRoutine(pattern));
        }

        public void Stop()
        {
            if (_routine != null)
            {
                StopCoroutine(_routine);
                _routine = null;
            }
            IsPlaying = false;
        }

        private IEnumerator PlayRoutine(string pattern)
        {
            IsPlaying = true;
            do
            {
                foreach (char symbol in pattern)
                {
                    switch (symbol)
                    {
                        case '.':
                            AudioManager.Instance.PlaySfxAt(SfxId.TapCurto, transform.position);
                            yield return new WaitForSeconds(unitDuration);
                            break;
                        case '-':
                            AudioManager.Instance.PlaySfxAt(SfxId.TapLongo, transform.position);
                            yield return new WaitForSeconds(unitDuration);
                            break;
                        case '|':
                            yield return new WaitForSeconds(unitDuration * longGapUnits);
                            break;
                        case ' ':
                            yield return new WaitForSeconds(unitDuration);
                            break;
                    }
                }
                onPatternComplete?.Invoke();
            } while (loopPattern);

            IsPlaying = false;
            _routine = null;
        }
    }
}
