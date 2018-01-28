using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningLogic : MonoBehaviour
{

	public GameObject Text_1;
	public GameObject Text_2;
	public GameObject Text_3;
	public GameObject IntroductionBGforText;
	public GameObject IntroductionBG;
	public GameObject Arrow_Introduction_left;
	public GameObject Arrow_Introduction_right;
	public GameObject PianoBee;
	public GameObject VintageDrumBee;
	public GameObject SaxBee;

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

		StartCoroutine(ShowIntro());
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

		int index = 0;
		int instrument = 0;

		var path = new List<Directions>(Pathing.m_currentPath);
		while (path.Count > 0)
		{
			Arrow_Introduction_left.GetComponent<SpriteRenderer>().enabled = false;
			Arrow_Introduction_right.GetComponent<SpriteRenderer>().enabled = false;

			var endTime4 = Time.time + 0.5f;
			while (Time.time < endTime4)
			{
				yield return null;
			}

			var direction = path[0];
			path.RemoveAt(0);

			Arrow_Introduction_left.GetComponent<SpriteRenderer>().enabled = (direction == Directions.Left);
			Arrow_Introduction_right.GetComponent<SpriteRenderer>().enabled = (direction == Directions.Right);

			var endTime5 = Time.time + 2.0f;
			while (Time.time < endTime5)
			{
				yield return null;
			}

			if (++index == 3)
			{
				if (instrument == 0)
				{
					PianoBee.GetComponent<AudioSource>().mute = false;
				}
				else if (instrument == 1)
				{
					VintageDrumBee.GetComponent<AudioSource>().mute = false;
				}
				else if (instrument == 2)
				{
					SaxBee.GetComponent<AudioSource>().mute = false;
				}

				instrument++;
				index = 0;
			}
		}

		Arrow_Introduction_left.GetComponent<SpriteRenderer>().enabled = false;
		Arrow_Introduction_right.GetComponent<SpriteRenderer>().enabled = false;

		var endTime6 = Time.time + 6.0f;
		while (Time.time < endTime6)
		{
			yield return null;
		}

		SceneManager.LoadScene("Gameplay");
	}
}
