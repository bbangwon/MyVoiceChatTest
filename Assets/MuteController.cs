using UnityEngine;
using UnityEngine.UI;

public class MuteController : MonoBehaviour
{
    [SerializeField]
    Text muteDetectedText;

    public void OnMuteSwitchChanged(bool mute)
    {
        AudioListener.pause = mute;

        muteDetectedText.text = $"Mute Detected : {mute}";    
    }
}
