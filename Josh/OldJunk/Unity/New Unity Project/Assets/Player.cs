using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 8.5f;
    public float jump_strength = 5.0f;
    public float bullet_force = 15.0f;

    public int ammo = 0;
    public int base_ammo_count = 30;
    public int health = 20;

    private Rigidbody2D rb;
    private float move_x = 0.0f;
    private bool is_jumping = false;
    private bool double_jumped = false;
    private int facing = 1; // 1 is right -1 is left
    public float magical_modifier = 1.0f;
    public float physical_modifier = 1.0f;

    // weapons
    private GameObject weapon;

    // Use this for initialization
    void Start() {

        // setup player objects
        weapon = Resources.Load("prefab/weapon") as GameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        // moving
        move_x = Input.GetAxis("Horizontal");

        // jumping
        if (is_jumping && !double_jumped) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (rb.velocity.y < 0) {
                    double_jumped = true;
                    Jump();
                }
            }
        } else if (!is_jumping) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                is_jumping = true;
                Jump();
            }
        }
        if (rb.velocity.magnitude <= float.Epsilon) {
            is_jumping = false;
            double_jumped = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weapon = Resources.Load("prefab/weapon") as GameObject;
            GameObject bullet_fired = Instantiate(weapon, transform.position, Quaternion.identity) as GameObject;
            bullet_fired.GetComponent<Rigidbody2D>().AddForce(new Vector2(bullet_force * 1.0f * facing, 0.0f), ForceMode2D.Impulse);
        }

    }

    void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        rb.AddForce(new Vector2(0, 1 * jump_strength), ForceMode2D.Impulse);
    }

    void FixedUpdate() {
        transform.Translate(new Vector3(speed * move_x * Time.deltaTime, 0.0f, 0.0f));
        facing = move_x > 0 ? 1 : -1;
    }

    void AddHealth(int amount) {

        if (health + amount <= 0) {
            Debug.Log("You're dead.");
        } else {
            health += amount;
        }
    }

    int GetHealth()
    {
        return health;
    }

    void OnCollisionEnter2D (Collision2D col)
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
            } else
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
