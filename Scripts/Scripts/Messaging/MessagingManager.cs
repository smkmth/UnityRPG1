using System;
using System.Collections.Generic;
using UnityEngine;

//a messsaging manager classs will manage a list of objects and notify them
//if somthing occurs.

public class MessagingManager : MonoBehaviour
{
	//static singleton property
	public static MessagingManager Instance { get; private set; }
	//public property for manager
	private List<Action> subscribers = new List<Action>();



void Awake()
{
	Debug.Log("Messaging Manager Started");
	//first we check if any instances are colliding 
	if (Instance != null && Instance != this)
	{
		Destroy(gameObject);
	}
	//save this as our singleton instance
	Instance = this;
	//make sure this instance is not destroyed between seends
	DontDestroyOnLoad(gameObject);

}
//the subscribe method for manager
public void Subscribe(Action subscriber)
{
	Debug.Log("Subscriber registered");
	subscribers.Add(subscriber);
}
//the unsubscribe method for manager
public void UnSubscribe(Action subscriber)
{
	Debug.Log("Subscriber registered");
	subscribers.Remove(subscriber);
}
public void ClearAllSubscribers()
{
	subscribers.Clear();
}
public void Broadcast()
{
		Debug.Log ("Broadcast Requested, no of subs =" + subscribers.Count);
	foreach (var subscriber in subscribers)
	{
			subscriber ();
	}
}
}