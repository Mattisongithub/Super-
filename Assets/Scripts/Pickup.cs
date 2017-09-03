using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public float WeightInKg;
	PlayerStats ps = new PlayerStats ();
	public GameObject player;
	bool isHeld = false;
	Component rigidbody_c;
	public float throw_speed = 2;
	AimBehaviour ab = new AimBehaviour ();
	Item lookingAtItem;

	void Start () {
		isHeld = false;
		gameObject.GetComponent<MeshCollider> ().enabled = true;
	}

	void Update () {
		if (Input.GetButtonDown ("Pickup")) {
		//	Rect crosshair_pos = Rect ((Screen.width - ab.crosshair.width) / 2, (Screen.height - ab.crosshair.height / 2), ab.crosshair.width, ab.crosshair.height);
		//	crosshair_pos;
			if (isHeld) {
				gameObject.transform.parent = null;
				isHeld = false;
				rigidbody_c = gameObject.AddComponent<Rigidbody> ();
				gameObject.GetComponent<MeshCollider> ().enabled = true;
				if (Input.GetButtonDown ("Aim")) {
					rigidbody_c.gameObject.GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * throw_speed);
				}
			} else {
				gameObject.GetComponent<MeshCollider> ().enabled = false;
				gameObject.transform.parent = player.transform;
				gameObject.transform.position = player.transform.position;
				gameObject.transform.rotation.Set (82.377f, 0f, 0f, 0f);
				Destroy (rigidbody_c);
				isHeld = true;
			}
		}
	}
}