using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFindTest : MonoBehaviour {

	public GameObject cube;
	// Use this for initialization
	void Start () 
	{
		Vector3 othercube = cube.GetComponent<Renderer> ().bounds.size;
		Debug.Log (othercube);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
