using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteSwitchText : MonoBehaviour {

	private Text textUI;
	private string initialText;

	public MuteSwitchDetector detector;

	void Start () {
		textUI = GetComponent<Text>();
		initialText = textUI.text;

		#if UNITY_IPHONE && !UNITY_EDITOR
		if (detector != null) {
			textUI.text = "";
			detector.onMuteSwitchChanged.AddListener(OnMuteSwitchChanged);
		}

		#else 
		textUI.gameObject.SetActive(false);
		#endif
	}

	void OnMuteSwitchChanged(bool newState) {
		DisplayMuteSwitchState(newState);
	}

	void DisplayMuteSwitchState(bool state) {
		textUI.text = initialText + state;
	}
}
