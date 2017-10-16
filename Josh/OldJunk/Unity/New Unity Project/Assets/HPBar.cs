using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {

	private int base_health;
	private float percent_health;
	public Sprite hp0, hp1, hp2, hp3, hp4, hp5, hp6, hp7, hp8;
    public SpriteRenderer spriteRenderer;
	//var player = GameObject.FindWithTag("Player");
	public Color objectTint;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
		//base_health = player.GetComponent (Player).GetHealth ();
	}
	
	// Update is called once per frame
	void Update () {
	    
//		percent_health = (player.GetComponent(Player).GetHealth())/base_health;
//
//		if (percent_health > 0.9) {
//			spriteRenderer.sprite = hp10;
//		} else if (percent_health > 0.8) {
//			spriteRenderer.sprite = hp9;
//		}
		objectTint = new Color (1.0F, 1.0F, 1.0F, 1.0F);
		spriteRenderer.color = objectTint;
	}
}
