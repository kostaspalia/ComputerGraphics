using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinhit : MonoBehaviour {
	public bool isHit;
	private Quaternion initrot;
	private Vector3 initpos;
	private float angle;
	private pincheck parentscript;
	private Rigidbody rb;
	private AudioSource asource;
	// Use this for initialization
	void Start () {
		isHit=false;
		initrot = transform.rotation;
		initpos = transform.position;
		angle = 0f;
		parentscript = transform.parent.GetComponent<pincheck> ();
		rb=GetComponent<Rigidbody>();
		asource=gameObject.GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {

		angle = Quaternion.Angle (initrot, transform.rotation);
		if (angle>=40f  && !isHit) {   //an h korina exei pesei
			
			isHit = true;
			parentscript.pins_hit++;   //enhmerwse thn metablhth sto parentscript
			asource.Play ();//hxos korinwn
		}
	}

	public void pinhide(){
		gameObject.SetActive (false);    //apenergopoihse thn  korina pou epese

	}

	public void pininit(){    //epanatopo8ethsh ths korinas sthn arxikh 8esh ths
		isHit = false;
		transform.rotation = initrot;
		transform.position = initpos;
		angle = 0f;
		gameObject.SetActive (true);
		rb.Sleep();
	 
	}


}
