using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Done_BossContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject BossExplosion;
	public GameObject CannonEnemy;
	public int scoreValue;

	[HideInInspector]
	public int LifeCounter =0,explotioncounter =1;

	public Slider BosshealthBarSlider;
	public GameObject Bosshealthbarcolor;
	[HideInInspector]
	public int HeartLife = 0, HeartLifeCompare=2; 


	private Done_GameController gameController;
	private CameraShake camerashake;
	private Done_PlayerController doneplayercontroller;
	private Done_WeaponController doneweaponcontroller;

	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawn2, shotSpawn3, shotSpawn4;
	public float fireRate;
	public float delay;
	[HideInInspector]
	public bool enemybulletbool= true, canshoot = true;

	void Start ()
	{
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		GameObject CameraGameObject = GameObject.FindGameObjectWithTag ("MainCamera");
//		GameObject WeaponGameObject = GameObject.FindGameObjectWithTag ("Enemy");
//		GameObject PlayerGameObject = GameObject.FindGameObjectWithTag ("Player");


		doneplayercontroller = gameObject.GetComponent<Done_PlayerController> ();
		doneweaponcontroller = gameObject.GetComponent<Done_WeaponController> ();

		if (gameControllerObject != null || CameraGameObject != null) 
		{
			camerashake = CameraGameObject.GetComponent<CameraShake> ();
			gameController = gameControllerObject.GetComponent <Done_GameController> ();
//			doneplayercontroller = PlayerGameObject.GetComponent<Done_PlayerController> ();
//			doneweaponcontroller = WeaponGameObject.GetComponent<Done_WeaponController> ();
		}
		if (gameController == null || camerashake == null) 
		{
			Debug.Log ("Cannot find 'camerashake' script");
			Debug.Log ("Cannot find 'GameController' script");
		}

		if (enemybulletbool) 
		{
			InvokeRepeating ("Fire", delay, fireRate);
		}
	}
		
	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
		Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
		Instantiate(shot, shotSpawn4.position, shotSpawn4.rotation);
		GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter (Collider other)
	{
		//		Debug.Log ("trigger called");

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyBoundary")
		{
			return;
		}

		if (explosion != null && other.tag == "PlayerBullert")
		{
			Debug.Log ("player explosion");

			Instantiate(explosion, transform.position, transform.rotation);

			Destroy (other.gameObject);

			gameController.SetScoreCountText ();

			BossHealthDecriment ();

//			if (explotioncounter >= 5) 
//			{
//				Debug.Log ("explotion counter called");
//				Destroy (gameObject);
//				Destroy (other.gameObject);
//				gameController.BonusScore ();
//				explotioncounter = 1;
//			}
//			explotioncounter++;

		}

		if (other.tag == "Rocket") 
		{
			Instantiate(explosion, transform.position, transform.rotation);
			gameController.BonusScore ();
			BossHealthDecriment ();
//			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if (other.tag == "Player")
		{
			Debug.Log ("Player");

			Instantiate(BossExplosion, other.transform.position, other.transform.rotation);

			//			gameController.LifeDecriment ();

			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			GameObject CameraGameObject = GameObject.FindGameObjectWithTag ("MainCamera");
			if (gameControllerObject != null || CameraGameObject != null)
			{
				camerashake = CameraGameObject.GetComponent<CameraShake> ();
				gameController = gameControllerObject.GetComponent <Done_GameController>();
			}
			if (gameController == null || camerashake == null)
			{
				Debug.Log ("Cannot find 'camerashake' script");
				Debug.Log ("Cannot find 'GameController' script");
			}

			gameController.PlayerHealthDecriment ();

			gameController.ScoreDecriment ();

			camerashake.shakecamera();

			if (gameController.LifeCount == LifeCounter) {

				Debug.Log ("LifeCounter is 0");

				Destroy (gameObject);

				Destroy (other.gameObject);

				gameController.PlayerHealthDecriment ();
			}
		}
	}

	//ENEMY MY FUNCTION
	public void BossHealthDecriment()
	{
		//if player triggers fire object and health is greater than 0
		if(BosshealthBarSlider.value>0.1f)
		{
			Debug.Log ("Boss health decrease");
			BosshealthBarSlider.value -=.01f;  //reduce health
			if (BosshealthBarSlider.value < 0.30f) 
			{
				Bosshealthbarcolor.GetComponent<Image> ().color = new Color(255, 0, 0);
			}
		}
		else
		{
			if (HeartLife < HeartLifeCompare) 
			{
				if(HeartLife==0)
				{
					Debug.Log ("blue called");
					Bosshealthbarcolor.GetComponent<Image> ().color = new Color(0, 0, 255);
					BosshealthBarSlider.value =1.0f;  //reduce health
					HeartLife= HeartLife + 1;
				}
				else
				{
					Debug.Log ("yellow called");
					Bosshealthbarcolor.GetComponent<Image> ().color = new Color(255, 255, 0);
					BosshealthBarSlider.value =1.0f;  //reduce health
					HeartLife= HeartLife + 1;
				}
			}
			else
			{	
//				StartCoroutine (gameController.GameWin ());
				StartCoroutine(BossExplostion());
			}
		}
	}

	IEnumerator BossExplostion()
	{
		Debug.Log ("BossExplostion function Called");

//		doneplayercontroller.canshoot = false;
//		doneweaponcontroller.enemybulletbool= false;
		yield return new WaitForSeconds (1.0f);
		Debug.Log ("First boss explotion Called");
		Instantiate(BossExplosion, transform.position, transform.rotation);
		//explotion
		yield return new WaitForSeconds (1.0f);
		Debug.Log ("First boss explotion Called");
		Instantiate (BossExplosion, transform.position, transform.rotation);
		//explotion
		yield return new WaitForSeconds (1.0f);
		Debug.Log ("First boss explotion Called");
		//explotion
		Instantiate(BossExplosion, transform.position, transform.rotation);
//		yield return new WaitForSeconds (1.0f);
//		Debug.Log ("First boss explotion Called");
//		Instantiate(BossExplosion, transform.position, transform.rotation);
		//explotion
//		yield return new WaitForSeconds (1.0f);
//		Debug.Log ("First boss explotion Called");
//		Instantiate(BossExplosion, transform.position, transform.rotation);
//		//explotion
//		yield return new WaitForSeconds (1.0f);
//		Debug.Log ("First boss explotion Called");
//		Instantiate(BossExplosion, transform.position, transform.rotation);
//		//explotion
		yield return new WaitForSeconds (1.0f);
		gameController.gamewincoroutine ();
	}
}
