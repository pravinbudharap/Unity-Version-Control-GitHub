using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_DestroyByContact : MonoBehaviour
{  
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject CannonEnemy;
	public int scoreValue;
	private Done_GameController gameController;
	private CameraShake camerashake;
	[HideInInspector]
	public int LifeCounter =0,explotioncounter =1;


	public Slider EnemyhealthBarSlider;
	public GameObject Enemyhealthbarcolor;


	void Start ()
	{
//		count = 0;

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
			
//		GameObject[] astroids = GameObject.FindGameObjectsWithTag ("Enemy");
//		foreach(GameObject astroid in astroids)
//		{
//			EnemyhealthBarSlider = astroid.GetComponentInChildren<Slider> ();
//		}
	}

	void Update()
	{
		
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

//			gameController.EnemyHealthDecriment ();
			gameController.SetScoreCountText ();

			EnemyHealthDecriment ();

			if (explotioncounter >= 5) 
			{
				Debug.Log ("explotion counter called");
				Destroy (gameObject);
				Destroy (other.gameObject);
				gameController.BonusScore ();
				explotioncounter = 1;
			}

			explotioncounter++;
		}

		if (other.tag == "Rocket") 
		{
			Instantiate(explosion, transform.position, transform.rotation);
			gameController.BonusScore ();
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if (other.tag == "Player")
		{
			Debug.Log ("Player");

			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

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

			Destroy (gameObject);

			camerashake.shakecamera();

			if (gameController.LifeCount == LifeCounter) {

				Debug.Log ("LifeCounter is 0");

				Destroy (gameObject);

				Destroy (other.gameObject);

//				gameController.LifeDecriment ();

				gameController.PlayerHealthDecriment ();

			}
//			gameController.GameOver();

		}

//		gameController.AddScore(scoreValue);
//		Destroy (other.gameObject);
//		Destroy (gameObject);
	}

	//ENEMY MY FUNCTION
	public void EnemyHealthDecriment()
	{

		//if player triggers fire object and health is greater than 0
		if(EnemyhealthBarSlider.value > 0.2f)
		{
			EnemyhealthBarSlider.value -=.2f;  //reduce health
			if (EnemyhealthBarSlider.value< 0.40f) 
			{
				Enemyhealthbarcolor.GetComponent<Image> ().color = new Color(255, 0, 0);
			}
		}
		else
		{
			return;
			Debug.Log ("life is 0 ");
		}
	}

}