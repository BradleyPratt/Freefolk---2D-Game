using UnityEngine;
using System.Collections;

public class Magical : Weapon {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(this.gameObject, 2.0F);
	}

	void OnCollisionEnter2D(Collision2D col) {
		Destroy(this.gameObject, 0.2F);
	}
}
