using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {
	public GameObject parentPauseUI;

	// Use this for initialization
	public void onClickRestart () {
		Destroy(parentPauseUI);
		Time.timeScale = 1.0f;
	}

}
