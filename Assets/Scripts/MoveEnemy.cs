using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

	#region Public Vars
	[HideInInspector]
	public GameObject[] waypoints;
	public float speed = 1.0f;
	public GameObject sprite;
	#endregion

	#region Private Vars
	private int currentWaypoint = 0;
	private float lastWaypointSwitchTime;
	private AudioSource audioSource;
	#endregion

	#region Mono Behaviors

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start(){
		lastWaypointSwitchTime = Time.time;
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update(){
		// 1 
		Vector3 startPosition = waypoints [currentWaypoint].transform.position;
		Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;
		// 2 
		float pathLength = Vector3.Distance (startPosition, endPosition);
		float totalTimeForPath = pathLength / speed;
		float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
		gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
		// 3 
		if (gameObject.transform.position.Equals(endPosition)) {
			if (currentWaypoint < waypoints.Length - 2) {
				// 3.a 
				currentWaypoint++;
				lastWaypointSwitchTime = Time.time;

				startPosition = waypoints [currentWaypoint].transform.position;
				endPosition = waypoints [currentWaypoint + 1].transform.position;
				RotateIntoMoveDirection (endPosition - startPosition);
			} else {
				// 3.b 
				Destroy(gameObject);

				AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
				// TODO: deduct health
			}
		}
	}

	#endregion

	#region Private Methods

	/// <summary>
	/// Rotates for movement.
	/// </summary>
	private void RotateIntoMoveDirection(Vector3 newDirection) {
		
		float x = newDirection.x;
		float y = newDirection.y;
		float rotationAngle = Mathf.Atan2 (y, x) * 180 / Mathf.PI;

		Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
		sprite.transform.rotation = rotation;
			
	}

	#endregion

}
