using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeed : MonoBehaviour {

	public Animator animator;
	public float speed;

	void Start () {
		animator.speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
