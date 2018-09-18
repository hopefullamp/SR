﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour {

	//1. 현재 마우스의 좌표를 받아온다. 
	//2. 현재 마우스의 좌표가 해당 오브젝트의 콜라다에 있다면 
	//3. 스텔라를 켠다. (알파 값을 반쯤으로 조정한다.) 
	//단 콜라다는 꺼져있다. 

	//이제 남은건 마우스가 떼지기전엔 반쯤 켜는 것과 거리별 콜라다 반지름(사이즈) 조정,
	//그리고 지우개 기능이다. 


	 public GameObject sphereCollider;
	 public Collider stellarCollider;
	 public Light light;

	 public GameObject stellar;

     public GameObject goOne;
     public GameObject center;
     
	 bool turnOn;

     bool goReady;
 
     GameObject initiateGO;
     int nextNameNumber = 0;
	 float timeCount = 0;


	void Start(){
		turnOn = false; 
		initiateGO = goOne;
        goReady = true;
	}
 
    void Update () 
    {


		//if (Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			//timeCount = timeCount + Time.deltaTime * 1;

				if (Physics.Raycast(ray, out hit)){
					if (Input.GetMouseButton(0) && hit.collider.gameObject==sphereCollider && turnOn == false) {	
					//별이 반쯤 켜질때 O
							Debug.Log("TestTurnOn");
							light.enabled=true;
							stellarCollider.enabled=false;
							stellar.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.3f);
							stellar.GetComponent<SpriteRenderer>().enabled = true;
					}

					else if (Input.GetMouseButtonUp(0) && hit.collider.gameObject==sphereCollider && turnOn == false)  {
					//별이진짜 켜질 때 O
					//마우스가 별에가서 터치하고 별을 떼었을 때 
						stellar.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
						stellar.GetComponent<SpriteRenderer>().enabled = true;
						stellarCollider.enabled = true;
						light.enabled=true;
						turnOn=true;
						Debug.Log("Turn On");
						//timeCount = 0;
					
					}
					//별을 지울 때 O
					else if(Input.GetMouseButtonUp(0) && hit.collider.gameObject==sphereCollider && turnOn == true){ 
						stellar.GetComponent<SpriteRenderer>().enabled = false;
						stellarCollider.enabled = false;
						light.enabled = false;
						turnOn = false; 
						Debug.Log("Delete");
						//timeCount = 0;
					}
					
					
					else if(Input.GetMouseButton(0) && hit.collider.gameObject!=sphereCollider && turnOn == false) {
						//마우스가 근처에도 없고 아무것도 안되었을 때 
						Debug.Log("TestTurnOff");
						stellar.GetComponent<SpriteRenderer>().enabled = false;
						stellarCollider.enabled = false;
						light.enabled=false; 
						//timeCount=0;
						}
					}
				}

    }




        

		/* 
        else if (Input.GetMouseButtonUp(0)){


            star.GetComponent<Renderer>().enabled = false;

            grid.SetActive(false);
            if (goReady)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit)){
                    if (hit.collider.gameObject.tag == "Record")//&& Input.GetMouseButtonDown(0))
                    {
                        //hit.point = new Vector3 (hit.point.x, 0.5f, hit.point.z);
                        //GameObject instance = Instantiate(initiateGO,hit.point,Quaternion.identity);
                        //instance.transform.parent = center.transform;
                    
                    }
                    else if (hit.collider.gameObject.tag == "Star"){

                        if (Physics.Raycast(ray, out hit, 1000.0f) && Input.GetMouseButtonUp(0)) // On left click we send down a ray
                            Destroy(hit.collider.gameObject); // Destroy what we hit
                    }
                }
            }
			*/

