using UnityEngine;
using System.Collections;

public class SlimeScript : MonoBehaviour {

    public float move_speed = 5f;
    public float attack_strength = 5.0f;
    public float magical_modifier = 1.0f;
    public float physical_modifier = 1.0f;

    public int health = 20;

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
        transform.Translate(new Vector3(move_speed * 1 * Time.deltaTime, 0.0f, 0.0f));
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
       // Time.timeScale = 0;
        move_speed = -move_speed;
//        transform.Translate(new Vector3(move_speed * 100 * Time.deltaTime, 10.0f, 0.0f));
        if (coll.gameObject.tag == "Player")
        {
            health = health - 1;
            Destroy(gameObject, 5);
        }
    }

    //void 
}
