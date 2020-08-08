using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/********************************************************************************
* @classDescription 버거 애니메이션 스크립트
* @author LTS Corp.
* @version 1.0
* -------------------------------------------------------------------------------
* Modification Information
* Date              Developer           Content
* ----------        -------------       -------------------------
* 2020/05/24        이태섭              신규생성
* 
* -------------------------------------------------------------------------------
* Copyright (C) 2020 by LTS Corp. All rights reserved.
*********************************************************************************/

/*
 * 2018.07.03 
 * Animation 딜레이 변수
 * 애니메이션 중에 입력이 발생하면 오류가 나기 때문에 오류 방지 락 함수
 * DeleTime 만큼의 딜레이를 주어서 애니메이션 효과를 준다.
 */

public class BM_AnimationController : MonoBehaviour
{

    private bool AnimationLook;
    private bool startTime;
    private float DeleTime = 0.2f;
    private float currentTime = 0.0f;


    private bool isMistake = false;
    private bool isOrder_AnimationStart = false;
    private float Order_AnimationTime = 0.5f;
    private float Order_currentTime = 0.0f;


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
   
    
    public void Order_AnimationON() { isMistake = true; }
    public void Order_AnimationOFF() { isMistake = false; }
    public bool isOrder_Animation() { return isMistake; }
    public bool IsOrder_AnimationStart() { return isOrder_AnimationStart; }

    // Use this for initialization
    void Start ()
    {
        AnimationLook = false;
        startTime = false;
    }


    void nodeAnimation ()
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
                currentTime = 0.0f;
                startTime = false;
                AnimationLookOFF();
            }
        }

    }


    // 다른 것이 입력되었을 경우 사용되는 애니메이션
    void Order_Animation ()
    {
        
        if (isOrder_Animation() == true)
        {
            if (isOrder_AnimationStart == false)
            {
                Order_currentTime = Time.time + Order_AnimationTime;
                isOrder_AnimationStart = true;
            }

          

            if (Time.time > Order_currentTime)
            {
                Order_currentTime = 0.0f;
                isOrder_AnimationStart = false;
                Order_AnimationOFF();
            }
        }
    }

    void orderAnimation ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
       nodeAnimation();
       Order_Animation();

    }
}
