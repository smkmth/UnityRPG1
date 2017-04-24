using System.Collections;
using UnityEngine;
using System;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Yarn.Unity;

public class GameControl : MonoBehaviour {

	public static GameControl Instance;

	public PlayerStatistics savedPlayerData = new PlayerStatistics ();

	public PlayerStatistics LocalCopyOfData;

	public bool isSceneBeingLoaded = false;

	public UIManager UI;
	public GameObject Canvas;
	//copy player object if we need it world wide
	public GameObject Player;





	void Start()
	{
		Canvas.gameObject.SetActive (false);
//		if (GameControl.Instance.isSceneBeingLoaded) {
//			PlayerState.Instance.localPlayerData = GameControl.Instance.LocalCopyOfData;
//
//			transform.position = new Vector3 (
//				GameControl.Instance.LocalCopyOfData.PositionX,
//				GameControl.Instance.LocalCopyOfData.PositionY,
//				GameControl.Instance.LocalCopyOfData.PositionZ + 0.1f);
//
//			GameControl.Instance.isSceneBeingLoaded = false;
//		}
	}
	// Use this for initialization
	void Awake () {
		//semisingleton to make sure only one gameobject is 
		//controlling 
		if(Instance == null){
			DontDestroyOnLoad(gameObject);
			Instance = this;
			}
		else if (Instance != this){
			Destroy(gameObject);
			}
		Debug.Log ("GameControl started");
		
	}


	
	public void Save()
	{
		Debug.Log ("SavingGame");
		if (!Directory.Exists ("Saves"))
			Directory.CreateDirectory ("Saves");
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream saveFile = File.Create ("Saves/save.giz");
		LocalCopyOfData = PlayerState.Instance.localPlayerData;
		formatter.Serialize (saveFile, LocalCopyOfData);
		saveFile.Close ();


		
	}

	public void Load()
	{
		Debug.Log ("Loading Game");
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream saveFile = File.Open ("Saves/save.giz", FileMode.Open);
		LocalCopyOfData = (PlayerStatistics)formatter.Deserialize (saveFile);
		saveFile.Close ();
			



	}


//	[Serializable]
//	class PlayerData
//	{
//		public float health;
//		public float experience; 
//	}

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
