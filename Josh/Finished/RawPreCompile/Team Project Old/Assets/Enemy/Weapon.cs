using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public float DamageAmount () {
		return damage;
	}
	
	public int DamageType () {
		return 1;
	}
}
