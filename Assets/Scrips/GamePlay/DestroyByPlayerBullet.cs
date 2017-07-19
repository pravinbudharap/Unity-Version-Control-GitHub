using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPlayerBullet : MonoBehaviour {


	public GameObject explosion, CannonEnemy;
	public GameObject playerExplosion;

	private Done_GameController gameController;
	private CameraShake camerashake;

	private int explotioncounter =1;

	private Done_DestroyByContact done_destroyeController;


	// Use this for initialization
	void Start () {
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		GameObject CameraGameObject = GameObject.FindGameObjectWithTag ("MainCamera");

		GameObject DoneDestroyerObject = GameObject.FindGameObjectWithTag ("Enemy");

		if (gameControllerObject != null || CameraGameObject != null)
		{
			camerashake = CameraGameObject.GetComponent<CameraShake> ();
			gameController = gameControllerObject.GetComponent <Done_GameController>();
			done_destroyeController = DoneDestroyerObject.GetComponent <Done_DestroyByContact>();
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


//	void OnTriggerEnter (Collider other)
//	{
//		Debug.Log ("trigger called");
//
//		if (other.tag == "PlayerBullert")
//				{
//					Debug.Log ("explosion");
//		
//					Instantiate(explosion, transform.position, transform.rotation);
//					Destroy (other.gameObject);
//		
//					gameController.SetScoreCountText ();
//
////					done_destroyeController.SetScoreCountText ();
//
//					if (explotioncounter >= 10) 
//					{
//						Debug.Log ("explotion counter called");
//						Destroy (CannonEnemy);
//						Destroy (other.gameObject);
//						explotioncounter = 1;
//					}
//					explotioncounter++;
//				}
//		if (other.tag == "Player")
//		{
//			Debug.Log ("Player");
//
//			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
//
//			//			gameController.LifeDecriment ();
//
//			gameController.PlayerHealthDecriment ();
//
//			gameController.ScoreDecriment ();
//			Destroy (CannonEnemy);
//
//			camerashake.shakecamera();
//
//			if (gameController.LifeCount == done_destroyeController.LifeCounter ) {
//
//				Debug.Log ("LifeCounter is 0");
//
//				Destroy (CannonEnemy);
//
//				Destroy (other.gameObject);
//
//				//				gameController.LifeDecriment ();
//
//				gameController.PlayerHealthDecriment ();
//
//			}
//			//			gameController.GameOver();
//
//		}
//	}
}
