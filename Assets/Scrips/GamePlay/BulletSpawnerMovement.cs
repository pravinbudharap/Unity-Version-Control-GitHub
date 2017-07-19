using UnityEngine;
using System.Collections;
using CnControls;
using UnityEngine.UI;

[System.Serializable]
public class Movement_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class BulletSpawnerMovement : MonoBehaviour {

	public float speed;
	public Movement_Boundary boundary;

	void FixedUpdate ()
	{

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
	}

}

