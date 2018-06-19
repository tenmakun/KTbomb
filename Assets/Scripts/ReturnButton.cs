using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour {

  /// ボタンをクリックした時の処理
  public void returnOnClick() {
    ScoreController.score = "0";
    SceneManager.LoadScene ("Title");
  }
}
