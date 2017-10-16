using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float health = 20;

    public float move_speed = 5f;

    public float attack_strength = 5.0f;

    public float magical_modifier = 1.0f;
    public float physical_modifier = 1.0f;
    
    // Use this for initialization

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void Move ()
    {
        float rotation_angle = (Quaternion.Angle(Quaternion.Euler(new Vector3(0, 0, 0)), GetComponent<Transform>().rotation)) % 360;
        
        if ((rotation_angle < 90) | (rotation_angle > 270))
        {
            transform.Translate(new Vector3(move_speed * 1 * Time.deltaTime, 0.0f, 0.0f));
        }
    }

    public float DamageAmount()
    {
        return attack_strength;
    }

    // DamageType indicates which modifier the player should use to calculate damage taken.
    // 1 is physical, 2 is magical, 1 is default
    public int DamageType()
    {
        return 1;
    }


}
