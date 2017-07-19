using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

//	// The position that that camera will be following.
//	public Transform target; 
//	// The speed with which the camera will be following.           
//	public float smoothing = 5f;        
//
//	// The initial offset from the target.
//	Vector3 offset;                     
//
//	void Start ()
//	{
//		// Calculate the initial offset.
//		offset = transform.position - target.position;
//	}
//
//	void FixedUpdate ()
//	{
//		// Create a postion the camera is aiming for based on 
//		// the offset from the target.
//		Vector3 targetCamPos = target.position + offset;
//
//		// Smoothly interpolate between the camera's current 
//		// position and it's target position.
//		transform.position = Vector3.Lerp (transform.position, 
//			targetCamPos,   
//			smoothing * Time.deltaTime);
//	}


	public GameObject stright;

	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - stright.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = transform.position + offset;
	}
}
