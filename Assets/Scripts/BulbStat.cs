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
	bool sleepingTick = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((int)Time.time % statTickTime == 0) {
			if (tick) {
				Tick();
			}
		} else {
			tick = true;
		}
		
		if(hunger[1] > 1){
			hunger[1] = 1;
		}
		if(hunger[1] < 0){
			hunger[1] = 0;
		}
		if(thirst[1] > 1){
			thirst[1] = 1;
		}
		if(thirst[1] < 0){
			thirst[1] = 0;
		}
		if(sleep[1] > 1){
			sleep[1] = 1;
		}
		if(hunger[1] < 0){
			sleep[1] = 0;
		}
		
		if(sleeping){
			gameObject.GetComponent<BulbWander>().enabled = false;
			gameObject.GetComponent<Animator> ().CrossFade ("Sleep", 0f);
			if((int)Time.time % (int)(statTickTime/4) == 0 && sleepingTick){
				sleep[1] += 0.1f;
				sleepingTick = false;
			}else if((int)Time.time % (int)(statTickTime/4) == 0){
				sleepingTick = false;
			}
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
				hunger [1] -= hunger [0] * 0.01f;
				thirst [1] -= thirst [0] * 0.01f;			
				sleep [1] -= sleep [0] * 0.01f;
	}
}
