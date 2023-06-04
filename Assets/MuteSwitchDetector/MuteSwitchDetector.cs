using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.Events;

public class MuteSwitchDetector : MonoBehaviour {

	[System.Serializable]
	public class MuteSwitchChangedEvent : UnityEvent<bool>
	{
	}
	
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	private static extern void StartListeningForMuteChanges();

	[DllImport ("__Internal")]
	private static extern void StopListeningForMuteChanges();

	[DllImport ("__Internal")]
	private static extern bool IsMuted();
	#endif

	public MuteSwitchChangedEvent onMuteSwitchChanged;

	public bool isMuted {
		get {
			#if UNITY_IPHONE && !UNITY_EDITOR
			return IsMuted();
			#endif
			return false;
		}
	}

	void Start () {

		if (onMuteSwitchChanged == null) {
			onMuteSwitchChanged = new MuteSwitchChangedEvent();
		}

		#if UNITY_IPHONE && !UNITY_EDITOR
		StartListeningForMuteChanges();
		#endif
	}
		
	void OnDestroy() {
		#if UNITY_IPHONE && !UNITY_EDITOR
		StopListeningForMuteChanges();
		#endif
	}

	void OnMuteStateChanged(string message) {
		bool newState = bool.Parse(message);
		onMuteSwitchChanged.Invoke(newState);
	}
}
