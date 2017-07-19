using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class Audio1
{
	public AudioSource[] audio1;
	public float[] Volum1;

	public void GetValueVolum ()
	{
		Volum1 = new float[audio1.Length];
		for (int i = 0; i < audio1.Length; i++) {
			Volum1 [i] = audio1 [i].volume;
		}
	}

	public void MuteAudio (float volum1)
	{
		for (int i = 0; i < audio1.Length; i++) {
			audio1 [i].volume = volum1 * Volum1 [i];
		}
	}
}

public class MusicOnOff : MonoBehaviour {


	public DataGame1 dataGame1;
	public Audio1 listAudio1;
	private bool toggle =true ;

	public GameObject OnimageMusic;
	public GameObject OffimageMusic;

	public AudioSource Clickmusic;


	void Awake()
	{
		//Screen.sleepTimeout = SleepTimeout.NeverSleep;

		string isSetSound1 = PlayerPrefs.GetString ("isSetSound1");
		Debug.Log ("isSetSound1"+isSetSound1);
		if(isSetSound1== "")
		{
			Debug.Log ("isSetSound1 ");

			isSetSound1 = "1";
			PlayerPrefs.SetString ("isSetSound1",isSetSound1);
			PlayerPrefs.SetInt ("sound1",1);
			PlayerPrefs.Save ();
		}

		listAudio1.GetValueVolum ();
		listAudio1.MuteAudio (dataGame1.volum1);
	}

	// Use this for initialization
	void Start ()
	{
		CheckSound1 ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void BottonMusicOn ()
	{
		OffimageMusic.SetActive (true);
		OnimageMusic.SetActive (false);

		//		Clickmusic.Pause ();

		listAudio1.MuteAudio (0);
		dataGame1.volum1 = 0;

		PlayerPrefs.SetInt ("sound1",0);
		PlayerPrefs.Save ();

	}
	public void BottonMusicOff ()
	{
		OffimageMusic.SetActive (false);
		OnimageMusic.SetActive (true);

		//		Clickmusic.Play ();

		dataGame1.volum1 = 1;
		listAudio1.MuteAudio (1);

		PlayerPrefs.SetInt ("sound1",1);
		PlayerPrefs.Save ();

	}

	public void CheckSound1 ()
	{

		Debug.Log ("dataGame1.volum1 "+dataGame1.volum1);
		if (dataGame1.volum1 != 0) 
		{
			Debug.Log ("IF SECTION RUN OF CHECKSOUND");

			OffimageMusic.SetActive (false);
			OnimageMusic.SetActive (true);

			dataGame1.volum1 = 1;
			listAudio1.MuteAudio (1);
			Debug.Log (dataGame1.volum1);



		} 
		else 
		{
			Debug.Log ("ELSE SECTION RUN OF CHECKSOUND");
		

			OffimageMusic.SetActive (true);
			OnimageMusic.SetActive (false);

			listAudio1.MuteAudio (0);
			dataGame1.volum1 = 0;

	

		}
		PlayerPrefs.Save ();
		Debug.Log ("dataGame1.volum1 "+dataGame1.volum1);

		if (PlayerPrefs.GetInt ("sound1") == 1) 
		{
	

			OffimageMusic.SetActive (false);
			OnimageMusic.SetActive (true);

			dataGame1.volum1 = 1;
			listAudio1.MuteAudio (1);

	
		} 
		else 
		{


			OffimageMusic.SetActive (true);
			OnimageMusic.SetActive (false);

			listAudio1.MuteAudio (0);
			dataGame1.volum1 = 0;

		}
	}
}
