using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 2018.07.03 
 * Animation 딜레이 변수
 * 애니메이션 중에 입력이 발생하면 오류가 나기 때문에 오류 방지 락 함수
 * DeleTime 만큼의 딜레이를 주어서 애니메이션 효과를 준다.
 *
 */

public class BM_AnimationController : MonoBehaviour
{

    private bool AnimationLook;
    private bool startTime;
    private float DeleTime = 0.2f;
    private float currentTime = 0.0f;


    
    public void AnimationLookON()
    {
        AnimationLook = true;
        startTime = false;

    }

    public void AnimationLookOFF()
    {
        AnimationLook = false;        
    }

    public bool getAnimationLook()  {return AnimationLook;}
   

    



    // Use this for initialization
    void Start ()
    {
        AnimationLook = false;
        startTime = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (AnimationLook == true)
        {
            if (startTime == false)
            {
                currentTime = Time.time + DeleTime;
                startTime = true;
            }


            if (Time.time > currentTime)
            {
                // nextTime = Time.time + DeleTime;
                currentTime = 0.0f;
                startTime = false;
                AnimationLookOFF();
            }
        }
      
  
	}
}
