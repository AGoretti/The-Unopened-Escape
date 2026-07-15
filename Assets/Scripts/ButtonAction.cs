using UnityEngine;
using UnopenedEscape.Audio;

public class ButtonAction : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Hello World!");
        AudioManager.Instance.PlaySfxAt(SfxId.CliqueAutenticacao, transform.position);
        // Add your button click logic here
    }
}
