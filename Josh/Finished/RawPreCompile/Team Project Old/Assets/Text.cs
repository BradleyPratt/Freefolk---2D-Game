using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour
{

    public GameObject menu;
    public string key=("key");
    public int mouse=(-1);
    public float timer;
    private bool isShowing;

    void Update()
    {
        if (timer > -1)
            timer -= Time.deltaTime;

        if (Input.GetKeyDown(key) || Input.GetMouseButtonDown(mouse))
        {
            menu.SetActive(isShowing);
        }
        else if (timer <= 0 && timer > -1)
        {
            menu.SetActive(isShowing);
        }
    }
}