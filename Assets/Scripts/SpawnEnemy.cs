using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
	#region Public Vars
	public GameObject[] waypoints;
	public GameObject testEnemyPrefab;
	#endregion

	#region Private Vars
	private GameObject testEnemy;
	private MoveEnemy enemyMovement;
 	#endregion

	#region Mono Behaviors

	void Start(){
		testEnemy = Instantiate (testEnemyPrefab);
		testEnemy.transform.SetParent (transform);
		enemyMovement = testEnemy.GetComponent<MoveEnemy> ();
		enemyMovement.waypoints = waypoints;
	}

	#endregion
}
