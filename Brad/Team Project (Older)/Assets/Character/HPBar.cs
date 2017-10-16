using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {

	private int base_health;
	private float percent_health, initialXScale, newXScale;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Transform scaleBar;
	public Color objectTint;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        scaleBar = GetComponent<Transform>();
		base_health = player.GetComponent<Player>().GetMaxHealth();
        initialXScale = scaleBar.localScale.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindWithTag("Player");

        percent_health = ((float)player.GetComponent<Player>().GetHealth())/base_health;

		objectTint = new Color (percent_health, percent_health, percent_health, 1.0F);
		spriteRenderer.color = objectTint;
        newXScale = initialXScale * percent_health;
        scaleBar.localScale = new Vector3(newXScale, scaleBar.localScale.y, scaleBar.localScale.z);
        
    }
}
