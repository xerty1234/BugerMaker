using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임시간을 알려주고 각 시간에 따른 이벤트를 알려주는 스크립트

public class BM_Timer : MonoBehaviour {

    public float Timer;
    public float CreateTimer;
    float currentTimer;
    float PlayTimer = 0;
    float bugkerTime;
    Text textTimer;


    // 시간을 체크하는 함수
    public float GetTimer ()
    {
        bugkerTime += Time.deltaTime;
        if (bugkerTime > Timer)
        {
            PlayTimer++;
            currentTimer++;
            bugkerTime = 0;
           
        }
        textTimer = GetComponent<Text>();
        textTimer.text = string.Format("{0:N0}", currentTimer);

        return PlayTimer;
    }
    
    public void resetTime () { PlayTimer = 0f; }
    
    // 체크되는 시간을 저장 했다가 
    /* 2018.02.13
     * 시간 함수의 문제점 발견
     * 게임시간을 체크하는 함수를 다시 만들어야 한다고 생각한다.
     * order timer은 버거의 생성 10을 왔다갔다 하면서 10이되면 1을 리턴한다.
     * 2018.03.19 구현사항
     * 버거를 나왔다 안나왔다 만들지만 로직이 바뀌어야 함  버거 생성 -> 버거가 사라지지 않음
     *  -> 버거를 맞추면 버거 체인지 -> 다 맞추면 버거 제거 -> 새로운 버거 생성 ( 일정시간이
     *  되어도 버거가 완성되지 않으면 변수 PlayTime 변수를 만들어서 이 값을 제거 (초기값100 0이되면 게임종료)
     * 
     * */
    // 시간을 체크하여 일정시간이 되었을때 1을 리턴하여 버거의 생성을 알려주는 함수
    // 변경
    /*
    public int check_BugTime (int mode)
    {
        int temp;
        float tempTimer;

        if (mode == 1) tempTimer = CreateTimer;
        else
            tempTimer = PlayTimer;


        temp = (int)(OrderTimer % tempTimer) + 1;
        if (tempTimer <= temp)
        {
            OrderTimer = 0.0f;
            return 1;
        }
        else
            return 0;
    }
    */



    public bool check_BugTime()
    {
        float currentTimer = GetTimer();
        if (CreateTimer <= currentTimer)
        {
            Debug.Log("버거크리에이트");
            resetTime();
            return true;
        }
        else
            return false;

    }


    // Use this for initialization
    void Start () {

     
   
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetTimer();
    }
}
