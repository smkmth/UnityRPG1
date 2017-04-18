using UnityEngine;
//this is the broadcaster which emits a message when an object collides with
//it. the message is picked up by the messaging manager

public class MessagingClientBroadcast : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col)
	{
		MessagingManager.Instance.Broadcast();
	}
}
