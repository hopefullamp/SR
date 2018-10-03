using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording : MonoBehaviour {

private bool switched = false;
private int touched = 0;


    void Start() {
        Everyplay.IsSupported();
    }

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "REC")
                {
                    if (switched == true){
                        switched = false;
                        touched = 0;
					Everyplay.StopRecording();
                    Debug.Log("Record Stop");
					//토글을 끈다  
					}

					else if (switched == false){
                        switched = true;
                        touched = 1;
					//토글을 켠다  
                    Everyplay.Initialize();
					Everyplay.StartRecording();
                    Debug.Log("Record Start");
                    }
                }
            }
        }

        if (touched == 1){
			//토글이 켜진 경우 
           
        }
		if (touched == 0){
			//토글이 꺼진 경우 

		}

	}
}
