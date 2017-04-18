using System.Collections;
using UnityEngine;
using System;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public UIManager UI;
	public GameObject Canvas;


	public static float health = 23;
	public static float experience = 50;

	

	public static GameControl control;
	// Use this for initialization
	void Awake () {
		//semisingleton to make sure only one gameobject is 
		//controlling 
		if(control == null){
			DontDestroyOnLoad(gameObject);
			control = this;
			}
		else if (control != this){
			Destroy(gameObject);
			}
		
	}

	void Start() {
		Canvas.gameObject.SetActive (false);

	}

	void OnGUI(){
		GUI.Label(new Rect(40,30,100,30),"Health: "+ health);
		GUI.Label(new Rect(40,40,150,30),"Exp: "+ experience);
	}

	public void Save()
	{
		Debug.Log ("Starttosave");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerData data = new PlayerData();
		data.health = health;
		data.experience = experience;
		bf.Serialize (file, data);
		file.Close();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			health = data.health;
			experience = data.experience;
			file.Close();

		}
	}


	[Serializable]
	class PlayerData
	{
		public float health;
		public float experience; 
	}

	public void TogglePauseMenu(){
//		if (UI.GetComponentInChildren<Canvas> ().enabled) {
//			UI.GetComponentInChildren<Canvas> ().enabled = false;
//			Time.timeScale = 1.0f;
//		} else {
//			UI.GetComponentInChildren<Canvas>().enabled = true;
//			Time.timeScale = 0f;
//		}
		if (Canvas.gameObject.activeSelf) {
			
			Time.timeScale = 1.0f;
			Canvas.gameObject.SetActive (false);
		} else {
			Time.timeScale = 0.0f;
			Canvas.gameObject.SetActive (true);
		}
		Debug.Log ("Gamemanager ::timescale" + Time.timeScale);
	}


}
