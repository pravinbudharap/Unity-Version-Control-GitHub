using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RotateFan : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		SceneManager.CreateScene ("pravin");
			}
	
	// Update is called once per frame
	void Update () {
		// Rotate the object around its local X axis at 1 degree per second
		transform.Rotate(Vector3.right * Time.deltaTime);
//		gameObject.transform.Rotate (Vector3.right, 360);

	}
}
