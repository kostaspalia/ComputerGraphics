using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followball : MonoBehaviour {

	public GameObject ball;
	private Vector3 offset;
	private Quaternion initrot;

	// Use this for initialization
	void Start () {
		offset = transform.position - ball.transform.position;   //h sta8erh apostash ths cameras apo thn bala
		initrot = transform.rotation;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (ball.transform.position.z < 9) {
			transform.position = ball.transform.position + offset;
			transform.rotation=initrot ;
		} else {
			transform.RotateAround (new Vector3 (0f, 1.4f, 10f), transform.up, 10f * Time.deltaTime); //otan h bala ftasei tis korines kane orbit gia allagh optikhs gwnias

		} 
	}
}

