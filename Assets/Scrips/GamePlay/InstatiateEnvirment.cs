using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateEnvirment : MonoBehaviour {


	public GameObject InstatiatePlane;
	[HideInInspector]
	public GameObject plane1,plane2,plane3;
	//	public int speed;
	Vector3 position1 = new Vector3(0, -1.0f, 25);
	Vector3 position2 = new Vector3(0, -1.0f, 60);

	void Awake()
	{
		Time.timeScale = 0f;
		AudioListener.volume = 0f;

	}

	void OnEnabled()
	{
		Time.timeScale = 0f;
		AudioListener.volume = 0f;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn1 ());
	}

	// Update is called once per frame
	void Update () {

	}


	IEnumerator Spawn1()
	{	
		Debug.Log ("first spawn");

		plane1 = (GameObject) Instantiate(InstatiatePlane, transform.position, transform.rotation);
		plane1.transform.position = position1;
		//		plane1.velocity = transform.forward * speed;

		//		yield return new WaitForSeconds (6.95f); // speed for 4

		yield return new WaitForSeconds (13.9f); // speed for 2

		//		Destroy (plane2);
		StartCoroutine (Spawn2());

	}

	IEnumerator Spawn2()
	{
		Debug.Log ("second spawn");

		plane2 = (GameObject) Instantiate(InstatiatePlane, transform.position, transform.rotation);
		plane2.transform.position = position2;

		//		yield return new WaitForSeconds (10f);
		//		Destroy (plane1);
		//		plane2.velocity = transform.forward * speed;
		//		yield return new WaitForSeconds (15.7f);  // speed for 4

		yield return new WaitForSeconds (24.45f); // speed for 2

		StartCoroutine (Spawn3());
	}

	IEnumerator Spawn3()
	{
		Debug.Log ("third spawn");
		plane3 = (GameObject) Instantiate(InstatiatePlane, transform.position, transform.rotation);
		plane3.transform.position = position2;

		//		yield return new WaitForSeconds (10f);
		//		Destroy (plane2);
		//		plane2.velocity = transform.forward * speed;
		//		yield return new WaitForSeconds (15.7f);  // speed for 4

		yield return new WaitForSeconds (24.45f); // speed for 2

		StartCoroutine (Spawn2());
	}

}
