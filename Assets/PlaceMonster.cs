using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour {
	public GameObject monsterPrefab;
	private GameObject monster;
	private AudioSource audioSource;

	#region Mono Behaviours

	void Start(){
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	#endregion

	#region Private Methods
	/// <summary>
	/// Checks if monster can be placed
	/// </summary>
	/// <returns><c>true</c>, if monster can be placed, <c>false</c> otherwise.</returns>
	private bool canPlaceMonster() {
		return monster == null;
	}
	#endregion

	#region Public Methods
	/// <summary>
	/// Raises the mouse up event.
	/// </summary>
	void OnMouseUp () {
		
		// check if the monster is able to be placed
		if (canPlaceMonster ()) {
			
			// instantiate monster
			monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity) as GameObject;

			// organize the gameobject
			monster.transform.SetParent (transform.parent);

			// play sound
			audioSource.PlayOneShot(audioSource.clip);

			// TODO: Deduct gold
		}
	}
	#endregion
}
