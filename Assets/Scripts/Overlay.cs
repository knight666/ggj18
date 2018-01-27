using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay
	: MonoBehaviour
{
	void Start()
	{
	}

	void Update()
	{
	}

	public void DoneEvent(string s)
	{
		Destroy(this);
	}
}
