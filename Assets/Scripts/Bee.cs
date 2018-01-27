using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {

	public GameObject m_hexGridInstance;
	private HexGrid m_hexGrid;

	public float m_distanceMinimum = 1;
	public float m_distanceMaximum = 2;

	void Start()
	{
		m_hexGrid = m_hexGridInstance.GetComponent<HexGrid>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
		}

		var positionFlat = transform.position;
		positionFlat.z = 0;

		foreach (var crossing in m_hexGrid.m_controlPoints)
		{
			var crossingFlat = crossing.transform.position;
			crossingFlat.z = 0;

			var distance = Vector3.Distance(positionFlat, crossingFlat);
			crossing.GetComponent<Crossing>().m_active = distance > m_distanceMinimum && distance < m_distanceMaximum;
		}
	}
}
