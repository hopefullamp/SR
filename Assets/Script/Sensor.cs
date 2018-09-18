﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {

	public ParticleSystem explosionParticle;
	//AudioSource audioData;
	public AudioSource audioSource;


	public int selectInst = 0;
    //이 inst 데이터를 외부에서 관리해주는게 아니라 
    //star 자체에서 외부 데이터를 이름으로 찾아서 
    //직접 찾아서 이 변수를 정해주어야한다. 
    //안그럼 바뀌지 않는다. 

    //public Collider collider;

 	public AudioClip[] note;
	public AudioClip[] note2;
	public AudioClip[] note3;
 	private AudioClip noteClip;
	
	public Vector3 center;
    public Vector3 record;

	int index;
	int clip;



    float dist = 0f;


	//public Transform center;
	//public Vector3 center = new Vector3 (0,0.5f,0);
	//private Vector3 centerPosition = head.position;
	//ㄴ 무수한 실패의 흔적들... (좌표나 설정등이 바뀌면 효율성이 떨어진다 생각해서 안씁니다)


	void Start()
	{
        //collider = GetComponent<Collider>();

        //audioData = GetComponent<AudioSource>();
        //중앙 및 반지름 계산
        //중앙으로부터의 별의 거리 
        //를 환산하여 얻은 그에 맞는 노트 데이터 
        dist = Vector3.Distance(center, transform.position);
        center = GameObject.FindGameObjectWithTag("Center").transform.position;
        record = GameObject.FindGameObjectWithTag("Record").transform.localScale;
        //Debug.Log("Record : "+record);
    }

    void Update()
    {

        Calculation();
        if (dist == (int)dist && dist != 0)
        {
            //Debug.Log("Sound");
            //SelectNote();
        }


        //SelectNote();

        //Test Sound 

        //Debug.Log("clip : "+clip);

        //Debug.Log("center : "+center);
        //Debug.Log("outline : "+record/2);
        //Debug.Log("radius : "+radius);
        //Debug.Log("distance : "+dist);
        //레코드와 센터의 Y값을 갖게 설정해주어야한다. 

        //변수 자체를 우선 랜덤으로 지정 
        // ㄴ 여기서 거리에 따라 계산을 할 수 있도록 계산하자. 
        // 중심과 거리의 차이(terminate)를 이용하여 
        // 값을 배분하도록 한다. 
        // if 를 사용하면 노가다를 해야하므로 
        // terminate 와 leghth 의 비율을 이용하여 
        // 깔끔한 정수 값 (버림 혹은 올림) 을 얻어낸다. 




     
    }

    //노가다 방식으로 결정! 
    // - 사유 1. 오브젝트 용량이 무거워져 과부하가 걸릴 가능성이 있음. 
    // - 사유 2. 오브젝트에서 멀티스레드로 너무 많은 데이터를 처리해야할 가능성. 

    //노가다 방식의 알고리즘 

    // 온트리거를 발동시킬 때마다 
    // '별에서' 중심으로부터의 거리를 계산한다.
    // 그에 따라 음을 재생한다. 각 고유한 소리를 재생시키게한다. 

    // 그럼 겹칠 일도 없으며 온전히 소리가 재생된다. 


    void Calculation(){

        record.y = 0;
        record.x = 0;
        center.y = 0;

        float radius = Vector3.Distance(center, record / 2);
        //Debug.Log("Radius : "+radius);

        float index = note.Length * dist / radius;
        //Debug.Log("index : "+index);

        if (dist > radius)
        {
            Destroy(gameObject);
        }
        clip = (int)index;

    }


    void OnTriggerEnter(Collider other){
		if(other.tag == "Head"){
			//Debug.Log("clip : "+clip);
			HitParticle();
		}
	}

	void OnTriggerStay(Collider other){
		if(other.tag == "Head"){
			//Debug.Log("clip : "+clip);
			SelectNote();
		}
	}

	void SelectNote(){

			audioSource = gameObject.GetComponent<AudioSource>();
			//noteClip = note[index];

			//여기에서 부터 악기선택에 따른 
			//배열을 정해주면 될 것 같다. 
			if(selectInst == 0){
				noteClip = note[clip];
			}
			else if(selectInst == 1){
				noteClip = note2[clip];
			}
			else if(selectInst == 2){
				noteClip = note3[clip];
			}

			//동일한 형식의 오디오 클립 데이터를 위에서 랜덤으로 지정  
			audioSource.clip = noteClip;
			//오디오 소스의 클립을 위의 클립으로 지정 
			audioSource.Play();
			//audioData.Play(noteClip);
	}

	void HitParticle(){
	
	Debug.Log("HitParticle!");
	//헤드에 부딪힐때마다 
	//Star에서 해당포지션에 파티클은 instance 
	//파티클은 Star에서 분리되고, 
	//파티클의 수명만큼 (혹은 임의의시간만큼)
	//재생한뒤 데스트로이 된다. 
	Instantiate(explosionParticle, transform.position, Quaternion.identity);
	explosionParticle.Play();
	explosionParticle.transform.parent = null;
	//Destroy(explosionParticle.gameObject,explosionParticle.duration);
	}
}
