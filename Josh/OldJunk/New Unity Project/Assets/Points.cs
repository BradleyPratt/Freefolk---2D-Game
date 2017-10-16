using UnityEngine;
using System.Collections;
using System;

public class Points : MonoBehaviour {

    int currentscore;
    int[] highscore;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddPoints (int increase)
    {
        currentscore = currentscore + increase;
    }

    void RemovePoints (int decrease)
    {
        currentscore = currentscore - decrease;
    }

    void ResetPoints ()
    {
        highscore[highscore.Length] = currentscore;
        currentscore = 0;
    }
}
