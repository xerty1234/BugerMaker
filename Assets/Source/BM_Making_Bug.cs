using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Making_Bug : MonoBehaviour {

    public int Bugker_Count;
    public int [] Steak_Bugker;
    public int [] Pineapple_Bugker;
    public int [] Bacon_Bugker;
    public int [] Normal_Bugker;

    // 노드들을 탐색해서 버거를 만들수 있는가??
    // 버거를 탐색을 한 다음 해당 버거의 첫번째를 이미지를 띄운다.
    // 유저가 노드를 누르면 해당 노드의 번호를 받고 이미지를 교체한다.
    // 유저가 버거 노드를 잘못 입력하면 해당 버거 스택은 가만이 있고 노드만 사라진다.
    // 버거를 완성하면 버거를 사라지게 만들고 점수가 올라가고 처음 루틴으로 돌아간다.




    public int Order_Bugker (int [] Bugker)
    {
      
        int temp;
        int NodeSize;

        List<int> Search_BugNode;

   
        temp = 0;

        Search_BugNode = new List<int>();

    
        NodeSize = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node.Count;


        for (int i = 0; i < Bugker.Length; i++)
        {
            Search_BugNode.Add(Search_BugNode[i]);

        }

        for (int i=0; i<NodeSize; i++)
        {
            temp = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node[i].GetComponent<BM_Button_Mgr>().NodeNum;
            for (int j=0; j< Search_BugNode.Count; j++)
            {
                if (temp == Search_BugNode[j])
                {
                    Search_BugNode.RemoveAt(j);
                }
            }
        }

        if (Search_BugNode.Count == 0)
            return 1;
        else
            return 0;
            
    }


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
