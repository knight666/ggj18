using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningLogic : MonoBehaviour
{

	public GameObject Text_1;
	public GameObject Text_2;
	public GameObject Text_3;
	public GameObject IntroductionBGforText;
	public GameObject IntroductionBG;
	public GameObject Arrow_Introduction_left;
	public GameObject Arrow_Introduction_right;

	// Use this for initialization
	void Start()
	{
		Text_1.GetComponent<SpriteRenderer>().enabled = false;
		Text_2.GetComponent<SpriteRenderer>().enabled = false;
		Text_3.GetComponent<SpriteRenderer>().enabled = false;
		IntroductionBG.GetComponent<SpriteRenderer>().enabled = false;
		Arrow_Introduction_left.GetComponent<SpriteRenderer>().enabled = false;
		Arrow_Introduction_right.GetComponent<SpriteRenderer>().enabled = false;

		Pathing.Initialize();

		StartCoroutine(ShowArrows());
		//StartCoroutine(ShowIntro());
	}

	// Update is called once per frame
	void Update()
	{

	}

	IEnumerator ShowIntro()
	{
		Text_1.GetComponent<SpriteRenderer>().enabled = true;

		var endTime1 = Time.time + 3.0f;
		while (Time.time < endTime1)
		{
			yield return null;
		}

		Text_1.GetComponent<SpriteRenderer>().enabled = false;
		Text_2.GetComponent<SpriteRenderer>().enabled = true;

		var endTime2 = Time.time + 3.0f;
		while (Time.time < endTime2)
		{
			yield return null;
		}

		Text_2.GetComponent<SpriteRenderer>().enabled = false;
		Text_3.GetComponent<SpriteRenderer>().enabled = true;

		var endTime3 = Time.time + 3.0f;
		while (Time.time < endTime3)
		{
			yield return null;
		}

		Text_3.GetComponent<SpriteRenderer>().enabled = false;
		IntroductionBG.GetComponent<SpriteRenderer>().enabled = true;
	}

	IEnumerator ShowArrows()
	{
		var path = Pathing.m_currentPath;

		while (path.Count > 0)
		{
			Arrow_Introduction_left.GetComponent<SpriteRenderer>().enabled = false;
			Arrow_Introduction_right.GetComponent<SpriteRenderer>().enabled = false;

			var endTime2 = Time.time + 0.5f;
			while (Time.time < endTime2)
			{
				yield return null;
			}

			var direction = path[0];
			path.RemoveAt(0);

			Arrow_Introduction_left.GetComponent<SpriteRenderer>().enabled = (direction == Pathing.Directions.Left);
			Arrow_Introduction_right.GetComponent<SpriteRenderer>().enabled = (direction == Pathing.Directions.Right);

			var endTime1 = Time.time + 2.0f;
			while (Time.time < endTime1)
			{
				yield return null;
			}
		}

		Arrow_Introduction_left.GetComponent<SpriteRenderer>().enabled = false;
		Arrow_Introduction_right.GetComponent<SpriteRenderer>().enabled = false;
	}
}
