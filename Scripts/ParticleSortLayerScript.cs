using UnityEngine;
using System.Collections;

public class ParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		//Change Foreground to the layer you want it to display on 
		//You could prob. make a public variable for this
		GetComponent<UnityEngine.ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Forground";
	}
	// Update is called once per frame
	void Update () {
	
	}
}
