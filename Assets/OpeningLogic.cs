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

	// Use this for initialization
	void Start()
	{
		Text_1.GetComponent<SpriteRenderer>().enabled = true;
		Text_2.GetComponent<SpriteRenderer>().enabled = false;
		Text_3.GetComponent<SpriteRenderer>().enabled = false;
		IntroductionBG.GetComponent<SpriteRenderer>().enabled = false;

		StartCoroutine(ShowIntro());
	}

	// Update is called once per frame
	void Update()
	{

	}

	IEnumerator ShowIntro()
	{
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
}
