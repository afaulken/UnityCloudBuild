using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject gameOverScreen;
    public GameObject FullRing;
    public GameObject ball;
    public GameObject Background;
    public GameObject GreenRing;
    public GameObject PurpleRing;
    public GameObject BlueRing;
    public GameObject YellowRing;
    public Material matYellow;
    public Material matBlue;
    public Material matGreen;
    public Material matPurple;

    public TextMesh scoreText;

    private bool ballMoving;

    public int colorID; // can be 0, 1, 2, or 3 depending on what color is picked
    private int tempScore;
    private int lost;
    public int realScore;

    public float rotSpeed;
    public float ballSpeed;


    void Start ()
    {
        gameOverScreen.SetActive(false);
        colorID = Random.Range(0, 4);
    }

	void Update () {
        string b = "Score: ";
        scoreText.text = b + realScore.ToString();

        realScore = ball.transform.GetComponent<BallCheck>().score;
        lost = ball.transform.GetComponent<BallCheck>().isDead;

        if (colorID == 0)//This is blue
        {
            BlueRing.transform.Translate(Vector3.back * 20);
            Background.transform.GetComponent<MeshRenderer>().material = matBlue;
            colorID = 10;
        }else if(colorID == 1)//This is green
        {
            GreenRing.transform.Translate(Vector3.back * 20);
            Background.transform.GetComponent<MeshRenderer>().material = matGreen;
            colorID = 20;
        }
        else if (colorID == 2)//This is purple
        {
            PurpleRing.transform.Translate(Vector3.back * 20);
            Background.transform.GetComponent<MeshRenderer>().material = matPurple;
            colorID = 30;
        }
        else if (colorID == 3)//This is yellow
        {
            YellowRing.transform.Translate(Vector3.back * 20);
            Background.transform.GetComponent<MeshRenderer>().material = matYellow;
            colorID = 40;
        }

        if (ballMoving == true)
        {
            ball.transform.Translate(Vector3.right * Time.deltaTime * ballSpeed);
        }

        FullRing.transform.Rotate(0, 0, -rotSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballMoving = true;
        }
        if(tempScore != realScore)
        {
            madePoint();
            tempScore = realScore;
        }
        if(lost != 0)
        {
            hitRing();
        }
	}

    void hitRing ()
    {
        ball.SetActive(false);
        rotSpeed = 0f;
        ballMoving = false;
        gameOverScreen.SetActive(true);
    }

    void madePoint ()
    {
        ballMoving = false;
        ball.transform.localPosition = new Vector3(0, 0, 0);
        if(colorID == 10)
        {
            BlueRing.transform.Translate(Vector3.forward * 20);
        }else if(colorID == 20)
        {
            GreenRing.transform.Translate(Vector3.forward * 20);
        }
        else if (colorID == 30)
        {
            PurpleRing.transform.Translate(Vector3.forward * 20);
        }
        else if (colorID == 40)
        {
            YellowRing.transform.Translate(Vector3.forward * 20);
        }
        colorID = Random.Range(0, 4);

        if (rotSpeed >= 180)
        {
            rotSpeed += 5f;
        }else if(rotSpeed >= 0)
        {
            rotSpeed = rotSpeed * 1.1f;
        }
    }
}
