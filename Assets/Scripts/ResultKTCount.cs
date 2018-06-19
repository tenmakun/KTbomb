using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class ResultKTCount : MonoBehaviour {
	public UnityEngine.UI.Text ResultCount;
	public UnityEngine.UI.Text HighScore;

	void Start () {
		if (PlayerPrefs.GetInt("KTbomb_high_score") < int.Parse(ScoreController.score)) {
			PlayerPrefs.SetInt("KTbomb_high_score", int.Parse(ScoreController.score));
			PlayerPrefs.Save();
		}
	}

	// Update is called once per frame
	void Update () {
		ResultCount.text = ScoreController.score;
		HighScore.text = PlayerPrefs.GetInt("KTbomb_high_score").ToString();
	}
}
