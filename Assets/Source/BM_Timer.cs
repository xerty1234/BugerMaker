using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임시간을 알려주고 각 시간에 따른 이벤트를 알려주는 스크립트

public class BM_Timer : MonoBehaviour {

    public float Timer;
    public float CreateTimer;
    Text textTimer;


    // 시간을 체크하는 함수
    public float GetTimer ()
    {
        Timer += Time.deltaTime;
        textTimer = GetComponent<Text>();
        textTimer.text = string.Format("{0:N0}", Timer);

        return Timer;
    }

    // 시간을 체크하여 일정시간이 되었을때 1을 리턴하여 버거의 생성을 알려주는 함수
    public int check_BugTime ()
    {
        int index;
        index = (int)(Timer % CreateTimer + 1);
        if (CreateTimer == index)
            return 1;
        else
           return 0;
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
