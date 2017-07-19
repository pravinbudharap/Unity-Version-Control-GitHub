using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {


//	public Animation animation;
	public bool animation_bool;

	void Update()
	{
		if(animation_bool == true)
		{
//			animation.Play("slash");
		}
		if(Input.GetKeyDown(KeyCode.Z))
		{
			animation_bool = true;
		}

	}

//	public void animate()
//	{
//		animation.Play ("rotate");
//	}

}
