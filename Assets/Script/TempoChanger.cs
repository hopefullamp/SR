using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoChanger : MonoBehaviour {

public Record record;

float speed = -800.0f; //how fast the object should rotate
private bool switched = false;
Vector3 rotation;

	void Update(){
		
	
		if (Input.GetMouseButton(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hitInfo;
				if (Physics.Raycast(ray, out hitInfo))
				{
					if (hitInfo.collider.gameObject.tag == "TempoButton"){
					//Debug.Log("TempoChanged");
					transform.Rotate(new Vector3(0 , 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * speed);

					//우선 로테이션 값을 변수화한다.
					rotation = transform.rotation.eulerAngles;
					//Debug.Log("rotation : "+rotation);

					//템포마커의 로테이션 범위를 조정한다. 
					if (rotation.y>90 && rotation.y<180){//270 , 90 
						transform.rotation = Quaternion.Euler(90 ,90 ,0);
						//Debug.Log("Over");
					
					}
					else if (rotation.y<270 && rotation.y>180){
						transform.rotation = Quaternion.Euler(90 ,270 ,0);
						Debug.Log("Over");
					}


					//로테이션 to 스피드 데이터 맵핑은 아래를 참고 
					else if (rotation.y>=0 && rotation.y<=90.0f){ // 21~36 스피드
						record.speed = (((rotation.y - 0)*15) / 90) + 21;
					}
					
					else if (rotation.y>=270 && rotation.y<360.0f){ // 6~20.9999 스피드 
						record.speed = (((rotation.y - 270)*14.9999f) / 90) + 6;
					}
				}
	
            }
        }	
	}
}

/* 
public float mapping(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
 
    float OldRange = (OldMax - OldMin);
    float NewRange = (NewMax - NewMin);
    float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
 
    return(NewValue);
}
*/