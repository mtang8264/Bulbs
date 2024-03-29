﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMemory : MonoBehaviour {
	public DateTime lastSaveTime;
	public DateTime lastLoadTime;
	BulbStat bulb;
	public SleepButton sleepButton;
	private bool loadUpdate = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (loadUpdate) {
			GameObject[] arr;
			arr = GameObject.FindGameObjectsWithTag("Bulb");
			if (arr.Length == 1) {
				Debug.Log ("Found a bulb");

				bulb = GameObject.FindWithTag("Bulb").GetComponent<BulbStat>();
				lastLoadTime = DateTime.Now;

				TimeSpan duration = lastLoadTime.Subtract (lastSaveTime);

				Debug.Log ("" + duration.TotalSeconds + "seconds since last save");

				int secondsSinceSave = (int)duration.TotalSeconds;

				for (int i = 0; i < secondsSinceSave; i++) {
					if (bulb.sleeping) {
						bulb.sleep [1] += 0.1f;
						Debug.Log ("Sleep restored!");
					}
					if (i % 60 == 0 && i != 0) {
						if (bulb.sleeping) {
							if (i % 120 == 0 && i != 0) {
								bulb.Tick ();
								Debug.Log ("Ticking!");
							}
						} else {
							bulb.Tick ();
							Debug.Log ("Ticking!");
						}
					}
				}
				loadUpdate = false;

				if (bulb.sleeping) {
					sleepButton.sleeping = true;
				}
			}
		}
	}
	
	void OnSave () {
		lastSaveTime = DateTime.Now;
	}
	
	void OnLoad () {
		loadUpdate = true;
	}
}
