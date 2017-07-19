using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthProgressTest : MonoBehaviour {



	public Slider healthBarSlider;  //reference for slider
	public Text gameOverText;   //reference for text
	private bool isGameOver = false, movementon= false; //flag to see if game is over
	public GameObject healthbarcolor, fireobject;

	void Start(){
		gameOverText.enabled = false; //disable GameOver text on start
	}

	// Update is called once per frame
	void Update () 
	{
		//check if game is over i.e., health is greater than 0
		if(!isGameOver)
		transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10f, 0, 0); //get input
		transform.Translate(Input.acceleration.x * Time.deltaTime*10f ,0 , 0);
	}

	//Check if player enters/stays on the fire
	void OnTriggerEnter(Collider other)
	{
		//if player triggers fire object and health is greater than 0
		if(other.gameObject.name=="Fire" && healthBarSlider.value>0.1f)
		{
			healthBarSlider.value -=.1f;  //reduce health
			if (healthBarSlider.value < 0.30f) 
			{
				healthbarcolor.GetComponent<Image> ().color = new Color(255, 0, 0);
			}
		}
		else{
			healthBarSlider.value -=.1f;  //reduce health
			isGameOver = true;    //set game over to true
			gameOverText.enabled = true; //enable GameOver text
		}
	}
		
}
