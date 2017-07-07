using UnityEngine;
using System.Collections;
using LitJson;
using System;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;


public class DecodeJson : MonoBehaviour {

	//private int JsonHolederint
	private string JsonString;
	private JsonData ItemData;
	private string FirstJson,SeconJson;
	public Text JsonText1, JsonText2;
//	public string url = "http://freelyonlinegames.com/mobilegames/ReadJson.json";
	public string url = "https://junior-photos.000webhostapp.com/JSON_FILES/Test.json";

	IEnumerator Start()
	{
		//JsonString = File.ReadAllText (Application.dataPath + "/MyTest/ReadJson.json");

		WWW www = new WWW(url);
		yield return www;
		JsonString = www.text;
		ItemData = JsonMapper.ToObject (JsonString);
	
//		JsonHolder = ItemData["IntertialFrequency"].ToString();

		FirstJson = ItemData["test1"].ToString();
		SeconJson = ItemData["test2"].ToString();

		Debug.Log (JsonString);
		JsonText1.text = FirstJson;
		JsonText2.text = SeconJson;

	}

}






//	public int interstitialFrequency = 3;
//
//	public class parseJSON
//	{
//		public string title;
//		public string id;
//		public ArrayList but_title;
//		public ArrayList but_image;
//	}
//	// Sample JSON for the following script has attached.
//	IEnumerator Start()
//	{
//		string url = "/Users/rajanbhadre/UNITY_PROJECTS/Json_Example/Assets/ReadJson.json";
//		WWW www = new WWW(url);
//		yield return www;
//		if (www.error == null)
//		{
//			Processjson(www.data);
//		}
//		else
//		{
//			Debug.Log (www);
//
//			Debug.Log("ERROR: " + www.error);
//		}        
//	}    
//	private void Processjson(string jsonString)
//	{
//		JsonData jsonvale = JsonMapper.ToObject(jsonString);
//		parseJSON parsejson;
//		parsejson = new parseJSON();
//		parsejson.title = jsonvale["title"].ToString();
//		parsejson.id = jsonvale["ID"].ToString();
//
//		parsejson.but_title = new ArrayList ();
//		parsejson.but_image = new ArrayList ();
//
//		for(int i = 0; i<jsonvale["buttons"].Count; i++)
//		{
//			parsejson.but_title.Add(jsonvale["buttons"][i]["title"].ToString());
//			Debug.Log (parsejson.but_title);
//			//parsejson.but_image.Add(jsonvale["buttons"][i]["image"].ToString());
//		}    
//	}







	// Sample JSON for the following script has attached.
//	IEnumerator Start()
//	{
//
//		string url = "/Users/rajanbhadre/UNITY_PROJECTS/Json_Example/Assets/ReadJson.json";
//
//		WWW www = new WWW ("/Users/rajanbhadre/UNITY_PROJECTS/Json_Example/Assets/ReadJson.json");
//		//WWW www = new WWW ("http://freelyonlinegames.com/mobilegames/ReadJson.json");
//
//
//		yield return www;
//		string jsondata = www.ToString ();
//
//		level = JsonUtility.FromJson<string> (url);
//		Debug.Log (level ); //displays Convert to String
//		 level object now contains JSON string values
//
//		WWW www = new WWW(url);
//		yield return www;
//
//		Debug.Log(jsondata);
//		string jd = JSON.Parse (www.text);
//		Debug.Log (jd);
//
//		parseJSON parsejson;
//		parsejson = new parseJSON();
//		parsejson.title = jsondata ["buttons"] ["title"];
//		Debug.Log (parsejson.title); 
//		string  jd = JSON.Parse(www.text);
//
//		if (www.error == null)
//		{
//			interstitialFrequency = jd ["buttons"] ["title"];
//
//			Debug.Log (interstitialFrequency);
//			Processjson(www.data);
//		}
//		else
//		{
//			Debug.Log("ERROR: " + www.error);
//		}        
//	}







//	private string mystring= null; 
//
//	public class ExampleSerializedClass {
//
//		// Value Types
//
//		public int myInt = 42;
//		public string myString = "The quick brown fox jumped over the lazy dog.";
//		public float myFloat = 3.14159f;
//		public bool myBool = false;
//
//		[JsonIgnore]
//		public Transform myIgnoredTransform; // This object will be ignored by the json engine.
//
//		public ExampleSerializedClass(){ }
//
//	}

//	void Start ()
//	{
//
//		ExampleSerializedClass serializedClass = new ExampleSerializedClass();
//
//		JsonWriter writer = new JsonWriter();
//		writer.PrettyPrint = true;
//
//		JsonMapper.ToJson(serializedClass, writer);
//
//		string jsonfile = writer.ToString();
//
//		Debug.Log(jsonfile);
//	
//
//		//If you don't need a JsonWriter, use this.
//		//string json = JsonMapper.ToJson(exampleClass);
//
//		ExampleSerializedClass deserializedClass = JsonMapper.ToObject<ExampleSerializedClass>(savedJsonString);
//
//		Debug.Log(deserializedClass.myString);
//	
//		WWW www = new WWW ("/Users/rajanbhadre/UNITY_PROJECTS/Json_Example/Assets/ReadJson.json");
//		yield return www;
//
//		string jsondata = www.ToString ();
//		 
//		JsonData deserializedClass = JsonMapper.ToObject<JsonData>(jsondata);
//
//		parsejson.title = jsonvale["title"].ToString();
//
//		serializedClass.myString = deserializedClass ["title"].ToString ();
//
//		Debug.Log(serializedClass.myString);
//
//	}
