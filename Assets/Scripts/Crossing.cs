using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossing : MonoBehaviour {

	void Start ()
	{
	}

	void Update ()
	{
		var pos = this.GetComponent<Transform>().position;
		Debug.DrawLine(pos - new Vector3(10.0f, 10.0f), pos + new Vector3(10.0f, 10.0f));
	}
}
