using UnityEngine;
using System.Collections;

public class Physical : Weapon {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 0.2F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
