using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void RestartLevel () {
		int currentSceneBuildIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene(currentSceneBuildIndex);
	}

}
