using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateTest : MonoBehaviour {


	public GameObject InstatiatePlane;
	[HideInInspector]
	public GameObject plane1,plane2,plane3;
//	public int speed;
	Vector3 position1 = new Vector3(0, 0, 20);
	Vector3 position2 = new Vector3(0, 0, 55);

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn1 ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator Spawn1()
	{	
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
