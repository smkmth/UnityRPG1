using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;


[Serializable]
public class PlayerStatistics
{
	public int SceneID;
	public float PositionX, PositionY, PositionZ;


	public float Health;
	public float Exp;
	public float Money;
}

