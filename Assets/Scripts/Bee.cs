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

		List<GameObject> nearCrossings = new List<GameObject>();

		foreach (var crossing in m_hexGrid.m_controlPoints)
		{
			var crossingFlat = crossing.transform.position;
			crossingFlat.z = 0;

			var distance = Vector3.Distance(positionFlat, crossingFlat);
			var isNear = distance > m_distanceMinimum && distance < m_distanceMaximum;
			if (isNear)
			{
				nearCrossings.Add(crossing);
			}

			//crossing.GetComponent<Crossing>().m_active = isNear;
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			foreach (var crossing in m_hexGrid.m_controlPoints)
			{
				crossing.GetComponent<Crossing>().m_active = false;
			}
		}

		if (nearCrossings.Count > 0 &&
			Input.GetKeyDown(KeyCode.A))
		{
			positionFlat.y -= 1;

			var greatestAngle = -Mathf.Infinity;
			GameObject greatestAngleInstance = null;

			var normalUp = new Vector3(0, 1, 0);
			var normalRight = new Vector3(1, 0, 0);

			foreach (var crossing in nearCrossings)
			{
				var crossingNormal = crossing.transform.position;
				crossingNormal.z = 0;

				crossingNormal = crossingNormal - positionFlat;
				crossingNormal.Normalize();

				/*float angle = Vector3.Angle(positionFlat, crossingFlat) - 180;
				if (angle > greatestAngle)
				{
					greatestAngle = angle;
					greatestAngleInstance = crossing;
				}*/

				float dotRight = Vector3.Dot(normalUp, crossingNormal);
				float dotUp = Vector3.Dot(normalRight, crossingNormal);
				if (dotRight > 0)
				{
					crossing.GetComponent<Crossing>().m_active = true;
				}
			}

			if (greatestAngleInstance)
			{
				greatestAngleInstance.GetComponent<Crossing>().m_active = true;
			}
		}
	}
}
