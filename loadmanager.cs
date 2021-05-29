using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadmanager : MonoBehaviour {

	public GameObject ball;//references sta objects pou prepei na energopoih8oun/apenergopoih8oun
	public GameObject gameman;
	public GameObject canvas;// o canvas tou bowling minigame
	public GameObject fpscam;
	public GameObject maincam;
	public GameObject lobcanvas; //o canvas sto lobby
	private Text helptext;

	// Use this for initialization
	void Start () {
		helptext = lobcanvas.GetComponentInChildren<Text> ();
		helptext.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {//an path8ei to esc epistrofh sto menu kai energopoish tou mouse(apenergopoieitai apo to fps controller)
			Cursor.visible = true;

			Cursor.lockState = CursorLockMode.None;

			fpscam.SetActive (false);
			maincam.SetActive (true);

			//gameObject.SetActive (false);
			exitTomenu ();
		}
	}


	void OnTriggerStay(Collider col){
		if (col.gameObject.CompareTag ("Player")) {//otan ftaseis konta sta lanes
			helptext.text = "Press E to start the game"; 
			if (Input.GetKey (KeyCode.E)) { //pata e gia na 3ekinhsei to game
				
				ball.SetActive (true);//energopoihsh aparaithtwn components

				canvas.SetActive (true);
				fpscam.SetActive (false);
				maincam.SetActive (true);
				lobcanvas.SetActive (false);
				gameman.SetActive (true);


			}
		} 
			

	}

	void OnTriggerExit(Collider col){//otan apomakrun8eis apo ta lanes
		
		lobcanvas.GetComponentInChildren<Text> ().text = "";
	}

	void exitTomenu(){
		SceneManager.LoadScene (0);
	}
}
