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

    void OnCollisionEnter2D (Collision2D coll)
    {

        move_speed = -move_speed;
        transform.Translate(new Vector3(move_speed * 10 * Time.deltaTime, 0.0f, 0.0f));

    }

    //void 
}
