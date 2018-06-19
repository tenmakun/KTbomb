using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour {

	public void rankingOnClick () {
		SceneManager.LoadScene ("Ranking");
	}
}
