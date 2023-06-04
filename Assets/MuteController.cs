using UnityEngine;
using UnityEngine.UI;

public class MuteController : MonoBehaviour
{
    [SerializeField]
    Text muteDetectedText;

    [SerializeField]
    Toggle muteToggle;

    public void OnMuteSwitchChanged(bool mute)
    {
        muteToggle.isOn = mute;

        muteDetectedText.text = $"Mute Detected : {mute}";    
    }
}
