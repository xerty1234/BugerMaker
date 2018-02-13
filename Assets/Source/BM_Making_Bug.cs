using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 각 버거가 어떤 버거가 생성이 되어야 하는지 알려주는 함수

public class BM_Making_Bug : MonoBehaviour {

    public int Bugker_Count;
    public int[] Normal_Bugker;
    public int [] Steak_Bugker;
    public int [] Pineapple_Bugker;
    public int [] Bacon_Bugker;

    public int [] Null_Bugker;

    public GameObject[] Bugker;
    static int StopBugOrder;
    
    // 노드들을 탐색해서 버거를 만들수 있는가??
    // 버거를 탐색을 한 다음 해당 버거의 첫번째를 이미지를 띄운다.
    // 유저가 노드를 누르면 해당 노드의 번호를 받고 이미지를 교체한다.
    // 유저가 버거 노드를 잘못 입력하면 해당 버거 스택은 가만이 있고 노드만 사라진다.
    // 버거를 완성하면 버거를 사라지게 만들고 점수가 올라가고 처음 루틴으로 돌아간다.


    int[] GetSelect_Bugker(int Num)
    {
        switch(Num)
        {
            case 0: return Normal_Bugker;        
            case 1: return Pineapple_Bugker;    
            case 2: return Bacon_Bugker;    
            case 3: return Steak_Bugker;    
            default:  return Null_Bugker; 
        }
       
    }

    public void Select_BugCreate ( int index)
    {
        switch(index)
        {
            case 0: GameObject.Find("Normal_Bugker").GetComponent<BM_BugCreate>().Create_Order(); break;
            case 1: GameObject.Find("Bacon_Bugker").GetComponent<BM_BugCreate>().Create_Order(); break;
            case 2: GameObject.Find("Steak_Bugker").GetComponent<BM_BugCreate>().Create_Order(); break;
            case 3: GameObject.Find("Pinapple_Bugker").GetComponent<BM_BugCreate>().Create_Order(); break;
            default: return;
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
            if (CreateBug[temp] != 0)
                return temp;
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
        if (Search_BugNode.Count == 0)
            return 1;
        // 노드값이 있으면 Count가 0이 아님으로 0을 리턴한다.
        else
            return 0;
            
    }



    // Use this for initialization
    void Start ()
    {
      

    }

    // Update is called once per frame
    /*
     * 시간의 의해서 버거 생성 완료
     * 크기 줄이는 것과, 한번만 실행되는것, 
     * 2018.02.08, 2018 02.12 추가(삭제루틴)
     * 삭제루틴 오류 201.02.12 (아직 고쳐지지 않았음)
     * 이태섭
     */


    void Update()
    {

        //2018.02.12 추가
        if (GameObject.Find("BM_Timer").GetComponent<BM_Timer>().check_BugTime() == 1
             && StopBugOrder == 0)
        {
            int temp, index;
            temp = GameObject.Find("BackGround").GetComponent<Create_Bugker>().getBM_OrederMAXindex();
           
            index = Random.Range(0, temp);
            Debug.Log("index = "+index);
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Create_Order(index);
            StopBugOrder = 1;
        }


          /*
         * 버거 삭제 루틴이 잘 되는지 테스트 
         */

        /*
        if (StopBugOrder == 1 
          && GameObject.Find("BM_Timer").GetComponent<BM_Timer>().getDelectBug() == true)
        {
            // 삭제루틴
            Debug.Log("버거 삭제 루틴");
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Delect_Order();
            StopBugOrder = 0;

        }
        */

    }
}
