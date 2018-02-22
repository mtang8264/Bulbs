using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbWander : MonoBehaviour {
	Transform startMarker;
	Transform endMarker;

	bool moving = false;
	float startTime;
	float journeyLength;
	public float speed;
	bool updated;
	Animator animator;
	
	// Update is called once per frame
	void Update () {
		if (startMarker == null){
			startMarker = GameObject.FindWithTag("Start").GetComponent<Transform>();
		}
		if (endMarker == null){
			endMarker = GameObject.FindWithTag("End").GetComponent<Transform>();
		}
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}

		if(moving){
			if(endMarker.position.x > transform.position.x){
				transform.localScale = new Vector3(-1,1,1);
			}else{
				transform.localScale = new Vector3(1,1,1);
			}

			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

			if(transform.position == endMarker.position){
				moving = false;
				updated = false;
			}
		}else{
			if(Random.value > 0.98){
				moving = true;
				updated = false;
				startTime = Time.time;
				RandomTravelPoint();
				journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
			}
		}

		if(moving && !updated){
			updated = true;
			animator.CrossFade("Move",0f);
		}else if(!moving && !updated){
			updated = true;
			animator.CrossFade("Idle",0f);
		}
	}

	//Moves the end marker to its new position
	void RandomTravelPoint(){
		startMarker.position = transform.position;
		float dist = Random.value;
		if(transform.position.x > 0){
			endMarker.position = new Vector3(transform.position.x - dist*2,1.5f,1.5f);
		}else{
			endMarker.position = new Vector3(transform.position.x + dist*2,1.5f,1.5f);
		}
	}
	
	public void PleaseStartOver(){
		startMarker.position = transform.position;
		endMarker.position = transform.position;
		moving = false;
		startTime = Time.time;
	}
}
