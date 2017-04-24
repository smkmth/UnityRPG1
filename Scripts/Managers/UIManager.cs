using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public GameControl GM;
	public MusicManager MM;

	private Slider _musicSlider;

	void Start(){
		_musicSlider = GameObject.Find ("Music_Slider").GetComponent<Slider> ();

	}
	void Update()
	{
		ScanForKeyStroke ();
	}

	void ScanForKeyStroke(){
		if (Input.GetKeyDown ("escape"))
			GM.TogglePauseMenu ();
		
	}

//	public void OptionSliderUpdate(float val) {}
//	void SetCustomSettings(bool val){}
//	void WriteSettingsToInputText(GameSettings settings){}

	public void MusicSliderUpdate(float val){
		MM.SetVolume (val);
			}

			
			

}

