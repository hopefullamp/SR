using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordColor : MonoBehaviour {

	public Sprite[] recordColor;
	public SpriteRenderer myImage;
	public InstChanger instChanger;

	void Update () {
		if(instChanger.instNum == 0){
			myImage.sprite = recordColor[0]; 
		}
		
		else if(instChanger.instNum == 1){
			myImage.sprite = recordColor[1]; 
		}
		
		else if(instChanger.instNum == 2){
			myImage.sprite = recordColor[2]; 
		}
		
		else if(instChanger.instNum == 3){
			myImage.sprite = recordColor[3]; 
		}
		
		else if(instChanger.instNum == 4){
			myImage.sprite = recordColor[4]; 
		}
		
		else if(instChanger.instNum == 5){
			myImage.sprite = recordColor[5]; 
		}
		
	}
}
