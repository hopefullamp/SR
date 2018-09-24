﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStar : MonoBehaviour {

    //public GameObject goOne;


 
    public GameObject center;
    public GameObject grid;
    public Transform star;
    public Transform StellarCenter;
    Vector3 Center;
    Vector3 Record;
    Vector3 StellarCenterScale;
    Vector3 StellarCenterPosition;

    //public Sensor sensor;

    bool goReady;
 
    //int nextNameNumber = 0;

	void Start(){
        goReady = true;
        float stellarCount = 15;
       
         
        Center = GameObject.FindGameObjectWithTag("Center").transform.position;
        Record = GameObject.FindGameObjectWithTag("Record").transform.lossyScale;
        StellarCenterScale = GameObject.FindGameObjectWithTag("StellarCenter").transform.lossyScale;
        StellarCenterPosition = GameObject.FindGameObjectWithTag("StellarCenter").transform.localPosition;


        Record.y = 0;
        Record.x = 0;
        Center.y = 0;

        float radius = Vector3.Distance(Center, Record / 2);
        Debug.Log("makeCenter : " + Center);
        Debug.Log("makeRecord : " + Record);
        Debug.Log("makeRadius : "+radius);

         for (int i = 0; i < stellarCount+1; i++)

         //높이를 -0.5 
        {//23 //23.1
            Vector3 xPosition = new Vector3 ((i+1)*radius/(stellarCount+1),0.5f/*높이*/,0.0f/*z*/);
            Debug.Log("xPosition: " + xPosition);
            //이 부분의 넓이를 최적화 할 수 있어야만, 서브레코드를 작동시킬 수 있다
            //공식에 문제가 없다면 왜 7.5f 였나 
            Quaternion rotation = Quaternion.Euler(90,0,0);
            if (i == stellarCount) {

            }
            else {
                Transform instance = Instantiate(star, xPosition, rotation);
                instance.transform.parent = StellarCenter.transform;

                float barCount = 32;
                for (int r = 0; r < barCount - 1; r++)
                {
                    //현재의 문제점 : 첫번째 for 문을 실행하는데에는 문제가 없으나 그 다음부터 값이 바뀌어 버린다  
                    //분명 이 것은 각도를 회전하면서 생기는 문제임이 분명하다 (아마 그렇게 되는데에는 월드 스케일을 받는 이유가 클 것이다) 

                    Quaternion rotation2 = Quaternion.Euler(0, (r + 1) * 360 / barCount, 0);

                    Transform instance2 = Instantiate(StellarCenter, new Vector3(0, 0, 0), rotation2);
                    Debug.Log("instance2 : " + instance2.transform);
                    //instance2.transform.parent = center.transform;
                    //instance2.transform.parent = StellarCenter.transform;
                }

            }
        }


        
        
        /* 
        for(int x=1;x>15;x++){

            Vector3 xPosition = new Vector3 (x*radius/16,1.0f,0.0f);
            GameObject instance = Instantiate(star,xPosition,Quaternion.identity);
            //Instantiate(star,xPosition,Quaternion.identity);
            instance.transform.parent = center.transform;

            for(int r=0;r<16;r++){

            }
        
        */
    }
 
    void Update () 
    {



        if (Input.GetMouseButton(0))
        {
            
            if (goReady)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Record") //&& Input.GetMouseButtonDown(0))
                    {
                        //grid.SetActive(true);
                        
                        
                        
                    }

                }
            }
        }
        else if (Input.GetMouseButtonUp(0)){


            //star.GetComponent<Renderer>().enabled = false;
            //grid.SetActive(false);
            if (goReady)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit)){
                    if (hit.collider.gameObject.tag == "Record")//&& Input.GetMouseButtonDown(0))
                    {

                        //grid.SetActive(false);
                        //hit.point = new Vector3 (hit.point.x, 0.5f, hit.point.z);
                        //GameObject instance = Instantiate(initiateGO,hit.point,Quaternion.identity);
                        //instance.transform.parent = center.transform;
                    }
                    /*
                    }
                    else if (hit.collider.gameObject.tag == "Star"){

                        if (Physics.Raycast(ray, out hit, 1000.0f) && Input.GetMouseButtonUp(0)) // On left click we send down a ray
                            Destroy(hit.collider.gameObject); // Destroy what we hit
                    }
                    */
                }
            }
        }
    }
}
