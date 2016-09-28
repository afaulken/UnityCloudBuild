using UnityEngine;
using System.Collections;

public class BallCheck : MonoBehaviour {

    public int score;
    public int isDead;
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if(col.transform.tag == "ScoreBox")
        {
            score++;
            Debug.Log("BOI YOU MADE IT");
        }

        if (col.transform.tag == "Ring")
        {
            isDead++;
            Debug.Log("you is dead");
        }
    }
}
