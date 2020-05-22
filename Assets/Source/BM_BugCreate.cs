using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 각 버거의 오브젝트를 가지고 있고 사용자의 값을 받아서 버거를 변형시켜주는 스크립트
// 테스트이빈다.
public class BM_BugCreate : MonoBehaviour {

    
    //public GameObject []  BugStack;


    // 2018.07.11 현재 사용하고 있지 않음
    //public void Create_Order()
    //{

    //    //변수를 접근하기 위한 오브젝트 변수
    //    GameObject tempObject;
    //    // 위치값 저장을 위한 임시 변수
    //    Vector3 temp;
    //    temp.x = 0;
    //    temp.y = 150;
    //    temp.z = 0;


    //    //Count 변수에 숫자에 따른 생성
    //    tempObject = Instantiate(BugStack[0], Vector3.zero, Quaternion.identity);

    //    //캔버스를 부모로 설정해주는 부분 이 문장을 넣어야 canvars 위치값으로 설정이 가능하다.
    //    tempObject.transform.SetParent(transform);

    //    // 위치값을 설정해 준다.
    //    tempObject.GetComponent<RectTransform>().localPosition = temp;
    //    // 크기를 설정해준다.
    //    tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);


    //}


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
