using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTController : MonoBehaviour {
	public GameObject Prefab;
	public Vector3 clickPosition;
	public Vector3 touchPosition;
	public GameObject MainCamera;
	public float forwardSpeed;
	public float upSpeed = 0;
	public float rlSpeed = 0;
	public AudioClip throwSe;
	private Rigidbody rb;
	private Vector3 prefabPosition = new Vector3();
	private Quaternion prefabRotation;
	private float firstTime;
	public float timeElapsed;

	// Use this for initialization
	void Start () {
		// QuickRanking.SaveRanking("tenma", 100)
	}

	// Update is called once per frame
	void Update () {

		prefabPosition[0] = MainCamera.transform.position.x * 1.2f;
		prefabPosition[1] = 5;
		prefabPosition[2] = MainCamera.transform.position.z * 1.2f;

		prefabRotation = MainCamera.transform.rotation;
		prefabRotation.x = 0;
		prefabRotation.z = 0;

		firstTime += Time.deltaTime;

		if (Input.GetMouseButtonDown(1) && firstTime >= timeElapsed) {
			clickPosition = Input.mousePosition;
			if (clickPosition.y > Screen.height * 0.4 && clickPosition.x >= 0 && clickPosition.x <= Screen.width) {
				rlSpeed = 240 * (clickPosition.x / Screen.width) - 120;
				upSpeed = 400 * ((clickPosition.y - Screen.height * 0.4f) / (Screen.height - Screen.height * 0.4f)) + 500;
				GameObject KTs = Instantiate(Prefab, prefabPosition, prefabRotation)as GameObject;
				Vector3 force;
				force = (KTs.transform.forward * forwardSpeed) + (KTs.transform.up * upSpeed) + (KTs.transform.right * rlSpeed);
				KTs.GetComponent<Rigidbody>().AddForce (force);
				GetComponent<AudioSource>().PlayOneShot(throwSe);
				firstTime = 0;
			}
    }

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && firstTime >= timeElapsed) {
			Touch t = Input.touches[0];
			touchPosition = t.position;
			if (touchPosition.y > Screen.height * 0.4 && touchPosition.x >= 0 && touchPosition.x <= Screen.width) {
				rlSpeed = 240 * (touchPosition.x / Screen.width) - 120;
				upSpeed = 400 * ((touchPosition.y - Screen.height * 0.4f) / (Screen.height - Screen.height * 0.4f)) + 500;
				GameObject KTs = Instantiate(Prefab, prefabPosition, prefabRotation)as GameObject;
				Vector3 force;
				force = (KTs.transform.forward * forwardSpeed) + (KTs.transform.up * upSpeed) + (KTs.transform.right * rlSpeed);
				KTs.GetComponent<Rigidbody>().AddForce (force);
				GetComponent<AudioSource>().PlayOneShot(throwSe);
				firstTime = 0;
			}
    }
	}
	void OnCollisionEnter(Collision collision) {
    //衝突判定
    if (collision.gameObject.tag == "Plane") {
      //相手のタグがBallならば、自分を消す
      Object.Destroy(this.gameObject);
    }
  }
}
