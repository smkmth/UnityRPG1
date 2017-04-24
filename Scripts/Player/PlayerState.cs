using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
	
	 
	public static PlayerState Instance;
	public PlayerStatistics localPlayerData = new PlayerStatistics();
	public Transform playerPosition;


	void Awake()
	{
		if (Instance == null)
			Instance = this;

		if (Instance != this)
			Destroy(gameObject);

		GameControl.Instance.Player = gameObject;
	}


	void Start (){
		localPlayerData = GameControl.Instance.savedPlayerData;


	}

	public void Update()
	{
		//GameControl.Instance.savedPlayerData = localPlayerData;

	}
}
