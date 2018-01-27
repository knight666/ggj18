using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {

	public GameObject m_hexGridInstance;
	private HexGrid m_hexGrid;

	public float m_distanceMinimum = 1;
	public float m_distanceMaximum = 2;
	public List<GameObject> m_overlays = new List<GameObject>();
	private GameObject m_overlayActive;

	public GameObject m_audioDrums;
	public GameObject m_audioPiano;
	public GameObject m_audioSaxophone;

	private int m_hits = 0;
	private int m_checkpointIndex = 0;

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
			!m_overlayActive)
		{
			positionFlat.y -= 1;

			var normalUp = new Vector3(0, 1, 0);
			var normalRight = new Vector3(1, 0, 0);

			GameObject leftCrossing = null;
			GameObject rightCrossing = null;

			foreach (var crossing in nearCrossings)
			{
				var crossingNormal = crossing.transform.position;
				crossingNormal.z = 0;

				crossingNormal = crossingNormal - positionFlat;
				crossingNormal.Normalize();

				float dotUp = Vector3.Dot(normalUp, crossingNormal);
				if (dotUp > 0)
				{
					float dotRight = Vector3.Dot(normalRight, crossingNormal);
					if (dotRight > 0)
					{
						rightCrossing = crossing;
					}
					else
					{
						leftCrossing = crossing;
					}
				}
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow) &&
				leftCrossing)
			{
				HitCrossing(leftCrossing);
			}

			if (Input.GetKeyDown(KeyCode.RightArrow) &&
				rightCrossing)
			{
				HitCrossing(rightCrossing);
			}
		}
	}

	private void HitCrossing(GameObject crossing)
	{
		transform.position = new Vector3(crossing.transform.position.x, crossing.transform.position.y, 5);
		crossing.GetComponent<Crossing>().m_active = true;

		if (++m_hits >= 3)
		{
			m_overlayActive = GameObject.Instantiate(m_overlays[m_checkpointIndex]);

			// Sorry David, but I don't know jack shit about audio mixing...

			if (m_checkpointIndex == 0)
			{
				m_audioPiano.GetComponent<AudioSource>().mute = false;
			}
			else if (
				m_checkpointIndex == 1)
			{
				m_audioDrums.GetComponent<AudioSource>().mute = false;
			}
			else if (
				m_checkpointIndex == 2)
			{
				// TODO: Saxophone
				//m_audioSaxophone.GetComponent<AudioSource>().mute = false;
			}

			if (++m_checkpointIndex > 2)
			{
				m_checkpointIndex = 0;
			}

			m_hits = 0;
		}
	}
}
