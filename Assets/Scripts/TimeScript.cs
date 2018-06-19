using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NCMB;

public class TimeScript : MonoBehaviour {
	private float time = 62;
	public Text ExpTimeText;
	public Text FinishMessage;

	void Start () {
		//初期値60を表示
		//float型からint型へCastし、String型に変換して表示
		GetComponent<Text>().text = ((int)time - 2).ToString();
	}

	void Update (){
		//1秒に1ずつ減らしていく
		time -= Time.deltaTime;
		GetComponent<Text> ().text = ((int)time - 2).ToString ();
		//マイナスは表示しない
		if (time <= 5) GetComponent<Text> ().color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
		if (time <= 2) {
			GetComponent<Text> ().text = "0";
			Destroy(ExpTimeText);
			FinishMessage.text = "おわり";
		}
		if (time < 0) SceneManager.LoadScene ("Result");
	}
}
