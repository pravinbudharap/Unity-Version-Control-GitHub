using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_DestroyByEnemyBullet : MonoBehaviour {


	public GameObject explosion;
	public GameObject playerExplosion;
	private Done_GameController gameController;
	private CameraShake camerashake;
	public int LifeCounter =0,explotioncounter =1;

	// Use this for initialization
	void Start () {


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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{
//		Debug.Log ("Done_DestroyByEnemyBullet trigger called");

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyBoundary")
		{
			return;
		}

		if (explosion != null && other.tag == "EnemyBullet")
		{
			Debug.Log ("Done_DestroyByEnemyBullet trigger called");

			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

//			gameController.LifeDecriment ();

			gameController.PlayerHealthDecriment ();

			gameController.ScoreDecriment ();

			Destroy (other.gameObject);

			camerashake.shakecamera();

			if (gameController.LifeCount == LifeCounter) {

				Debug.Log ("LifeCounter is 0");

				Destroy (gameObject);

				Destroy (other.gameObject);

				gameController.PlayerHealthDecriment ();
		
			}
		}
	}
}
