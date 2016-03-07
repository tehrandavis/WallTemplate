using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;
using System.Threading;
using System.Globalization;

public class trialParameters : MonoBehaviour {
	public int trialNumber;
	public int participantNumber;
	public string participantName;

	int totalTrials = 17;
	float Player1size;
	float Player2size;
	string Player1stance;
	string Player2stance;


	public float ZcameraPos;

	// read file specific vars:
	public string[] values;
	protected FileInfo theSourceFile = null;
	protected StreamReader reader = null;
	string text = " "; // assigned to allow first line to be read below

	// parameter list specific vars:
	public List<string> trialList = new List<string>();
	public List<string> player1sizeList = new List<string>();
	public List<string> player1stanceList = new List<string>();
	public List<string> player2sizeList = new List<string>();
	public List<string> player2stanceList = new List<string>();


	// Use this for initialization
	void Start () {

		// get the trial and participant number:
		participantName = PlayerPrefs.GetString ("playerName");
		trialNumber = PlayerPrefs.GetInt ("trialNumber");
		Debug.Log ("trial number is: "+trialNumber);

		if ((trialNumber + 1) > totalTrials){
			SceneManager.LoadScene("Goodbye");
		}



		participantNumber = int.Parse(participantName);

		// read in all lines of trial data file based on participant #
		string[] lines = File.ReadAllLines("TrialData_P" + participantNumber + ".txt");

		// read each line of file
		foreach(string line in lines) {
			// split by delimiter
			string[] values = line.Split(new string[] {","}, StringSplitOptions.None);

			// Create lists for each parameter
			trialList.Add(values[0]);
			player1sizeList.Add(values[1]);
			player1stanceList.Add(values[2]);
			player2sizeList.Add(values[3]);
			player2stanceList.Add(values[4]);

		}


		//totalTrials = targetSpeedList.Count;
		//Debug.Log ("number of trials is: "+ totalTrials);
		//PlayerPrefs.SetInt("TotalTrials", totalTrials);


		//Thread.Sleep(2000);



		// get paramerts for trial
		Player1size = float.Parse(player1sizeList[trialNumber]);
		Player1stance = player1stanceList[trialNumber];
		Player2size = float.Parse(player2sizeList[trialNumber]);
		Player2stance = player1stanceList[trialNumber];


		// set camera position * alternative set layers:
		if (Player1size > Player2size)
		{
			ZcameraPos = 1;
		} else {
			ZcameraPos = -1;
		}


		// save as player prefs
		PlayerPrefs.SetFloat("Player1size", Player1size);
		//Debug.Log ("trial speed is: "+PlayerPrefs.GetFloat("TrialSpeed"));

		PlayerPrefs.SetString("Player1stance", Player1stance);
		//Debug.Log ("trial time is: "+PlayerPrefs.GetFloat("TrialTime"));

		PlayerPrefs.SetFloat("Player2size", Player2size);
		//Debug.Log ("trial measure direction is: "+PlayerPrefs.GetFloat("MeasureDirection"));

		PlayerPrefs.SetString("Player2stance", Player2stance);
		//Debug.Log ("trial report direction is: "+PlayerPrefs.GetFloat("ReportDirection"));

		PlayerPrefs.SetFloat("ZcameraPos", ZcameraPos);
		// add trial number for next loop
		trialNumber++;
		PlayerPrefs.SetInt ("TrialNumber", trialNumber);


	}



	// Update is called once per frame
	void Update () {

	}
}
