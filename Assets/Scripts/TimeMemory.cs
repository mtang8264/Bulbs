using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMemory : MonoBehaviour {
	public DateTime lastSaveTime;
	public DateTime lastLoadTime;
	BulbStat bulb;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnSave () {
		lastSaveTime = DateTime.Now;
	}
	
	void OnLoad () {
		lastLoadTime = DateTime.Now;
		
		TimeSpan duration = lastLoadTime.Subtract(lastSaveTime);
		
		Debug.Log("" + duration.TotalSeconds + "seconds since last save");
		
		bulb = GameObject.FindWithTag("Bulb").GetComponent<BulbStat>();
		
		int secondsSinceSave = (int)duration.TotalSeconds;
		
		for(int i = 0; i < secondsSinceSave; i ++){
			if(i % 60 == 0 && i != 0){
				bulb.Tick();
				Debug.Log("Ticking!");
			}
		}
	}
}
