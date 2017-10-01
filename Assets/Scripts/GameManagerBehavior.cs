using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour {
	#region Const Vars
	const string GOLD_TEXT_PREFIX = "GOLD: ";
	const int STARTING_GOLD = 1000;
	#endregion

	#region Static Vars
	private static object _lock = new object ();
	private static bool applicationIsQuitting = false;

	private static GameManagerBehavior _instance;
	public static GameManagerBehavior Instance {
		get {
			if (applicationIsQuitting) {
				return null;
			}

			return _instance;
		}

		private set{
			lock (_lock) {
				if (Instance == null) {
					_instance = value;
				}
			}
		}
	}

	#endregion

	#region Public Vars
	public Text goldLabel;

	public int Gold {
		get { return gold; }
		set {
			gold = value;
			goldLabelText.text = GOLD_TEXT_PREFIX + gold;
		}
	}
	#endregion

	#region Private Vars

	private int gold;
	private Text goldLabelText;

	#endregion

	#region Mono Behaviours

	void Awake(){
		Instance = this;
	}

	void Start(){
		goldLabelText = goldLabel.GetComponent<Text> ();
		Gold = 1000;
	}

	void OnDestroy(){
		applicationIsQuitting = true;
	}

	#endregion
}
