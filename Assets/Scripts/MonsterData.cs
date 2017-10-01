using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterLevel{
	public int cost;
	public GameObject visualization;
}

public class MonsterData : MonoBehaviour {

	#region Public Vars

	public List<MonsterLevel> levels;

	#endregion

	#region Private Vars

	private MonsterLevel currentLevel;
	private GameObject levelVisualization;
	private int currentLevelIndex;
	private int maxLevelIndex;

	#endregion

	#region Accessors
	public MonsterLevel CurrentLevel {
		get {
			return currentLevel;
		}

		set {
			currentLevel = value;
			currentLevelIndex = levels.IndexOf (currentLevel);
			levelVisualization = levels [currentLevelIndex].visualization;

			if (levelVisualization == null) {
				return;
			}
			foreach (MonsterLevel level in levels) {
				if (currentLevel == level) {
					level.visualization.SetActive (true);
				} else {
					level.visualization.SetActive (false);
				}
			}
		}
	}

	#endregion

	#region Mono Behaviours

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable(){
		CurrentLevel = levels [0];
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start(){
		maxLevelIndex = levels.Count - 1;
	}

	#endregion

	#region Public Methods
	/// <summary>
	/// Gets the next level.
	/// </summary>
	/// <returns>The next level.</returns>
	public MonsterLevel getNextLevel() {
		if (currentLevelIndex < maxLevelIndex) {
			return levels[currentLevelIndex+1];
		} else {
			return null;
		}
	}

	public void increaseLevel() {
		if (currentLevelIndex < levels.Count - 1) {
			CurrentLevel = levels[currentLevelIndex + 1];
		}
	}

	#endregion
}
