using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

  /// ボタンをクリックした時の処理
  public void startOnClick() {
    Time.timeScale = 1f;
    ScoreController.score = "0";
    SceneManager.LoadScene ("GameScene");
  }
}
