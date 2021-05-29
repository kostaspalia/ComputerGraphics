using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {

	// Use this for initialization

	private int round;
	private int attempt;
	private int player;
	private int numofplayers;
	private int hitmemory;  //boh8aei gia ton upologismo twn korinwn tou 2ou attempt
	public throwball ballscript;
	public Text attempts;
	public pincheck pinscript;
	public scorescr scorescript;
	public Text wintxt;


	void Start () {
		round = 1;
		attempt = 1;
		player = 1;
		attempts.text = "Attempt: " + attempt+ "    Round: " + round+ "   Player: "+player;
		wintxt.text = "";
		numofplayers = 2;
		hitmemory = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (ballscript.getattemptend() == true) {// se ka8e telos enos attempt
			pinscript.pinshide();
			wintxt.text = "";
			if (round < 10) { // an den einai o 10os gurps (pou exei kapoies eidikes periptwseis)

				if (player == 1) {
					scorescript.score1 [2 * (round - 1) + attempt] = pinscript.pins_hit - hitmemory;  //apo8hkeush score gia ka8e attempt 3exwrista
					if (attempt == 1 && pinscript.pins_hit == 10) {// gia to strike
						scorescript.special1 [round - 1] = 'X';
					} else if (attempt == 2 && pinscript.pins_hit == 10) { //gia to spare
						scorescript.special1 [round - 1] = '/';
					} else {
						scorescript.special1 [round - 1] = ' ';//gia tpt
					}




				} else {//gia ton 2o paikth
					scorescript.score2 [2 * (round - 1) + attempt] = pinscript.pins_hit - hitmemory;
					if (attempt == 1 && pinscript.pins_hit == 10) {
						scorescript.special2 [round - 1] = 'X';
					} else if (attempt == 2 && pinscript.pins_hit == 10) {
						scorescript.special2 [round - 1] = '/';
					} else {
						scorescript.special2 [round - 1] = ' ';
					}
				}


				hitmemory = pinscript.pins_hit;   //8a xrhsimopoih8ei gia to score ka8e 2ou attempt ws pinshit-hitmemory


				attempt++;
				if (attempt > 2 | pinscript.pins_hit == 10) {//telos ths seiras tou twrinou paikth kai epishs allagh gurou an player==2
					attempt = 1;
					hitmemory = 0;
					pinscript.pinsinit ();
					if (player == 2) {
						round++;
					}
					if (player < numofplayers) {
						player++;
					} else {
						player = 1;
					}
				}


			} else { // an einai o 10s guros



				if (player == 1) {
					scorescript.score1 [2 * (round - 1) + attempt] = pinscript.pins_hit - hitmemory;
					if (attempt == 1 && pinscript.pins_hit == 10) {
						scorescript.special1 [round - 1] = 'X';
					} else if (attempt == 2 && pinscript.pins_hit == 10) {
						scorescript.special1 [round - 1] = '/';
					} else {
						scorescript.special1 [round - 1] = ' ';
					}

					hitmemory = pinscript.pins_hit;

					if (scorescript.score1 [2 * (round - 1) + 1] == 10 | (scorescript.score1 [2 * (round - 1) + 2] + scorescript.score1 [2 * (round - 1) + 1] == 10&&attempt==2)) {
						hitmemory = 0;
						pinscript.pinsinit ();
					}

				} else {
					scorescript.score2 [2 * (round - 1) + attempt] = pinscript.pins_hit - hitmemory;
					if (attempt == 1 && pinscript.pins_hit == 10) {
						scorescript.special2 [round - 1] = 'X';
					} else if (attempt == 2 && pinscript.pins_hit == 10) {
						scorescript.special2 [round - 1] = '/';
					} else {
						scorescript.special2 [round - 1] = ' ';
					}

					hitmemory = pinscript.pins_hit;

					if (scorescript.score2 [2 * (round - 1) + 1] == 10 | (scorescript.score2 [2 * (round - 1) + 2] + scorescript.score2 [2 * (round - 1) + 1] == 10&&attempt==2)) {
						hitmemory = 0;
						pinscript.pinsinit ();
					}
				}

				attempt++;
				if (player == 1) {//allagh paikth analoga me to an ekane strike h spare h tpt
					
					if (attempt > 3 | (scorescript.score1 [2 * (round - 1) + 1] < 10 && scorescript.score1 [2 * (round - 1) + 2] + scorescript.score1 [2 * (round - 1) + 1] < 10&&attempt>2)) {
						attempt = 1;
						player++;
						hitmemory = 0;
						pinscript.pinsinit ();
					} 
			
				} else {
					if(attempt > 3 | (scorescript.score2 [2 * (round - 1) + 1] < 10 && scorescript.score2 [2 * (round - 1) + 2] + scorescript.score2 [2 * (round - 1) + 1] < 10&&attempt>2)) {//telos paixnidiou
						attempt = 1;
						player=1;
						round = 1;
						hitmemory = 0;

						if (scorescript.getscore (1) > scorescript.getscore (2)) {
							wintxt.text = "Player 1 won!!";
						} else {
							wintxt.text = "Player 2 won!!";
						}
						newgame ();
					}
				}
			}

			attempts.text = "Attempt: " + attempt+ "    Player: "+player+ "      Round: " + round ;
		}

		if (Input.GetKey (KeyCode.R)) { //gia to reset tou score
			newgame ();
			attempts.text = "Attempt: " + attempt+ "    Player: "+player+ "      Round: " + round ;
		}

	}

	public void newgame(){
		round = 1;
		attempt = 1;
		player = 1;
		hitmemory = 0;
		pinscript.pinsinit ();
		scorescript.newgame ();
	}




}
