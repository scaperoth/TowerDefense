using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour {

	#region Public Vars

	public GameObject monsterPrefab;

	#endregion

	#region Private Vars

	private GameManagerBehavior gameManager;
	private GameObject monster;
	private AudioSource audioSource;
	private MonsterData monsterData;
	private MonsterLevel nextLevel;

	#endregion

	#region Mono Behaviours

	void Start(){
		audioSource = gameObject.GetComponent<AudioSource> ();
		gameManager = GameManagerBehavior.Instance;
		monsterData = monsterPrefab.GetComponent<MonsterData> ();
	}

	#endregion

	#region Public Methods
	/// <summary>
	/// Raises the mouse up event.
	/// </summary>
	void OnMouseUp () {
		
		// check if the monster is able to be placed
		if (canPlaceMonster ()) {
			
			// instantiate monster and get its data
			monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity) as GameObject;
			monsterData = monster.GetComponent<MonsterData> ();

			// organize the gameobject
			monster.transform.SetParent (transform.parent);

			// play sound
			audioSource.PlayOneShot(audioSource.clip);
			gameManager.Gold -= monsterData.CurrentLevel.cost;

		} else if (canUpgradeMonster()) {
			
			monsterData.increaseLevel();
			audioSource.PlayOneShot(audioSource.clip);
			gameManager.Gold -= monsterData.CurrentLevel.cost;
		}
	}
	#endregion

	#region Private Methods
	/// <summary>
	/// Checks if monster can be placed
	/// </summary>
	/// <returns><c>true</c>, if monster can be placed, <c>false</c> otherwise.</returns>
	private bool canPlaceMonster() {
		int cost = monsterData.levels[0].cost;
		return monster == null && gameManager.Gold >= cost;
	}

	private bool canUpgradeMonster() {
		if (monster != null) {
			nextLevel = monsterData.getNextLevel();
			if (nextLevel != null) {
				return gameManager.Gold >= nextLevel.cost;
			}
		}
		return false;
	}
	#endregion
}
