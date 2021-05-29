using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanesound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.CompareTag ("leball")) {//otan h mpala xtuphsei sto lane 3ekinaei o hxos

			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
