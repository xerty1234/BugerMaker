using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 버거 메이커 소스 업데이트
/*
 * 2018.03.20
 * START_GAMESTATE 변수 추가 버거 노드가 일정시간이 넘어갔는데도 버거가 사라지지 않은 경우
 * 버거GameStateValue 를 감소 시켜서 0으로 만들면 게임이 오버 되도록 만드는 클래스
 * (추가사항): 지금은 버거 생성->일정시간뒤 -> setReduce() 이지만 일정시간이 너무 길고
 * 버거 생성 매커니즘이 바뀌지 않았으니 다시 생각해보아야 한다.
 */

public class BM_GameManger : MonoBehaviour {

    // 게임이 시작되면 처음으로 가지고 있는 변수값
    const int START_GAMESTATE = 100;
    // 값을 가지고 있는 변수
    private int GameStateValue;

    // 처음 게임이 시작될때 가지고 있는 값
    public void setGameStart () { GameStateValue = START_GAMESTATE; }
    // 버거가 일정시간이 되도록 사라지지 않을때 호출하는 메서드
    public void setReduce(int ReducePower) { GameStateValue -= ReducePower; }
    // 버거가 다 만들어지고 성공적으로 배달되면 호출하는 메서드
    public void setIncrease(int IncreasePower) { GameStateValue += IncreasePower; }
    // 변수의 값을 호출하는 호출 메서드
    public void printGameStateValue() { Debug.Log(GameStateValue); }



    // Use this for initialization
    void Start ()
    {
        // 게임이 시작될때 불러온다.
        setGameStart();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
