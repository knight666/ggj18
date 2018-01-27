using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossing : MonoBehaviour {

	public bool m_active = false;

	void Start ()
	{
	}

	void Update ()
	{
		var sprite = GetComponent<SpriteRenderer>();
		sprite.color = m_active ? Color.red : Color.white;
	}
}
