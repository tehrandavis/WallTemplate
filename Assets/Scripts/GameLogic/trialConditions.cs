using UnityEngine;
using System.Collections;

public class trialConditions : MonoBehaviour {
	public GameObject Player1;
	public GameObject Player2;
	public GameObject tableCamera;

	public float Player1size;
	public float Player2size;

	public float ZcameraPos;
	public Vector3 cameraRot;

	public float trialTime;

	// Use this for initialization
	void Start () {
		// define camera info:

		tableCamera = GameObject.Find("tableCamera");

		ZcameraPos = PlayerPrefs.GetFloat("ZcameraPos");

		// camera rotation:
		cameraRot = tableCamera.transform.eulerAngles;

		if (ZcameraPos == 1){
			cameraRot.y = 180f;
		} else {
			cameraRot.y = 0f;
		}
		tableCamera.transform.eulerAngles = cameraRot;

		// camera position
		Vector3 cameraPos = tableCamera.transform.position;
		cameraPos.z = ZcameraPos;
		tableCamera.transform.position = cameraPos;

		Player1 = GameObject.Find("Player1");
		Vector3 Player1dim = Player1.transform.localScale;
		//Player1dim = new Vector3(Player1size,Player1size,Player1size);

		Player1dim = new Vector3(PlayerPrefs.GetFloat("Player1size"),PlayerPrefs.GetFloat("Player1size"),PlayerPrefs.GetFloat("Player1size"));
		Player1.transform.localScale = Player1dim;

		Player2 = GameObject.Find("Player2");
		Vector3 Player2dim = Player2.transform.localScale;
		//Player2dim = new Vector3(Player2size,Player2size,Player2size);

		Player2dim = new Vector3(PlayerPrefs.GetFloat("Player2size"),PlayerPrefs.GetFloat("Player2size"),PlayerPrefs.GetFloat("Player2size"));
		Player2.transform.localScale = Player2dim;
	}
		
}
