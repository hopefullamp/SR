using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstChanger : MonoBehaviour {


	public Sensor stellar; 
	public int instNum = 0;


	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0))
		{
				//서브레코드를 가져올경우 기존의 악기 데이터를 보존해야한다. 

				//1. 메인레코드만 악기를 바꿀 수 있다. 
				//2. 처음 서브레코드에서 가져온 악기는 그대로 보존이 된다. (바뀌지 않는다.)
				//3. 메인레코드가 서브레코드와 바뀐 경우에도 각각의 악기데이터가 보존되어야한다. 
				//4. 즉, 악기데이터는 각각의 레코드 (혹은 스텔라)가 가지고 있어야함을 뜻한다. 

				//메인레코드를 어떻게 구별할 것인가와, 
				//악기번호를 어떻게 저장하고, 바꿔줄 것인가가 관건인듯하다. 

				//이 스크립트는 그저 '버튼' 장치로서만 존재해야할 듯 싶다. 
				//악기번호는 메인레코드의 스텔라에서 여기의 instNum 이 바뀌었을 경우에만 
				//바뀌도록해야한다. 

				//단 그러면 문제가 생기는데, 평소 스텔라들은 안켜져있을 경우 
				//대부분 꺼져있기 때문에 각 레코드의 고유한 악기 변수를 만들어주어야한다. 

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hitInfo;
				if (Physics.Raycast(ray, out hitInfo))
				{
					if (hitInfo.collider.gameObject.tag == "Inst1"){
						instNum = 0;
						//메인레코드에만 바뀌는 것은 따로 해야할 듯 하다. 
					}
					else if (hitInfo.collider.gameObject.tag == "Inst2"){
						instNum = 1;
						//메인레코드에만 바뀌는 것은 따로 해야할 듯 하다. 
					}
					else if (hitInfo.collider.gameObject.tag == "Inst3"){
						instNum = 2;
						//메인레코드에만 바뀌는 것은 따로 해야할 듯 하다. 
					}
					else if (hitInfo.collider.gameObject.tag == "Inst4"){
						instNum = 3;
						//메인레코드에만 바뀌는 것은 따로 해야할 듯 하다. 
					}

					else if (hitInfo.collider.gameObject.tag == "Inst5"){
						instNum = 4;
						//메인레코드에만 바뀌는 것은 따로 해야할 듯 하다. 
					}

					else if (hitInfo.collider.gameObject.tag == "Inst6"){
						instNum = 5;
						//메인레코드에만 바뀌는 것은 따로 해야할 듯 하다. 
					}

					//if (instNum != instNum){ //악기가 바뀌었을 경우에만 해당레코드의 악기를 변경한다. 
						//stellar.selectInst = instNum;
						//Debug.Log("Changed");
					//}
					
				}
	
        }
	}		
}
