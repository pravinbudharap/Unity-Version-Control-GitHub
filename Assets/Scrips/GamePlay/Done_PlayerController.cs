using UnityEngine;
using System.Collections;
using CnControls;
using UnityEngine.UI;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{

	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	//BULLET VARIABLES
	public GameObject shot;
	public Transform FrontSpawn, LeftSpawn, RightSpawn;
	public Transform RocketSpawn1, RocketSpawn2;


	public bool canshoot = true, ShootConverter = true;

	private Done_GameController gameController;
	private float totaltime = 0 , waittime = 10;

	bool onetime;
	public AudioSource PlayerBulletSound;


	void Awake()
	{
		Time.timeScale = 0f;

	}
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null )
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

	}
	public void Update ()
	{
//		if (Input.GetButton("Fire1") && Time.time > nextFire) 
//		{
//			nextFire = Time.time + fireRate;
//			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
//			GetComponent<AudioSource>().Play ();
//		}

		if(canshoot == true)
		{
			if (ShootConverter && Time.time > totaltime)
			{
				Debug.Log ("one shoot called");
				Instantiate (shot, FrontSpawn.position, FrontSpawn.rotation);
				PlayerBulletSound.Play ();

			}
			else 
			{
				Instantiate (shot, FrontSpawn.position, FrontSpawn.rotation);

				Instantiate (shot, LeftSpawn.position, LeftSpawn.rotation);

				Instantiate (shot, RightSpawn.position, RightSpawn.rotation);

				PlayerBulletSound.Play ();
			}

//			Instantiate(shot, shotSpawnRocket.position, shotSpawnRocket.rotation);
	
			//InRange scripts
			//Shot scripts
//			gameController.nextFire = Time.time + gameController.fireRate;
//			GetComponent<AudioSource>().Play ();

			canshoot = false;
			StartCoroutine(Reload());
		}

		Debug.Log (totaltime);

		if (Time.time < totaltime && onetime) 
		{
			Debug.Log ("total time shootconverter called");
			ShootConverter = !ShootConverter;
			onetime = false;

		}
		if (Time.time > totaltime && onetime) {
			ShootConverter = !ShootConverter;
			Debug.Log ("one time called");
			onetime = false;
		}
	}

	IEnumerator Reload()
	{
		yield return new WaitForSeconds(0.2f);
		canshoot = true;
	}

	void FixedUpdate ()
	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");

//		nextFire = Time.time + fireRate;
//		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
//		GetComponent<AudioSource>().Play (); 

		float moveHorizontal = CnInputManager.GetAxis ("Horizontal");
		float moveVertical = CnInputManager.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
//		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

		//MY FUNCTION
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (GetComponent<Rigidbody>().velocity.z * tilt, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "OneToThreeSpawner") {

			Destroy (other.gameObject);
			ShootConverter = !ShootConverter;
			totaltime = Time.time + waittime;
			onetime = true;
		}

		if (other.tag == "ThreeToOneSpawner") {

			Destroy (other.gameObject);
			ShootConverter = !ShootConverter;
			onetime = true;
		}
		if (other.tag == "Health") {
			
			Debug.Log ("Health is Fillleeddd.!!");
			Destroy (other.gameObject);
			gameController.PlayerhealthBarSlider.value =1.0f;  //reduce health
		}

	}

	public void stopcoverter()
	{
			Debug.Log ("total time shootconverter called");
			ShootConverter = !ShootConverter;
	}

}
