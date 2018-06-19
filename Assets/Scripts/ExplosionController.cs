using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionController : MonoBehaviour {
	public GameObject ExploadPos;
	public Text bombLoopSec;
	public float exploadpower = 1000.0F;
	public float exploadradius = 10.0F;
	public float waitTime = 10;
	public AudioClip se;
	public ParticleSystem exParticle;
	private float time = 10;

	void Start () {
		exParticle.Stop();
	}

	void explosion() {
		Collider[] kts = Physics.OverlapSphere(ExploadPos.transform.position, exploadradius);
		foreach (Collider obj in kts) {
			if ((obj)&&(obj.tag=="KT" || obj.tag=="BombKT")&&(obj.GetComponent<Rigidbody>())) {
				obj.tag = "BombKT";
				obj.GetComponent<Rigidbody>().AddExplosionForce(exploadpower, ExploadPos.transform.position, exploadradius);
			}
		}
  }

	void Update () {
		time -= Time.deltaTime;
		bombLoopSec.text = ((int)time).ToString ();
		if (time <= 1) {
			explosion();
			exParticle.Play ();
			GetComponent<AudioSource>().PlayOneShot(se);
			time = 11;
		}
	}
}
