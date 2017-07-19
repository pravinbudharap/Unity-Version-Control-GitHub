using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrigger : MonoBehaviour {

	public AILook ailook;
//	private Transform target = null;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log ("callingggggg");
			GameObject aiscript = GameObject.FindGameObjectWithTag ("cannon");		
			ailook = aiscript.GetComponent <AILook> ();
			ailook.enabled = true;
			ailook.target = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("exit calledd");
			ailook.target = null;
			ailook.enabled = false;
		}

	}

	void OnTriggerStay(Collider other) 
	{
		if (other.tag == "Player") 
			Debug.Log ("stay calledd");
		
	}
}
