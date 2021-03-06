﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************
* @classDescription 버거 생성 스크립트
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



// 각 버거가 어떤 버거가 생성이 되어야 하는지 알려주는 함수

public class BM_Making_Bug : MonoBehaviour {

    public int Bugker_Count;
    public int[] Normal_Bugker;
    public int[] Steak_Bugker;
    public int[] Pineapple_Bugker;
    public int[] Bacon_Bugker;

    //const int MAX_BUGKER_TYPE = 4 ;
    //const int MAX_BUGKER_COUNT = 6;

    // 버거노드를 체크하는 배열 
    static int[] checkBugArray;
    static int checkIndex;

   
    // 버거 오브젝트의 배열 (버거 오브젝트를 바꾸는 로직 제작0
    // 2018.03.19
    public GameObject[] Normal_Bugker_obj;
    public GameObject[] Steak_Bugker_obj;
    public GameObject[] Pineapple_Bugker_obj;
    public GameObject[] Bacon_Bugker_obj;




    static int StopBugOrder;

    public void moveCheckindex()   {checkIndex++;}
    public void resetCheckindex()  { checkIndex = 0;}
    public int  getCheckindex()     { return checkIndex; }
    public void demoveCheckindex() { checkIndex--; }
    public int getMAXcheckBugArray() { return checkBugArray.Length; }

    //public int getcheckBugArray_Length() { return checkBugArray.Length; }

    // 노드들을 탐색해서 버거를 만들수 있는가??
    // 버거를 탐색을 한 다음 해당 버거의 첫번째를 이미지를 띄운다.
    // 유저가 노드를 누르면 해당 노드의 번호를 받고 이미지를 교체한다.
    // 유저가 버거 노드를 잘못 입력하면 해당 버거 스택은 가만이 있고 노드만 사라진다.
    // 버거를 완성하면 버거를 사라지게 만들고 점수가 올라가고 처음 루틴으로 돌아간다.





    // 버거를 찾아서 버거 노드와 맞으면 인덱스 노드를 1증가 시키고 true를 반환한다.
    public void check_select_bug (int tagNum)
    {

        // 버거를 다 맞춘다음 버거를 삭제하고 
        if (checkBugArray == null) {return;}
        if (checkIndex >= checkBugArray.Length - 1)
        {
            return;
        }

        if (checkBugArray[checkIndex] == tagNum)
        {
            moveCheckindex();
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Change_bugOrder(checkIndex);
        }

        else
        {
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Mistake_BugOrder(checkIndex);
            return;
        }


    }


    int[] GetSelect_Bugker(int Num)
    {
        switch(Num)
        {
            case 0: return Normal_Bugker;        
            case 1: return Bacon_Bugker;    
            case 2: return Pineapple_Bugker;    
            case 3: return Steak_Bugker;    
            default:  return null; 
        }
       
    }


    public GameObject[] getSelect_BugCreate ( int index)
    { 
        switch (index)
        {
            case 0:  return Normal_Bugker_obj;
            case 1:  return Bacon_Bugker_obj;
            case 2:  return  Pineapple_Bugker_obj;
            case 3:  return Steak_Bugker_obj;
            default: return null;
        }
    }

    int Select_Bugker ()
    {

        int temp;
        int[]  CreateBug  = new int[Bugker_Count];

        temp = 100;

        for (int i=0; i< Bugker_Count; i++)
        {
            CreateBug[i] = 0;
        }
      
        for (int i=0; i< Bugker_Count; i++)
        {
            CreateBug[i] = Order_Bugker(GetSelect_Bugker(i));
        }

        while(true)
        {
            temp = Random.Range(0, 3);
            if (CreateBug[temp] != 0) {return temp;}
        }

        //return temp;
    }

    public int Order_Bugker (int [] Bugker)
    {
      
        int temp;
        int NodeSize;
        int Count;

        List<int> Search_BugNode;

        temp = 0;
        Count = 0;

        // 버거 노드 탐색 문
        // 버거 노드의 리스트화 (스택 처럼 사용)
        Search_BugNode = new List<int>();


        // 버거 노드를 전부 순회하기 위한 사이즈 
        NodeSize = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node.Count;

        
        // 완성된 버거의 노드를 저장하는 문장
        for (int i = 0; i < Bugker.Length; i++)
        {
            Search_BugNode.Add(Search_BugNode[i]);
            if (Search_BugNode[i] == 0)
            {
                Count++;
            }

        }

        if (Count <= 6)
        {
            return 0;
        }

        // 버거 노드를 순회하면서 해당 버거가 만들어져도 되는지 노드를 순회하여 알아보는 문장
        for (int i=0; i<NodeSize; i++)
        {
            // 해당 노드의 변수를 알아오는 함수
            temp = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node[i].GetComponent<BM_Button_Mgr>().NodeNum;
            for (int j=0; j< Search_BugNode.Count; j++)
            {
                // 같이 같다면 해당 변수를 지워준다.
                if (temp == Search_BugNode[j])
                {
                    Search_BugNode.RemoveAt(j);
                }
            }
        }

        // 만들어저도 된다면 모든값이 지워짐으로 Count는 0이된다.
        if (Search_BugNode.Count == 0){ return 1;}

        // 노드값이 있으면 Count가 0이 아님으로 0을 리턴한다.
        else {return 0;}
            
    }

    // Use this for initialization
    void Start ()
    {
     
    }
  
       // 버거를 생성하는 함수
    public void Increase()
    {
        int temp, index;
        temp = GameObject.Find("BackGround").GetComponent<Create_Bugker>().getBM_OrederMAXindex();
        index = Random.Range(0, temp);
        //Debug.Log("index = " + index);
        GameObject.Find("BackGround").GetComponent<Create_Bugker>().Create_Order(index);

        Debug.Log("Increase()실행");
        checkBugArray = GetSelect_Bugker(index);
        resetCheckindex();
    }


    // 버거가 이미 생성 되어있다면 Reduce
    // 생성이 되지 않았다면 Increase를 생성해
    // 주문을 받는다.
    void CreateOrderBug ()
    {
        if (StopBugOrder != 1)
        {
            StopBugOrder = 1;
            Increase();
        }

       else
        {
            Reduce();
        }

    }

    void DelectOrderBug()
    {
        if (StopBugOrder != 0) {StopBugOrder = 0;}
    }

    void Reduce()
    {
        GameObject.Find("Screen").GetComponent<BM_GameManger>().setReduce(1);

    }

    void Update()
    {
        if (GameObject.Find("BM_Timer").GetComponent<BM_Timer>().check_BugTime())
        {
            CreateOrderBug();
        }
    }
}
