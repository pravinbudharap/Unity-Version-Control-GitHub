using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaEntvirment : MonoBehaviour {

	public int speed;
	public Rigidbody envirment1,envirment2;
	Vector3 position = new Vector3(0, 0, 95);

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnentvirment ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnentvirment()
	{

		Rigidbody envirmentwithforce = (Rigidbody) Instantiate(envirment1, transform.position, transform.rotation);
		envirmentwithforce.transform.position = position;
		envirmentwithforce.velocity = transform.forward * speed;
		yield return new WaitForSeconds (20);
		Destroy (envirmentwithforce.gameObject);
		StartCoroutine (spawnentvirmentsecond ());
	}
	IEnumerator spawnentvirmentsecond()
	{

		Rigidbody envirmentwithforce = (Rigidbody) Instantiate(envirment2, transform.position, transform.rotation);
		envirmentwithforce.transform.position = position;
		envirmentwithforce.velocity = transform.forward * speed;
		yield return new WaitForSeconds (20);
		Destroy (envirmentwithforce.gameObject);
		StartCoroutine (spawnentvirment ());
	}
}
