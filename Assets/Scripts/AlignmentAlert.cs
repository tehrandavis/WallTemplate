using UnityEngine;
using System.Collections;

public class AlignmentAlert : MonoBehaviour {

	public string PlayerName;
	public string sensorName;
	public int sensor;
	public float touchHeight;
	public bool playersAligned;
	public Renderer rend;
	public float flickerFreq;
	public float flickerTimer;

	public Ray alignmentRay;
	public float rayDirection;

	public int alignedHits;

	// Use this for initialization
	void Start () {

		// Identify sensor

		PlayerName = gameObject.name;
		sensorName = PlayerName.Substring(6,1); 
		sensor = int.Parse(sensorName);
		touchHeight = 12; // 12 meters should be enough for overlap

		rend = GetComponent<Renderer>();
		rend.enabled = true;
		flickerFreq = 1/8f; // flicker at 3Hz
		flickerTimer = 0;
		rayDirection = transform.position.z;



	
	}
	
	// Update is called once per frame
	void Update () {



		// use raycasting to detect
		RaycastHit hit;

		if (rayDirection < 0)
		{
			alignmentRay =  new Ray (transform.position, Vector3.forward);
			Debug.DrawRay (transform.position, Vector3.forward * touchHeight);
		
		} else

		{
			alignmentRay =  new Ray (transform.position, Vector3.back);
			Debug.DrawRay (transform.position, Vector3.back * touchHeight);
		}


		if (Physics.Raycast (alignmentRay, out hit, touchHeight) && hit.collider.tag=="Player")
		{
			playersAligned = true;
			TableEvents.alignedHitCounter.alignHit++;

		} else {
			playersAligned = false;
			TableEvents.alignedHitCounter.alignHit = 0;
		}

		if (TableEvents.alignedHitCounter.alignHit > 0)
		{
			rend.enabled = true;

		} else {
			// make object blink

			flickerTimer += Time.deltaTime;

			if(flickerTimer < flickerFreq)
			{
				rend.enabled = false;
			}

			if(flickerTimer > flickerFreq)
			{
				rend.enabled = true;
			}

			if(flickerTimer>flickerFreq*2)
			{
				flickerTimer = 0;
			}
		}

			

	
	}
}
