using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class trialCountdown : MonoBehaviour {

	public float timeLeft = 40;
	public float endTrial = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft < 0){
			
		}
	
	}
}
