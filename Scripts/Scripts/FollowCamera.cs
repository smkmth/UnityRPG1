using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float xMargin = 1.5f;
	public float yMargin = 1.5f;
	public float xSmooth = 1.5f;
	public float ySmooth = 1.5f;
	private Vector2 maxXAndY;
	private Vector2 minXAndY;
	public Transform player;

	void Awake()
	{
				//setting up refferences;
			player = GameObject.Find (		"Player").transform;
		if (player == null) {
			Debug.LogError ("Player object not found");
			}
		var backgroundBounds = GameObject.Find ("sky")
			.GetComponent<Renderer>().bounds;
		//Get the viewable bounds of the camera in the world
		//coordinates
		var camTopLeft = GetComponent<Camera>().ViewportToWorldPoint 
			(new Vector3 (0, 0, 0));
		var camBottomRight = GetComponent<Camera>().ViewportToWorldPoint
			(new Vector3 (1, 1, 1));
		minXAndY.x = backgroundBounds.min.x - camTopLeft.x;
		maxXAndY.x = backgroundBounds.max.x - camBottomRight.x;
	}
	
	bool CheckXMargin()
		{//returns true if the distance between the camerea and the 
			//player in the x axis is greater then x margin
		return Mathf.Abs 
				(transform.position.x - player.position.x) > xMargin;
		}
	bool CheckYMargin()
		{//returns true if the distance between the camera and 
				//the player in the y axis is greaeter then the y margin
				return Mathf.Abs
				(transform.position.y - player.position.y) > yMargin;
		}
	void FixedUpdate()
	{
		//by default the targets x and y coordinates of the camera 
		//are its current x and y coordinates 
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		//if the player has moved beyond the x margin
		if (CheckXMargin ())
			//the targets x coordinates should be a lerp between 
			//the cameras current x position and the players
			//current x position
						targetX = Mathf.Lerp (transform.position.x,
			                      player.position.x, xSmooth *
								Time.fixedDeltaTime);
		if (CheckYMargin ())
			//the targets y coordinates should be a lerp between 
			//the cameras current y position and the players 
			//current y position 
						targetY = Mathf.Lerp (transform.position.y,
			                     player.position.y, ySmooth *
								Time.fixedDeltaTime);
		//the target x and y coordinates should not be larger
		//then the maximum or smaller then the minimum
		targetX = Mathf.Clamp (targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp (targetY, minXAndY.y, maxXAndY.y);

		//Set the cameras position to the target position with
		//the same z component
		transform.position =
			new Vector3 (targetX, targetY, transform.position.z);
	}
}
