using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTest : MonoBehaviour {


	public int score;
	public int highscore;

	public Text scoretext;
	public Text highscoretext;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("CurruntScoreTest");
		highscore = PlayerPrefs.GetInt("HighScoreTest");

		score = 0;
		PlayerPrefs.SetInt("CurruntScoreTest", score);
		scoretext.text = score.ToString ();

		highscoretext.text = highscore.ToString ();

	}
	
	// Update is called once per frame
	void Update () {

		if (score > highscore){
			highscore = score;
			highscoretext.text = score.ToString();

			PlayerPrefs.SetInt ("HighScoreTest", highscore);
		}
	}

	public void SetInt()
	{
		score = score + 1;
		scoretext.text = score.ToString ();

	}
}
