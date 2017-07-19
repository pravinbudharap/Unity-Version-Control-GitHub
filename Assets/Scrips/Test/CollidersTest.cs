using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
//		Destroy(this.gameObject);
		Debug.Log ("Enter");
	}
	void OnTriggerStay(Collider other)
	{
//		Destroy(this.gameObject);
		Debug.Log ("Stay");
	}
	void OnTriggerExit(Collider other)
	{
//		Destroy(this.gameObject);
		Debug.Log ("Exit");
	}
}