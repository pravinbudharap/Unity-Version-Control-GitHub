using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Image>().canvasRenderer.SetAlpha( 0.0f );
//		image.CrossFadeAlpha( 1.0f, duration, false );

	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Image> ().CrossFadeAlpha (1.0f,1f, false);
	}

}
