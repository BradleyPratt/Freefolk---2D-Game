﻿using UnityEngine;
using System.Collections;

public class ManaPotion : MonoBehaviour {

    public int restore = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0f);
            col.gameObject.GetComponent<Player>().AddMana(restore);
        }
    }
}
