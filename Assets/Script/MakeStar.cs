using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStar : MonoBehaviour {

    //public GameObject goOne;


    public Transform StellarCenter;
    public GameObject center;
    public GameObject grid;
    public Transform star;
    Vector3 Center;
    Vector3 Record;

    //public Sensor sensor;

    bool goReady;
 
    //int nextNameNumber = 0;

	void Start(){
        goReady = true;
        float stellarCount = 15;
       
        Center = GameObject.FindGameObjectWithTag("Center").transform.position;
        Record = GameObject.FindGameObjectWithTag("Record").transform.localScale;
        float radius = Vector3.Distance(Center, Record / 2);
       //Debug.Log("Radius : "+radius);
        
         for (int i = 0; i < stellarCount; i++)
        {//23 //23.1
            Vector3 xPosition = new Vector3 ((i+1)*radius/(stellarCount+7.5f),1.0f,0.0f);
            Quaternion rotation = Quaternion.Euler(90,0,0);
            Transform instance = Instantiate(star,xPosition,rotation);
            instance.transform.parent = StellarCenter.transform;
        }

        float barCount = 32;
        for (int r =0; r < barCount-1; r++){
            Quaternion rotation2 = Quaternion.Euler(0,(r+1)*360/barCount,0);
            Transform instance2 = Instantiate(StellarCenter,new Vector3(0,0,0),rotation2);
            instance2.transform.parent = center.transform;
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
