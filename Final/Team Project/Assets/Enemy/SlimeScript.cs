using UnityEngine;
using System.Collections;

public class SlimeScript : Enemy
{

    private Rigidbody2D rb;
    private int facing = 1; // 1 is right -1 is left
    

    // Use this for initialization
    void Start()
    {

        // setup player objects
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AreaLimit")
        {
            move_speed = -move_speed;
        }
    }


    void OnCollisionEnter2D (Collision2D col)
    {

        move_speed = -move_speed;
        transform.Translate(new Vector3(move_speed * 10 * Time.deltaTime, 0.0f, 0.0f));

		Weapon temp_script = col.gameObject.GetComponent<Weapon>();
		
		if (temp_script == null)
		{
			// it's not a weapon
		}
		else
		{
			// It's a weapon
			float enemy_damage = temp_script.DamageAmount();
			if (1 == temp_script.DamageType()) // one means it's physical
			{
				enemy_damage = (int)(physical_modifier * temp_script.DamageAmount());
			} else
			{
				enemy_damage = (int)(magical_modifier * temp_script.DamageAmount());
			}
			if ((health - enemy_damage) <= 0)
			{
				// you ded son
				Destroy(this.gameObject, 0);
			}
			else
			{
				// you survived
				health -= enemy_damage;
			}
		}
	}
}
