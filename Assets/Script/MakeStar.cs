using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStar : MonoBehaviour {

     public GameObject goOne;
     public GameObject center;

     public GameObject grid;
     //public GameObject star; 
     

     bool goReady;
 
     GameObject initiateGO;
     int nextNameNumber = 0;



	void Start(){
		initiateGO = goOne;
        goReady = true;
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
            grid.SetActive(false);
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
                    else if (hit.collider.gameObject.tag == "Star"){

                        if (Physics.Raycast(ray, out hit, 1000.0f) && Input.GetMouseButtonUp(0)) // On left click we send down a ray
                            Destroy(hit.collider.gameObject); // Destroy what we hit
                    }
                }
            }
        }
    }
}