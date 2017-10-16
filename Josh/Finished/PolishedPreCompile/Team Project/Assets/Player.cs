using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed = 7.5f;
    public float jump_strength = 7.5f;
    public float bullet_force = 15.0f;
    
    public int max_health = 20;
    public int max_mana = 20;
    public int health = 20;
    public int mana = 20;

    private Rigidbody2D rb;
    private float move_x = 0.0f;
    public bool is_jumping = false;
    public bool double_jumped = false;
    private int facing = 1; // 1 is right -1 is left
    private Animator anim;
    [SerializeField]
    private Animator attackanim;
    [SerializeField]
    private Animator mattackanim;
    public float magical_modifier = 1.0f;
    public float physical_modifier = 1.0f;

    // weapons
    private GameObject weapon;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        // setup player objects
        rb = GetComponent<Rigidbody2D>();
        //Camera.main.transform.GetComponent<SmoothFollow>().target = this.transform;

        // setup weapons
        weapon = Resources.Load("prefab/weapon") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        // moving
        move_x = Input.GetAxis("Horizontal");
        // anim.SetFloat("Speed", move_x);

        if (move_x != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
		}


		// rmb button
		if (Input.GetMouseButtonDown (0)) 
			attackanim.SetTrigger ("attack");

        //if (Input.GetMouseButtonDown(1)) 

        //if (Input.GetMouseButtonDown(2))


        // lmb button
        if (Input.GetMouseButtonDown(1))
            mattackanim.SetTrigger("mattack");


        this.gameObject.GetComponent<Renderer>().transform.localScale
            = new Vector3(facing, 1.0f, 1.0f);

        // jumping
        if (is_jumping && !double_jumped)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (rb.velocity.y < 0)
                {
                    double_jumped = true;
                    Jump();
                }
            }
        }
        else if (!is_jumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                is_jumping = true;
                Jump();
            }
        }
        if (rb.velocity.magnitude <= float.Epsilon)
        {
            is_jumping = false;
            double_jumped = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weapon = Resources.Load("prefab/physical") as GameObject;
            GameObject bullet_fired = Instantiate(weapon, (new Vector2(transform.position.x + (0.125f*(float)facing), transform.position.y)), Quaternion.identity) as GameObject;
            //    bullet_fired.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 0.0f), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (mana > 4)
            {
                weapon = Resources.Load("prefab/magical") as GameObject;
                GameObject bullet_fired = Instantiate(weapon, (new Vector2(transform.position.x + (0.25f*(float)facing), transform.position.y+0.001f)), Quaternion.identity) as GameObject;
                bullet_fired.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.12f * (float)facing, 0f), ForceMode2D.Impulse);
                if (facing == -1)
                {
                    bullet_fired.GetComponent<SpriteRenderer>().flipX = true;
                }
                mana -= 4;
            }
            else
            {
                //no mana
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        rb.AddForce(new Vector2(0, 1 * jump_strength), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        if (move_x == 0)
        {
            if (facing == 1)
            {
                facing = 1;
            }
            else if (facing == -1)
            {
                facing = -1;
            }
        }
        else if (move_x > 0)
        {
            facing = 1;
        }
        else if (move_x < 0)
        {
            facing = -1;
        }
        //facing = move_x > 0 ? -1 : 1;
        if (move_x <= 0)
        {
            move_x = -move_x;
        }
        transform.Translate(new Vector3(speed * move_x * Time.deltaTime, 0.0f, 0.0f));
    }

    public void AddHealth(int amount)
    {

        if ((health + amount) <= max_health)
        {
            health += amount;
        }
        else
        {
            health = max_health;
        }
    }

    public void AddMana(int amount)
    {

        if ((mana + amount) <= max_mana)
        {
            mana += amount;
        }
        else
        {
            mana = max_mana;
        }
    }

    public int GetHealth()
    {
        return health;
    }
    public int GetMana()
    {
        return mana;
    }
    public int GetMaxHealth()
    {
        return max_health;
    }
    public int GetMaxMana()
    {
        return max_mana;
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        Enemy temp_script = col.gameObject.GetComponent<Enemy>();

        if (temp_script == null)
        {
            // it's not an enemy
        }
        else
        {
            // It has an enemy based script on it
            int player_damage = 1;
            if (1 == temp_script.DamageType())
            {
                player_damage = (int)(physical_modifier * temp_script.DamageAmount());
            }
            else
            {
                player_damage = (int)(magical_modifier * temp_script.DamageAmount());
            }
            if ((health - player_damage) <= 0)
            {
                // you ded son
                Application.LoadLevel("GameOver");
            }
            else
            {
                // you survived
                health -= player_damage;
            }
        }
    }
}