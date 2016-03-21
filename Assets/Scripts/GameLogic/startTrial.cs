using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class startTrial : MonoBehaviour {

	public int triggerCount; // polls all possible end trial triggers; how many have been triggered?
	public GameObject trigger1, trigger2;
	public int trialNumber;


	// Use this for initialization
	void Start () {
		trialNumber = PlayerPrefs.GetInt ("trialNumber"); // get the trial number

		triggerCount = 0;

		trigger1 = GameObject.Find("trialTrigger1");
		trigger2 = GameObject.Find("trialTrigger2");
	}

	// Update is called once per frame
	void Update () {
		
		int trigger1ready = trigger1.GetComponent<goTrigger>().goTrial;
		int trigger2ready = trigger2.GetComponent<goTrigger>().goTrial;

		triggerCount = trigger1ready + trigger2ready;



		if (triggerCount == 2){
			trialNumber++;
			PlayerPrefs.SetInt("trialNumber", trialNumber);
			SceneManager.LoadScene( "TableActive" );
		}
	}
}