using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class Ranking : MonoBehaviour {
	// public Text RankingText;
	private int count = 1;

	[SerializeField]
	RectTransform nodePrefab = null;
	[SerializeField]
	Text waitText = null;

	// Use this for initialization
	void Start () {
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("ScoreRanking");
		query.WhereEqualTo ("name", PlayerPrefs.GetString("KTbomb_user_name"));
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			if (e == null) {
				if (objList.Count != 0) {
					foreach (NCMBObject obj in objList) {
						NCMBObject deleteClass = new NCMBObject("ScoreRanking");
						deleteClass.ObjectId = obj.ObjectId;
						deleteClass.DeleteAsync ();
					}
				}
				NCMBObject rankingClass = new NCMBObject("ScoreRanking");
				// オブジェクトに値を設定
				rankingClass["name"] = PlayerPrefs.GetString("KTbomb_user_name");
				rankingClass["score"] = PlayerPrefs.GetInt("KTbomb_high_score");
				// データストアへの登録
				rankingClass.SaveAsync((NCMBException error) => {
					if (e == null) {
						fetchTopRankers();
					}
				});
			}
		});

	}

	public void fetchTopRankers() {

		// データストアの「HighScore」クラスから検索
    NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("ScoreRanking");
    query.OrderByDescending ("score");
    query.Limit = 100;
    query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
	    if (e != null) {
				Destroy(waitText);
				var item = GameObject.Instantiate(nodePrefab) as RectTransform;
				item.SetParent(transform, false);
				var text = item.GetComponentInChildren<Text>();
				text.text = "ランキング取得時にエラーが発生しました。";
	    } else {
				Destroy(waitText);
	      //検索成功時の処理
				// var item = GameObject.Instantiate(nodePrefab) as RectTransform;
				// item.SetParent(transform, false);
				// var text = item.GetComponentInChildren<Text>();
				// text.text = "あなたのハイスコア";

				foreach (NCMBObject obj in objList) {
	        // int s = System.Convert.ToInt32(obj["score"]);
	        // string n = System.Convert.ToString(obj["name"]);

					var item = GameObject.Instantiate(nodePrefab) as RectTransform;
					if (count == 1) {
						item.GetComponent<Image>().color = new Color(255f / 255f, 224f / 255f, 0f / 255f);
					} else if (count == 2) {
						item.GetComponent<Image>().color = new Color(192f / 255f, 192f / 255f, 192f / 255f);
					} else if (count == 3) {
						item.GetComponent<Image>().color = new Color(172f / 255f, 107f / 255f, 37f / 255f);
					}

					item.SetParent(transform, false);
					var text = item.GetComponentInChildren<Text>();
					text.text = count.ToString() + "." + obj["name"] + ":" + obj["score"] ;

					count++;
	      }
	    }
    });
	}
}
