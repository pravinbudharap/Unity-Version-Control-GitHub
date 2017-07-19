using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MenuManager : MonoBehaviour {

	public AudioSource myaudio;
//	private Done_GameController gameController;
	public Text HighScoreText;
	[HideInInspector]
	public int ScoreCount,HighScore;
	public GameObject[] panels;
	public GameObject[] HeliPanels;
	[HideInInspector]
	public int heliselected;
	[HideInInspector]
	public int unlocklevel = 0;
	public GameObject[] levellocks;

	// Use this for initialization
	void Start () 
	{
//		PlayerPrefs.DeleteAll ();  // USE WITH CAUTION DONT UNCOMMENT WITHOUT PERMISTION.

//		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
//		if (gameControllerObject != null)
//		{
//			gameController = gameControllerObject.GetComponent <Done_GameController>();
//		}
//		if (gameController == null)
//		{
//			Debug.Log ("Cannot find 'GameController' script");
//		}

		ScoreCount = PlayerPrefs.GetInt("CurruntScore");
		HighScore = PlayerPrefs.GetInt("HighScore");
		heliselected = PlayerPrefs.GetInt ("heliselected");
		unlocklevel = PlayerPrefs.GetInt ("unlocklevel");

		ScoreCount = 0;
	
		PlayerPrefs.SetInt("CurruntScore", ScoreCount);
		PlayerPrefs.SetInt ("HighScore", HighScore);
		PlayerPrefs.SetInt ("unlocklevel", unlocklevel);

		HighScoreText.text =HighScore.ToString ();

//		temporary
//		PlayerPrefs.SetInt ("HighScore", 201);

	}
	
	// Update is called once per frame
	void Update ()
	{

//		if (PlayerPrefs.GetInt("HighScore") > 100) {
//			PlayerPrefs.SetInt ("unlocklevel", 0);
//		}
		if (PlayerPrefs.GetInt("HighScore") > 200) {
			PlayerPrefs.SetInt ("unlocklevel", 1);
		}

		if(PlayerPrefs.GetInt("unlocklevel") == 0){
			//DEFAULT CONDITION RUN
			Debug.Log ("first level unlocked");
			levellocks[0].SetActive (false);
		}
		if(PlayerPrefs.GetInt("unlocklevel") == 1){
			Debug.Log ("first level unlocked");
			levellocks[0].SetActive (false);
			levellocks[1].SetActive (false);
		}
		if(PlayerPrefs.GetInt("unlocklevel") == 2){
			Debug.Log ("first level unlocked");
//			levellocks[0].SetActive (false);
//			levellocks[1].SetActive (false);
//			levellocks[2].SetActive (false);

		}

	}

	public void selectLevelobject(int levelnumber)
	{
		if (levelnumber == 1) {
			StartCoroutine (FirstLevel ());
		} else if (levelnumber == 2) {
			StartCoroutine (SecondLevel ());
		}else if (levelnumber == 3) {
			StartCoroutine (ThirdLevel ());
		}else if (levelnumber == 4) {
			StartCoroutine (FourthLevel ());
		}else if (levelnumber == 5) {
			StartCoroutine (FifthLevel ());
		}else if (levelnumber == 6) {
			StartCoroutine (SixthLevel ());
		}
	}

	IEnumerator FirstLevel()
	{
		Debug.Log ("caleed");
		GameObject level1 = GameObject.Find ("level1");
		Image templevel1 = level1.GetComponent<Image> ();
		templevel1.enabled = !templevel1.enabled;
		yield return new WaitForSeconds (0);
		GameObject levelselection = GameObject.FindGameObjectWithTag ("Levels");
		Debug.Log (levelselection);
		levelselection.SetActive(false);
		panels[0].SetActive(true);
		templevel1.enabled = !templevel1.enabled;

	}
	IEnumerator SecondLevel()
	{
		GameObject level2 = GameObject.Find ("level2");
		Image templevel2 = level2.GetComponent<Image> ();
		templevel2.enabled = !templevel2.enabled;
		yield return new WaitForSeconds (0.5f);
		GameObject levelselection = GameObject.Find ("LevelSelectionPanel");
		levelselection.SetActive(false);
		panels[0].SetActive(true);
		templevel2.enabled = !templevel2.enabled;
	
	}
	IEnumerator ThirdLevel()
	{
		GameObject level3 = GameObject.Find ("level3");
		Image templevel3 = level3.GetComponent<Image> ();
		templevel3.enabled = !templevel3.enabled;
		yield return new WaitForSeconds (0.5f);
		GameObject levelselection = GameObject.Find ("LevelSelectionPanel");
		levelselection.SetActive(false);
		panels[0].SetActive(true);
		templevel3.enabled = !templevel3.enabled;

	}	
	IEnumerator FourthLevel()
	{
		GameObject level4 = GameObject.Find ("level4");
		Image templevel4 = level4.GetComponent<Image> ();
		templevel4.enabled = !templevel4.enabled;
		yield return new WaitForSeconds (0);
		GameObject levelselection = GameObject.Find ("LevelSelectionPanel");
		levelselection.SetActive(false);
		panels[0].SetActive(true);
		templevel4.enabled = !templevel4.enabled;

	}	
	IEnumerator FifthLevel()
	{
		GameObject level5 = GameObject.Find ("level5");
		Image templevel5 = level5.GetComponent<Image> ();
		templevel5.enabled = !templevel5.enabled;
		yield return new WaitForSeconds (0);
		GameObject levelselection = GameObject.Find ("LevelSelectionPanel");
		levelselection.SetActive(false);
		panels[0].SetActive(true);
		templevel5.enabled = !templevel5.enabled;

	}	
	IEnumerator SixthLevel()
	{
		GameObject level6 = GameObject.Find ("level6");
		Image templevel6 = level6.GetComponent<Image> ();
		templevel6.enabled = !templevel6.enabled;
		yield return new WaitForSeconds (0.5f);
		GameObject levelselection = GameObject.Find ("LevelSelectionPanel");
		levelselection.SetActive(false);
		panels[0].SetActive(true);
		templevel6.enabled = !templevel6.enabled;

	}
		
	public void selectHeliObject(int levelnumber)
	{
		if (levelnumber == 1) {
			StartCoroutine (FirstHeliSelected ());
		} else if (levelnumber == 2) {
			StartCoroutine (SecondHeliSelected ());
		}else if (levelnumber == 3) {
			StartCoroutine (ThirdHeliSelected ());
		}else if (levelnumber == 4) {
			StartCoroutine (FourthHeliSelected ());
		}else if (levelnumber == 5) {
			StartCoroutine (FifthHeliSelected ());
		}else if (levelnumber == 6) {
			StartCoroutine (SixthHeliSelected());
		}
	}

	IEnumerator FirstHeliSelected()
	{
		Debug.Log ("FirstHeliSelected called");
		Image templevel1 = HeliPanels[0].GetComponent<Image> ();
		templevel1.enabled = !templevel1.enabled;
		yield return new WaitForSeconds (0);
		templevel1.enabled = !templevel1.enabled;
		PlayerPrefs.SetInt ("heliselected", 1);
		SceneManager.LoadScene (1);


	}
	IEnumerator SecondHeliSelected()
	{		
		Debug.Log ("SecondHeliSelected called");
		Image templevel2 = HeliPanels[1].GetComponent<Image> ();
		templevel2.enabled = !templevel2.enabled;
		yield return new WaitForSeconds (0);
		templevel2.enabled = !templevel2.enabled;
		PlayerPrefs.SetInt ("heliselected", 2);
		Debug.Log (heliselected);
		SceneManager.LoadScene (1);

	}
	IEnumerator ThirdHeliSelected()
	{
		Image templevel3 = HeliPanels[2].GetComponent<Image> ();
		templevel3.enabled = !templevel3.enabled;
		yield return new WaitForSeconds (0);
		templevel3.enabled = !templevel3.enabled;
		PlayerPrefs.SetInt ("heliselected", 3);
		SceneManager.LoadScene (1);

	}	
	IEnumerator FourthHeliSelected()
	{
		Image templevel4 = HeliPanels[3].GetComponent<Image> ();
		templevel4.enabled = !templevel4.enabled;
		yield return new WaitForSeconds (0);
		templevel4.enabled = !templevel4.enabled;
		PlayerPrefs.SetInt ("heliselected", 4);
		SceneManager.LoadScene (1);

	}	
	IEnumerator FifthHeliSelected()
	{
		Image templevel5 = HeliPanels[4].GetComponent<Image> ();
		templevel5.enabled = !templevel5.enabled;
		yield return new WaitForSeconds (0);
		templevel5.enabled = !templevel5.enabled;
		PlayerPrefs.SetInt ("heliselected", 5);
		SceneManager.LoadScene (1);

	}	
	IEnumerator SixthHeliSelected()
	{
		Image templevel6 = HeliPanels[5].GetComponent<Image> ();
		templevel6.enabled = !templevel6.enabled;
		yield return new WaitForSeconds (0);
		templevel6.enabled = !templevel6.enabled;
		PlayerPrefs.SetInt ("heliselected", 6);
		SceneManager.LoadScene (1);

	}
}
