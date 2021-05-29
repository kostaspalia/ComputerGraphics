using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwball : MonoBehaviour {

	private Rigidbody rb;

	public float z;
	private Vector3 initpos;
	private Quaternion initrot;
	private Vector3 inittargetpos;
	private Quaternion inittargetrot;
	private  bool ballthrown; 
	public bool attemptend;
	private float timer;
	private float backuptimer;
	float moveHorizontal;
	private bool poschosen;
	private bool anglechosen;
	public Transform targettrans;
	public Renderer targetrend;
	private float randomtarget;
	private bool randomdir;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		initpos = transform.position;
		initrot = transform.rotation;
		inittargetpos = targettrans.position;
		inittargetrot = targettrans.rotation;
		ballthrown = false;
		rb.useGravity = false;
		attemptend = false;
		timer = 0f;
		backuptimer = 0f;
		poschosen = false;
		moveHorizontal = 0f;
		anglechosen = false;
		targetrend.enabled = false;
		randomtarget = 0;
		randomdir=true;
	}

	void Update(){

		if (Input.GetMouseButtonDown (0) && !ballthrown&&poschosen ) {
			anglechosen = true;
		}

		if (!ballthrown&&!poschosen) {  //epilogh ths 8eshs ths balas ston x a3ona
			attemptend = false;
			moveHorizontal = Input.GetAxis ("Horizontal");

			if(!(transform.position.x<-0.75&&moveHorizontal<0)&&!(transform.position.x>0.75&&moveHorizontal>0)){   //oria ston x a3ona
			transform.position = transform.position + (new Vector3 (moveHorizontal/10, 0, 0));
			targettrans.position =targettrans.position + (new Vector3 (moveHorizontal/10, 0, 0));
			}
			if (Input.GetMouseButtonDown (0)) {
				poschosen = true;
				randomtarget = 2;
			}
				
		}

		if (poschosen) {  //afou epilex8hke h 8esh tote emfanish stoxou kai rotation enalla3 mexri na path8ei to mouse click
			targetrend.enabled = true;


			float step=27f;
			float limit = 14f;

			if (randomtarget < limit && randomdir) {
				transform.RotateAround (transform.position, transform.up, step*Time.deltaTime);
				targettrans.RotateAround (transform.position, transform.up, step*Time.deltaTime);
				randomtarget += step*Time.deltaTime;
					if (randomtarget > limit)
						randomdir = !randomdir;
				} else if (randomtarget > -limit && !randomdir) {
				transform.RotateAround (transform.position, transform.up, -step*Time.deltaTime);
				targettrans.RotateAround (transform.position, transform.up, -step*Time.deltaTime);
				randomtarget -= step*Time.deltaTime;
					if (randomtarget <-limit)
						randomdir = !randomdir;
			}

		}




		if (ballthrown && transform.position.z > 10) {//otan ftasei h bala stis korines metra allo ligo mexri to telos tou gurou

			timer += Time.deltaTime;
			if(timer>2)
				ballinit ();

		}

		if (ballthrown) {//k allos timer pou bh8aei na teleiwsei to attempt se periptwsh pou h bala fugei se kapoio allo lane 
			backuptimer += Time.deltaTime;
			if (backuptimer > 7) {
				ballinit ();
			}
		}




	}

	// Update is called once per frame
	void FixedUpdate () {
		
			
		if (anglechosen) {//otan epilex8hke o stoxos ri3e thn bala
			rb.AddForce (transform.forward*z, ForceMode.Impulse);
			ballthrown = true;
			rb.useGravity = true;
			targetrend.enabled = false;
			poschosen = false;
			anglechosen= false;
		}

	
	}

	void ballinit(){//topo8etish balas sthn arxikh 8esh gia kainourgio attempt
		transform.position = initpos;
		transform.rotation=initrot;
		targettrans.position=inittargetpos ;
		targettrans.rotation=inittargetrot ;

		ballthrown = false;
		rb.useGravity = false;
		rb.Sleep();
		attemptend = true;
		timer = 0f;
		backuptimer = 0f;
		poschosen = false;
		anglechosen = false;
		targetrend.enabled = false;

	}

	public bool getattemptend(){
		return attemptend;
	}

}
