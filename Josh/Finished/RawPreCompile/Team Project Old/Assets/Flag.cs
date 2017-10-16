using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

    public Sprite newColor;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sprite.sprite = newColor;
            StartCoroutine(loadSceneAfterDelay(3));
        }
    }

    IEnumerator loadSceneAfterDelay(float waitbySecs)
    {
        yield return new WaitForSeconds(waitbySecs);
        Application.LoadLevel("GameWon");
    }
}
