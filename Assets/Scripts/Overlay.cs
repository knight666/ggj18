using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay
	: MonoBehaviour
{
	public void DoneEvent(string blah)
	{
		Destroy(gameObject);
	}
}
