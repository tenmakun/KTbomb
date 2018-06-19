using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text scoreText;
	public static string score = "0";

	void Update () {
		scoreText.text = score;
	}

	void OnCollisionEnter(Collision collision) {
		//衝突判定
		if (collision.gameObject.tag == "BombKT") {
			float dis = Vector3.Distance(this.gameObject.transform.position, collision.gameObject.transform.position);
			score = (int.Parse(scoreText.text) + Mathf.Floor(dis * 1000f)).ToString ();
			Object.Destroy(collision.gameObject);
		}

		else if (collision.gameObject.tag == "KT") {
			Object.Destroy(collision.gameObject);
		}
	}
}
