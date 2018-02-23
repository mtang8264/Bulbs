using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbStat : MonoBehaviour {
	public string bulbName;
	public string gender;

	//Stats should {Decay rate, current value}
	public float[] hunger = new float[2];
	public float[] thirst = new float[2];
	public float[] sleep = new float[2];
	public int magic;

	public int statTickTime;
	bool tick = true;
	
	public bool sleeping = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((int)Time.time % statTickTime == 0) {
			if (tick) {
				if (sleeping) {
					if ((int)Time.time % (statTickTime * 2) == 0) {
						Tick ();
					}
				} else {
					Tick ();
				}
			}
		} else {
			tick = true;
		}
		
		if(hunger[1] > 100){
			hunger[1] = 100;
		}
		if(hunger[1] < 0){
			hunger[1] = 0;
		}
		if(thirst[1] > 100){
			thirst[1] = 100;
		}
		if(thirst[1] < 0){
			thirst[1] = 0;
		}
		if(sleep[1] > 100){
			sleep[1] = 100;
		}
		if(sleep[1] < 0){
			sleep[1] = 0;
		}
		
		if(sleeping){
			gameObject.GetComponent<BulbWander>().enabled = false;
			gameObject.GetComponent<Animator> ().CrossFade ("Sleep", 0f);
			sleep[1] += 0.01f;
		}else{
			gameObject.GetComponent<BulbWander>().enabled = true;
		}
	}
	
	public void Feed (float value){
		if(!sleeping)
			hunger[1] += value;
	}
	public void Drink (float value){
		if(!sleeping)
			thirst[1] += value;
	}
	public void Tick (){
				tick = false;
				hunger [1] -= hunger [0] * 0.1f;
				thirst [1] -= thirst [0] * 0.1f;			
				sleep [1] -= sleep [0] * 0.1f;
	}
}
