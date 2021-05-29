using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorescr : MonoBehaviour {


	public int[] score1;// ta score arrays einai gia tis korines pou epesan se ka8e attempt gia ka8e paikth
	public int[] score2=new int[25];
	private Text score;
	public throwball ballscript;
	public char[] special1=new char[11]; //Ta special arrays einai gia thn apo8hkeush strike h spare gia ka8e paikth xwrista
	public char[] special2=new char[11];
	public int[] roundscore1=new int[11] ; //ta roundscore attays einai to a8roisma kai twn 2 attempt enos gurou
	public int[] roundscore2=new int[11] ;
	private int totalscore1; //to sunoliko score tou ka8e paikth
	private int totalscore2;
	public Text rdscore1;
	public Text atscore1;
	public Text rdscore2;
	public Text atscore2;


	// Use this for initialization
	void Start () {
		
		totalscore1 = 0;
		totalscore2 = 0;

		score1=new int[30];
		score2=new int[30];
		special1=new char[11];
		special2=new char[11];
		roundscore1=new int[11] ;
		roundscore2=new int[11] ;

		for (int i = 0; i < 20; i++) {
			score1 [i] = 0;
			score2 [i] = 0;
		}
		for (int i = 0; i <= 10; i++) {
			special1 [i] = ' ';
			special2 [i] = ' ';
			roundscore1 [i] = 0;
			roundscore2 [i] = 0;

		}

		score = GetComponent<Text> ();
		score.text =  "(Press Tab for full score)";
		atscore1.text = " ";
		rdscore1.text = " ";
		atscore2.text = " ";
		rdscore2.text = " ";
		atscore1.enabled = false;
		rdscore1.enabled = false;
		atscore2.enabled = false;
		rdscore2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (ballscript.getattemptend() == true) {
			totalscore1 = 0;
			totalscore2 = 0;
			for(int i=0;i<11;i++){
				

				//upologismos twn round score me bash to an eginan strike h spare sumfwna me tous episimous kanones tou bowling
				if(special1[i]=='X'){
					roundscore1[i]=score1[2*i+1]+score1[2*(i+1)+1];
					if(special1[i+1]=='X'){
						roundscore1[i]+=score1[2*(i+2)+1];
					}else{
						roundscore1[i]+=score1[2*(i+1)+2];
					}
				}else if(special1[i]=='/'){
					roundscore1[i]=score1[2*i+1]+score1[2*i+2]+score1[2*(i+1)+1];
				}else{
					roundscore1[i]=score1[2*i+1]+score1[2*i+2];
				}


				if(special2[i]=='X'){//gia ton 2o paikth
					roundscore2[i]=score2[2*i+1]+score2[2*(i+1)+1];
					if(special2[i+1]=='X'){
						roundscore2[i]+=score2[2*(i+2)+1];
					}else{
						roundscore2[i]+=score2[2*(i+1)+2];
					}
				}else if(special2[i]=='/'){
					roundscore2[i]=score2[2*i+1]+score2[2*i+2]+score2[2*(i+1)+1];
				}else{
					roundscore2[i]=score2[2*i+1]+score2[2*i+2];
				}
				totalscore1 += roundscore1[i];
				totalscore2 += roundscore2[i];

		}
			roundscore1 [9] = roundscore1 [9] +	score1 [21];	//gia to teleutaio attempt tou teleutaiou gurou
			roundscore2 [9] = roundscore2 [9] +	score2 [21];
			totalscore1 += score1[21];
			totalscore2 += score2[21];

	     



		}
		score.text = totalscore1+ " - "+ totalscore2+"(Press Tab for full score)";	
		//score.text = score1+" - "+score2;


		atscore1.text = score1[1].ToString()+","+score1[2].ToString();
		rdscore1.text = "Player 1: " + roundscore1[0].ToString();
		for(int i=1;i<10;i++){
			rdscore1.text+= " - " + roundscore1[i].ToString();//dhmiourgia eniaiou string pou 8a periexei olh thn plhroforia twn gurwn se ena text UI
		}
		for(int i=3;i<22;i=i+2){
			atscore1.text+=" - "+ score1[i].ToString() + ","+score1[i+1].ToString();
		}

		atscore2.text = score2[1].ToString()+","+score2[2].ToString();
		rdscore2.text = "Player 2: " + roundscore2[0].ToString();
		for(int i=1;i<10;i++){
			rdscore2.text+= " - " + roundscore2[i].ToString();
		}
		for(int i=3;i<22;i=i+2){
			atscore2.text+=" - "+ score2[i].ToString() + ","+score2[i+1].ToString();
		}

		showinfo ();

	}


	void showinfo(){//gia to analutiko score oso patietai to tab
		if (Input.GetKeyDown (KeyCode.Tab)) {
			atscore1.enabled = true;
			rdscore1.enabled = true;
			atscore2.enabled = true;
			rdscore2.enabled = true;
		}
		if (Input.GetKeyUp (KeyCode.Tab)) {
			atscore1.enabled = false;
			rdscore1.enabled = false;
			atscore2.enabled = false;
			rdscore2.enabled = false;
		}
	}



	public void newgame(){//reset score
		totalscore1 = 0;
		totalscore2 = 0;
		for (int i = 0; i < 22; i++) {
			score1 [i] = 0;
			score2 [i] = 0;
		}
		for (int i = 0; i <= 10; i++) {
			special1 [i] = ' ';
			special2 [i] = ' ';
			roundscore1 [i] = 0;
			roundscore2 [i] = 0;

		}
	}

	public int getscore(int x){
		if(x==1){
			return totalscore1;
		}else{
			return totalscore2;
		}
	}

}
