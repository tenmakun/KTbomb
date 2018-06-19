using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalScore : MonoBehaviour {

	public int currentRank = 0;
	public GameObject inputFieldPrefab;
	public Text welcomeMessage;

	// Use this for initialization
	void Start () {

		int highScore = PlayerPrefs.GetInt("KTbomb_high_score", 0);
		string userName = PlayerPrefs.GetString("KTbomb_user_name", "Anonymous0010109291012");

		if (highScore == 0) {
			PlayerPrefs.SetInt("KTbomb_high_score", 0);
			PlayerPrefs.Save();
		}

		if (userName == "Anonymous0010109291012") {
			Instantiate (inputFieldPrefab);
		} else {
			welcomeMessage.text = "ようこそ" + PlayerPrefs.GetString("KTbomb_user_name").ToString() + "さん！";
		}
	}
}
