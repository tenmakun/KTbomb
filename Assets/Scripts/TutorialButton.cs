using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour {

	public void tutorialOnClick () {
		SceneManager.LoadScene ("Tutorial");
	}
}
