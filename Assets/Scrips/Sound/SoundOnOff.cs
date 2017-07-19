using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;


[System.Serializable]
public class Audio
{
	public AudioSource[] audio;
	public float[] Volum;

	public void GetValueVolum ()
	{
		Volum = new float[audio.Length];
		for (int i = 0; i < audio.Length; i++) {
			Volum [i] = audio [i].volume;
		}
	}

	public void MuteAudio (float volum)
	{
		for (int i = 0; i < audio.Length; i++) {
			audio [i].volume = volum * Volum [i];
		}
	}
}

public class SoundOnOff : MonoBehaviour {

	public DataGame dataGame;
    public Audio listAudio;
	private bool toggle =true ;
	public GameObject OnimageSound;
	public GameObject OffimageSound;


	public AudioSource backgroundmusic1;
	public AudioSource backgroundmusic2;

	//JSON VARIABLES
	private static int counter = 0;
	private string JsonString;
	private JsonData ItemData;
	private string JsonSoundHolder;
	private float SoundValueToInt;

	private string url = "https://junior-photos.000webhostapp.com/JSON_FILES/Cricketgame.json";

	void Awake()
	{
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

		string isSetSound = PlayerPrefs.GetString ("isSetSound");
		Debug.Log ("isSetSound"+isSetSound);
		if(isSetSound == "")
        {
			Debug.Log ("isSetSound 1");

			isSetSound = "1";
			PlayerPrefs.SetString ("isSetSound",isSetSound);
			PlayerPrefs.SetInt ("sound",1);
			PlayerPrefs.Save ();
		}
        
		listAudio.GetValueVolum ();
		listAudio.MuteAudio (dataGame.volum);
	}

	// Use this for initialization
	IEnumerator Start () 
	{
        CheckSound ();
		WWW www = new WWW(url);
		yield return www;
		JsonString = www.text;
		ItemData = JsonMapper.ToObject (JsonString);
			
		Debug.Log (JsonString);

		JsonSoundHolder = ItemData["BackgroundSound"].ToString();
		//Debug.Log (ItemData["title"]);


		SoundValueToInt = float.Parse(JsonSoundHolder);
		Debug.Log (SoundValueToInt);
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void BottonSoundOn ()
	{
		OffimageSound.SetActive (true);
		OnimageSound.SetActive (false);
		listAudio.MuteAudio (0);
		dataGame.volum = 0;

		PlayerPrefs.SetInt ("sound",0);
		PlayerPrefs.Save ();

	}

	public void BottonSoundOff ()
	{
		OffimageSound.SetActive (false);
		OnimageSound.SetActive (true);
		dataGame.volum = 1;
		listAudio.MuteAudio (1);

		PlayerPrefs.SetInt ("sound",1);
		PlayerPrefs.Save ();

	}
		
    public void CheckSound ()
	{																
		Debug.Log ("dataGame.volum"+dataGame.volum);
		if (dataGame.volum != 0) 
		{
			Debug.Log ("IF SECTION RUN OF CHECKSOUND");
			OffimageSound.SetActive (false);
			OnimageSound.SetActive (true);


			dataGame.volum = 1;
			listAudio.MuteAudio (1);
			Debug.Log (dataGame.volum);

				if (counter == SoundValueToInt)
				{
					backgroundmusic1.Play ();
					Debug.Log ("first backgroud play");
				} 
				else 
				{
					backgroundmusic2.Play ();
					Debug.Log ("second backgroud play");
		
				}


		} 
		else 
		{
			Debug.Log ("ELSE SECTION RUN OF CHECKSOUND");
			OffimageSound.SetActive (true);
			OnimageSound.SetActive (false);

			listAudio.MuteAudio (0);
			dataGame.volum = 0;

			if (counter == SoundValueToInt)
			{
				backgroundmusic1.Play ();
				Debug.Log ("first backgroud play");
			} 
			else 
			{
				backgroundmusic2.Play ();
				Debug.Log ("second backgroud play");

			}

		}
		PlayerPrefs.Save ();
		Debug.Log ("dataGame.volum"+dataGame.volum);

		if (PlayerPrefs.GetInt ("sound") == 1) 
		{
			OffimageSound.SetActive (false);
			OnimageSound.SetActive (true);



			dataGame.volum = 1;
			listAudio.MuteAudio (1);



			if (counter == SoundValueToInt)
			{
				backgroundmusic1.Play ();
				Debug.Log ("first backgroud play");
			} 
			else 
			{
				backgroundmusic2.Play ();
				Debug.Log ("second backgroud play");

			}
		} 
		else 
		{
			OffimageSound.SetActive (true);
			OnimageSound.SetActive (false);


			listAudio.MuteAudio (0);
			dataGame.volum = 0;

;

			if (counter == SoundValueToInt)
			{
				backgroundmusic1.Play ();
				Debug.Log ("first backgroud play");
			} 
			else 
			{
				backgroundmusic2.Play ();
				Debug.Log ("second backgroud play");

			}
		}
	}

}
	