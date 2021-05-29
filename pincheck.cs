using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pincheck : MonoBehaviour {


	public int pins_hit;//oi korines pou exoun pesei se auton ton guro(kai sta 2 attempts a8roistika)


	private pinhit[] pinarray;




	// Use this for initialization
	void Start () {
		pins_hit=0;

		pinarray = GetComponentsInChildren<pinhit> ();

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void pinsinit(){
		foreach (pinhit pin in pinarray) {//arxikopoihsh ka8e pin xwrista
			pin.pininit ();
			pins_hit=0;
		}
	}

	public void pinshide(){//apenergopoihsh twn pesmenwn korinwn
		foreach (pinhit pin in pinarray) {
			if (pin.isHit == true)
				pin.pinhide ();

		}
	}



}
