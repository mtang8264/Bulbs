using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkButton : MonoBehaviour {
	public BulbStat bulb;
	public float value = 0.1f;
	
	public Material unclicked;
	public Material clicked;
	
	private SpriteRenderer sr;
	
	void Awake(){
		sr = GetComponent<SpriteRenderer>();
	}
	
	void Update(){
		if(bulb == null){
			bulb = GameObject.FindWithTag("Bulb").GetComponent<BulbStat>();
		}
	}
	
	void OnMouseDown(){
		bulb.Drink(value);
		sr.material = clicked;
	}
	void OnMouseUp(){
		sr.material = unclicked;
	}
}
