using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChangeButton : MonoBehaviour {
	public bool selected;
	public Material selectedMat;
	public Material unselectedMat;
	public ScreenChangeButton[] buttons;
	SpriteRenderer spriteRenderer;
	
	public string pre;
	GameObject screen;
	
	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void OnMouseDown(){
		for(int i = 0; i < buttons.Length; i ++){
			buttons[i].selected = false;
		}
		selected = true;
	}
	
	void Update(){
		if(screen == null){
			screen = GameObject.Find(pre + "Screen");
		}
		
		if(selected){
			screen.SetActive(true);
			spriteRenderer.material = selectedMat;
		}else{
			screen.SetActive(false);
			spriteRenderer.material = unselectedMat;
		}
	}
}
