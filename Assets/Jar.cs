using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jar : MonoBehaviour {

	private Image m_empty;
	private Image m_filled;

	void Start()
	{
		m_empty = transform.GetChild(0).GetComponent<Image>();
		m_filled = transform.GetChild(1).GetComponent<Image>();
	}
	
	public void SetFilled(bool value)
	{
		m_empty.enabled = !value;
		m_filled.enabled = value;
	}
}
