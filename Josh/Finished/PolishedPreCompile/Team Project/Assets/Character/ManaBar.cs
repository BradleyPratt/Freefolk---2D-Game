using UnityEngine;
using System.Collections;

public class ManaBar : MonoBehaviour
{

    private int base_mana;
    private float percent_mana, initialXScale, newXScale;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Transform scaleBar;
    public Color objectTint;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        scaleBar = GetComponent<Transform>();
        base_mana = player.GetComponent<Player>().GetMaxMana();
        initialXScale = scaleBar.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        percent_mana = ((float)player.GetComponent<Player>().GetMana()) / base_mana;

        objectTint = new Color(percent_mana, percent_mana, percent_mana, 1.0F);
        spriteRenderer.color = objectTint;
        newXScale = initialXScale * percent_mana;
        scaleBar.localScale = new Vector3(newXScale, scaleBar.localScale.y, scaleBar.localScale.z);

    }
}
