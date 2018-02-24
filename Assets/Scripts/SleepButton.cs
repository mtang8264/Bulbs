using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepButton : MonoBehaviour {
	public bool sleeping = false;
	public Material selectMaterial;
	public Material unselectMaterial;
	bool loadUpdate;

	void Update(){
		if (loadUpdate) {
			loadUpdate = false;
			BulbStat bulb = GameObject.FindWithTag ("Bulb").GetComponent<BulbStat> ();
			if (bulb.sleeping) {
				gameObject.GetComponent<SpriteRenderer> ().material = selectMaterial;
			} else {
				gameObject.GetComponent<SpriteRenderer> ().material = unselectMaterial;
			}
		}
	}

	void OnMouseDown(){
		if(sleeping){
			sleeping = false;
			GameObject.FindWithTag("Bulb").GetComponent<BulbStat>().sleeping = false;
			gameObject.GetComponent<SpriteRenderer>().material = unselectMaterial;
			GameObject.FindWithTag("Bulb").GetComponent<BulbWander>().PleaseStartOver();
		}else{
			sleeping = true;
			GameObject.FindWithTag("Bulb").GetComponent<BulbStat>().sleeping = true;
			gameObject.GetComponent<SpriteRenderer>().material = selectMaterial;
			GameObject.FindWithTag("Bulb").GetComponent<Transform>().position = new Vector3(0f,1.5f,0f);
		}
	}

	void OnLoad(){
		loadUpdate = true;
	}
}
