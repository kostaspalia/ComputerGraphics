using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menufunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void LoadSceneOnClick(int sceneindex) {


				SceneManager.LoadScene (sceneindex);//fortosh skhnhs paixnidiou

		}

	public void quit(){//gia e3odo apo to game kai oso einai sto editor kai oso einai sto stand alone play 
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit ();
		#endif
	}

}


