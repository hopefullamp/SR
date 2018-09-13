using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStar : MonoBehaviour {

     public GameObject goOne;
     public GameObject center;
     //public GameObject goTwo;
     public GameObject grid;
     public GameObject star; 
     

     bool goReady;
 
     GameObject initiateGO;
     int nextNameNumber = 0;

	/*
     public void SelectGameObjectOne() 
     {
         initiateGO = goOne;
         goReady = true;
     }
	
     public void SelectGameObjectTwo()
     {
         initiateGO = goTwo;
         goReady = true;
     }
	*/

	void Start(){
		initiateGO = goOne;
        goReady = true;
	}
 
    void Update () 
    {



        if (Input.GetMouseButton(0))
        {
            //return;
            if (goReady)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Record") //&& Input.GetMouseButtonDown(0))
                    {
                        grid.SetActive(true);


                        star.GetComponent<Renderer>().enabled = true;
                        //star.SetActive(true);
                        Debug.Log("TestStarActive");

                        star.transform.position = hit.point;


                        //hit.point = new Vector3 (hit.point.x, 0.5f, hit.point.z);
                        //GameObject instance = Instantiate(initiateGO,hit.point,Quaternion.identity);

                        //instance.transform.parent = center.transform;
                        //goReady = false;
                    }/*
                    else if (hit.collider.gameObject.tag == "Star")
                    {

                        if (Physics.Raycast(ray, out hit, 1000.0f) && Input.GetMouseButtonDown(0)) // On left click we send down a ray
                            Destroy(hit.collider.gameObject); // Destroy what we hit
                    }*/
                }
            }
        }
        else if (Input.GetMouseButtonUp(0)){

            //star.SetActive(false);

            star.GetComponent<Renderer>().enabled = false;

            grid.SetActive(false);
            if (goReady)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hit)){
                    if (hit.collider.gameObject.tag == "Record")//&& Input.GetMouseButtonDown(0)){

                        hit.point = new Vector3 (hit.point.x, 0.5f, hit.point.z);
                        GameObject instance = Instantiate(initiateGO,hit.point,Quaternion.identity);

                        instance.transform.parent = center.transform;
                        //goReady = false;
                    }
                    else if (hit.collider.gameObject.tag == "Star"){

                        if (Physics.Raycast(ray, out hit, 1000.0f) && Input.GetMouseButtonUp(0)) // On left click we send down a ray
                            Destroy(hit.collider.gameObject); // Destroy what we hit
                    }
                }
            }
        }
   
    /*
     void Update () 
    {
 
         if (Input.GetMouseButtonDown(0)){
             //return;
			if(goReady){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
             	{
					if (hit.collider.gameObject.tag == "Record")
                	{
						GameObject instance = Instantiate(initiateGO,hit.point,Quaternion.identity);
                        instance.name = "Star"+nextNameNumber;
                        nextNameNumber++;
                        Debug.Log("Make Star");
                        //goReady = false;
					}
                    
                    if (hit.collider.gameObject.tag == "Star"){
                        if(Physics.Raycast(ray,out hit, 1000.0f) && Input.GetMouseButtonDown (0)) // On left click we send down a ray
                        Destroy (hit.collider.gameObject); // Destroy what we hit
                    }
                    
				}
			}
		}
    }
    */

 }