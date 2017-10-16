using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float lifetime = 2.0f;

    // Use this for when the object is spawned
    void Awake() {

        // Destroy the object after it has existed for a short period of time
        Destroy(this.gameObject, lifetime);

    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.transform.tag != "Player") {
            Destroy(this.gameObject);
        }

    }
}
