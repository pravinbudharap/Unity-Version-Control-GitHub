using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

[System.Serializable]
public class My_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}
public class MyPlayerController : MonoBehaviour {

	public int speed;
	public float tilt;
	public My_Boundary boundary;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		float MoveHorizontal = CnInputManager.GetAxis ("Horizontal");
		float MoveVertical = CnInputManager.GetAxis ("Vertical");
			
		Vector3 movement = new Vector3 (MoveHorizontal, 0.0f, MoveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		Debug.Log (movement);
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * tilt);

	}
}
