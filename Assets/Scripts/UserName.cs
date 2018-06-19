using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class UserName : MonoBehaviour {

	string str;
	public InputField inputField;
	public GameObject inputFieldGene;
	public Text AlreadyUseMessage;

	public void SaveName () {
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("ScoreRanking");
    query.WhereEqualTo ("name", inputField.text);
    query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			if (e == null) {
				if (objList.Count == 0) {
					str = inputField.text;
					if (str == "") {
						AlreadyUseMessage.text = "なまえを入力してください";
					} else {
						PlayerPrefs.SetString("KTbomb_user_name", str);
						PlayerPrefs.Save();

						// オブジェクトに値を設定
						NCMBObject rankingClass = new NCMBObject("ScoreRanking");
						rankingClass["name"] = PlayerPrefs.GetString("KTbomb_user_name");
						rankingClass["score"] = PlayerPrefs.GetInt("KTbomb_high_score", 0);
						// データストアへの登録
						rankingClass.SaveAsync();
						Debug.Log(PlayerPrefs.GetString("KTbomb_user_name"));
						Destroy(inputFieldGene);
					}
				} else {
					AlreadyUseMessage.text = "このなまえはすでに使われています。";
				}
			}
		});
	}
}
