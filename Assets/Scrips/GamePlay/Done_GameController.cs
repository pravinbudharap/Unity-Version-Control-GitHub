using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
	public GameObject boss;
	public Vector3 bosposition;
	bool onetime = true;
	float nextbosstime;

	//for hazards  enemy
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;


	//for helicopter hazards  enemy
	public GameObject[] EnemyHazards;
	public Vector3 EnemyValues;
	public int EnemyCount;
	public float EnemyspawnWait;
	public float EnemystartWait;
	public float EnemywaveWait;

	//for helicopter Player Prefabs
	public GameObject[] Helicopters;
	public GameObject PlayerPrefab, BulletSpawnerPrefab;
	public Vector3 PlayerSpawnPostion;

//	public int EnemyCount;
//	public float EnemyspawnWait;
//	public float EnemystartWait;
//	public float EnemywaveWait;
	
//	public GUIText scoreText;
//	public GUIText restartText;
//	public GUIText gameOverText;
	
//	private bool gameOver;
	private bool restart;
	private int score;

	//MY NEW VARIABLES
	public Text ScoreText, HighScoreText;
	[HideInInspector]
	public int ScoreCount, HighScore;
	public Text LifeText;
	public int LifeCount=5;
	public GameObject GameOverPanel, WinPanel;


	//PLAYER HEALTHBAR VARIABLES
	public Slider PlayerhealthBarSlider ;  //reference for slider
	private bool isGameOver = false, movementon= false; //flag to see if game is over
	public GameObject Playerhealthbarcolor;
	[HideInInspector]
	public int HeartLife = 0, HeartLifeCompare=2; 

	//ROCKET VARIABLES
	public Text RocketText;
	[HideInInspector]
	public float nextFire,fireRate = 10;
	[HideInInspector]
	public int rocketcounter = 5;
	//ROCKET VARIABLES
	public GameObject Rocketshot;
	public Transform RocketSpawn1, RocketSpawn2;

	Done_PlayerController done_playercontroller = new Done_PlayerController();
	MenuManager menumanagaer = new MenuManager();

	void OnEnabled()
	{
		Time.timeScale = 0f;
		AudioListener.volume = 0f;

	}

	void Awake()
	{
	}
	void Start ()
	{

		rocketcounter = 5;

//		ScoreCount = PlayerPrefs.GetInt("CurruntScore");
//		HighScore = PlayerPrefs.GetInt("HighScore");
	
		ScoreCount = 0;
		PlayerPrefs.SetInt("CurruntScore", ScoreCount);
		ScoreText.text = ScoreCount.ToString ();

		HighScore = PlayerPrefs.GetInt("HighScore");

		PlayerPrefs.SetInt ("HighScore", HighScore);
		HighScoreText.text = HighScore.ToString ();

			
		if (PlayerPrefs.GetInt("heliselected") == 1) {
			Debug.Log ("first heli instatiated");
			Instantiate (Helicopters [0], PlayerSpawnPostion, Quaternion.identity);
//			Instantiate (BulletSpawnerPrefab, PlayerSpawnPostion, Quaternion.identity);
		} else if (PlayerPrefs.GetInt("heliselected") == 2) {
			Debug.Log ("second heli selected ");
			Instantiate (Helicopters [1], PlayerSpawnPostion, Quaternion.identity);
		} else if (PlayerPrefs.GetInt("heliselected") == 3) {
			Debug.Log ("third heli selected");
			Instantiate (Helicopters [2], PlayerSpawnPostion, Quaternion.identity);
		} else if (PlayerPrefs.GetInt("heliselected") == 4) {
			Debug.Log ("fourth heli selected");
			Instantiate(Helicopters[3],PlayerSpawnPostion, Quaternion.identity);
		}else if(PlayerPrefs.GetInt("heliselected") == 5){
			Debug.Log("fifth heli selected");
			Instantiate(Helicopters[4],PlayerSpawnPostion,Quaternion.identity);
		}else if(PlayerPrefs.GetInt("heliselected") == 6){
			Debug.Log("sixth heli selected");
			Instantiate(Helicopters[5],PlayerSpawnPostion,Quaternion.identity);
		}

		restart = false;
		score = 0;

//		gameOver = false;
//		restartText.text = "";
//		gameOverText.text = "";
//		UpdateScore ();

		StartCoroutine (SpawnHazards ());
		StartCoroutine (SpawnEnemy ());

	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

		//MY FUNCTION
		if (ScoreCount <= 0) 
		{
			Debug.Log (ScoreCount);
			ScoreCount = 0;
			ScoreText.text = ScoreCount.ToString ();
		}

		if (ScoreCount > HighScore){
			Debug.Log ("HighScore called");
			HighScore = ScoreCount;
			HighScoreText.text = ScoreCount.ToString();
			PlayerPrefs.SetInt ("HighScore", HighScore);
		}

		//	BOSS INSTATIANTE
		if (Time.time > 15.0f && onetime) 
		{
			Debug.Log ("boss called");
			Instantiate (boss, bosposition, Quaternion.identity);
			onetime = false;
//			nextbosstime = Time.time + 20.0f;
		}

//		if (nextbosstime < Time.time) {
//			onetime = true;
//		}

	}
	
	IEnumerator SpawnHazards ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
//				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
//			if (gameOver)
//			{
//				restartText.text = "Press 'R' for Restart";
//				restart = true;
//				break;
//			}
		}
	}

	IEnumerator SpawnEnemy ()
	{
		yield return new WaitForSeconds (EnemystartWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = EnemyHazards [Random.Range (0, EnemyHazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-EnemyValues.x, EnemyValues.x), EnemyValues.y, EnemyValues.z);
				Debug.Log (spawnPosition);
//				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (EnemyspawnWait);
			}
			yield return new WaitForSeconds (EnemywaveWait);

//			if (gameOver)
//			{
//				restartText.text = "Press 'R' for Restart";
//				restart = true;
//				break;
//			}
		}
	}

	//MY FUNCTION
	IEnumerator SpawnPlayer ()
	{
				Debug.Log ("spawn player called");
				yield return new WaitForSeconds (3);
//				GameObject hazard = EnemyHazards [Random.Range (0, EnemyHazards.Length)];
				Vector3 spawnPosition = new Vector3 (PlayerSpawnPostion.x, PlayerSpawnPostion.y, PlayerSpawnPostion.z);
				
//				GameObject TempPlayerObject = GameObject.FindGameObjectWithTag ("Player");
//				GameObject TempBulletSpawnerObject = GameObject.FindGameObjectWithTag ("Player");
				
				PlayerPrefab.transform.position = PlayerSpawnPostion;
				BulletSpawnerPrefab.transform.position = PlayerSpawnPostion;

				PlayerPrefab.SetActive (true);
//				BulletSpawnerPrefab.SetActive (true);
				yield return new WaitForSeconds (2);

				GameObject PlayerController = GameObject.FindGameObjectWithTag ("Player");
				if (PlayerController != null)
				{
					Debug.Log (" find 'Done_PlayerController' script");

						done_playercontroller = PlayerController.GetComponent <Done_PlayerController>();
				}
				if (done_playercontroller == null)
				{
					Debug.Log ("Cannot find 'GameController' script");
				}
				
				done_playercontroller.Update ();

//				Instantiate (PlayerPrefab, spawnPosition, Quaternion.identity);
//				Instantiate (BulletSpawnerPrefab, spawnPosition, Quaternion.identity);
//				yield return new WaitForSeconds (EnemyspawnWait);
	}


//	public void AddScore (int newScoreValue)
//	{
//		score += newScoreValue;
//		UpdateScore ();
//	}
//	
//	void UpdateScore ()
//	{
//		scoreText.text = "Score: " + score;
//	}
//	
//	public void GameOver ()
//	{
//		gameOverText.text = "Game Over!";
//		gameOver = true;
//	}

	//MY FUNCTION
	public void LifeDecriment()
	{
		if (LifeCount <= 0) {
			Debug.Log ("life is 0 ");
			Time.timeScale = 0f;
			AudioListener.volume = 0f;
			GameOverPanel.SetActive (true);

		} else {
			LifeCount = LifeCount - 1;
			LifeText.text = LifeCount.ToString ();
		}
	}

	//PLAYER MY FUNCTION
	public void PlayerHealthDecriment()
	{
		
		//if player triggers fire object and health is greater than 0
		if(PlayerhealthBarSlider.value>0.1f)
		{
			Debug.Log ("player health decrease");
			PlayerhealthBarSlider.value -=.05f;  //reduce health
			if (PlayerhealthBarSlider.value < 0.30f) 
			{
				Playerhealthbarcolor.GetComponent<Image> ().color = new Color(255, 0, 0);
			}
		}
		else
		{
			if (HeartLife < HeartLifeCompare) 
			{
				if(HeartLife==0)
				{
					Debug.Log ("blue called");
					Playerhealthbarcolor.GetComponent<Image> ().color = new Color(0, 0, 255);
					PlayerhealthBarSlider.value =1.0f;  //reduce health
					HeartLife= HeartLife + 1;
				}
				else
				{
					Debug.Log ("yellow called");
					Playerhealthbarcolor.GetComponent<Image> ().color = new Color(255, 255, 0);
					PlayerhealthBarSlider.value =1.0f;  //reduce health
					HeartLife= HeartLife + 1;
				}

//				GameObject TempPlayerObject = GameObject.Find ("Heli_PREFAB");
//				GameObject TempBulletSpawnerObject = GameObject.Find ("Bullet_Spaner");

//				Destroy(TempPlayerObject);
//				Destroy(TempBulletSpawnerObject);

//				PlayerPrefab.SetActive (false);
//				BulletSpawnerPrefab.SetActive (false);

//				BulletSpawnerPrefab.transform.position = PlayerSpawnPostion;
//				StartCoroutine (SpawnPlayer ());

			}
			else
			{	
				StartCoroutine (GameOver ());
//				HeartLife = 0;
//				Debug.Log ("life is 0 ");
//				Time.timeScale = 0f;
//				AudioListener.volume = 0f;
//				GameOverPanel.SetActive (true);

//				healthBarSlider.value -=.1f;  //reduce health
//				isGameOver = true;    //set game over to true
//				gameOverText.enabled = true; //enable GameOver text
			}
		}
	}

	public IEnumerator GameOver()
	{
		yield return new WaitForSeconds (2.0f);
		HeartLife = 0;
		Debug.Log ("life is 0 ");
		Time.timeScale = 0f;
		AudioListener.volume = 0f;
		GameOverPanel.SetActive (true);
	}

	public void gamewincoroutine()
	{
		StartCoroutine(GameWin ());

	}
	IEnumerator GameWin()
	{
		Debug.Log ("game win called.!");
		GameObject	boss = GameObject.FindGameObjectWithTag ("Enemy");
		Destroy (boss);
		yield return new WaitForSeconds(2.0f);
		HeartLife = 0;
		Debug.Log ("life is 0");
		Time.timeScale = 0f;
		AudioListener.volume = 0f;
		WinPanel.SetActive (true);
	}

	//FOR COUNTING 1 SCORE MY FUNCTION
	public void SetScoreCountText ()
	{
		Debug.Log ("SCORE COUNT");
		ScoreCount = ScoreCount + 1;
		ScoreText.text = ScoreCount.ToString ();
	}

	// FOR BONUS COUNTING MY FUNCTION
	public void BonusScore ()
	{
		Debug.Log ("BONUS SCORE");
		ScoreCount = ScoreCount + 5;
		ScoreText.text = ScoreCount.ToString ();
	}

	// FOR BONUS DECRIMENT MY FUNCTION
	public void ScoreDecriment ()
	{
		Debug.Log ("SCORE DECRIMENT");
		ScoreCount = ScoreCount - 5;
		ScoreText.text = ScoreCount.ToString ();
	}

	//MY FUNCTION
	public void PauseGameplay()
	{
//		Debug.Log ("game is paused ");
//		Time.timeScale = 0f;
//		AudioListener.volume = 0f;
//		GameOverPanel.SetActive (true);
	}

	public void ShootConvert()
	{
		GameObject PlayerController = GameObject.FindGameObjectWithTag ("Player");
		if (PlayerController != null)
		{
			Debug.Log (" find 'Done_PlayerController' script");
			done_playercontroller = PlayerController.GetComponent <Done_PlayerController>();
		}
		if (done_playercontroller == null)
		{
			Debug.Log ("Cannot find 'Done_PlayerController' script");
		}

		done_playercontroller.ShootConverter = !done_playercontroller.ShootConverter;
	}	

	public void FireRocket()
	{
//		nextFire = Time.time + fireRate;
//		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

		if (rocketcounter <= 0) 
		{
			return;
		}
		else
		{
			if(Time.time > nextFire)
			{
//					WeaponLauncher weaponlancher = new WeaponLauncher ();					
//					weaponlancher.MyShoot();

//					Instantiate(weaponlancher.Missile, RocketSpawn1.position, RocketSpawn1.rotation);
//
//					Instantiate(weaponlancher.Missile, PlayerSpawnPostion, Quaternion.identity);
					
					Done_PlayerController done_playercontroller = new Done_PlayerController();
					GameObject PlayerController = GameObject.FindGameObjectWithTag ("Player");
					if (PlayerController != null)
					{
						Debug.Log (" find 'Done_PlayerController' script");

						done_playercontroller = PlayerController.GetComponent <Done_PlayerController>();
					}
					if (done_playercontroller == null)
					{
						Debug.Log ("Cannot find 'GameController' script");
					} 
					Debug.Log ("rocket spawned");
					Instantiate(Rocketshot,done_playercontroller.RocketSpawn1.position,done_playercontroller.RocketSpawn1.rotation);

					rocketcounter = rocketcounter - 1;
					RocketText.text = rocketcounter.ToString ();
					nextFire = Time.time + fireRate;
			}
		}
		GetComponent<AudioSource>().Play ();
	}

	public void TapToContinue()
	{	
		AudioListener.volume = 1f;
		Time.timeScale = 1f;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (0);
	}
}