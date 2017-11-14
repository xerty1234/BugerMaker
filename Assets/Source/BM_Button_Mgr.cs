using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Button_Mgr : MonoBehaviour {



  

 

    // 버튼이 선택 될시 해당 버튼 노드 삭제와 노드 위치 변경 및, 새로운 노드 생성을 담당하는 함수
   public  void Select_Button ()
    {
        Vector3 temp;
        Vector2 Result;
        
      
        temp = this.GetComponent<RectTransform>().localPosition;
        Result = GameObject.Find("BackGround").GetComponent<Create_Bugker>().Check_Button(temp.x, temp.y);

        // 여기서 버거의 노드를 정리하는 문장을 만드러야 한다.
        Debug.Log(Result);

        // 클릭된 버거를 삭제하는 함수 (클릭된 위치정보)
        Remove_BugNode(temp);
        Change_of_location(Result);
    }

    // 클릭된 버거를 삭제하는 함수 
    void Remove_BugNode(Vector3 BPos)
    {
        // 버거들의 위치정보를 가지고 있는 임시변수
        Vector3 BugPos;
        // 리스트의 크기를 가지고 있는 임시변수 
        int NodeSize = 0;

        // 리스트의 크기를 가져오는 함수 
        NodeSize = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node.Count;

        // 리스트 사이즈 만큼 탐색을 한다.
        for (int i = 0; i < NodeSize; i++)
        {
            // 리스트를 탐색하여 위치값을 가져오는 문장
            BugPos = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node[i].GetComponent<RectTransform>().localPosition;

            // 만약 클릭한 사이즈와 노드의 값이 같다면 그 노드를 삭제시키는 문장
            if (BPos.x == BugPos.x && BPos.y == BugPos.y)
            {

                Destroy(GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node[i]);
                GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node.RemoveAt(i);
                return;
            }

        }
    }

    void Change_of_location(Vector2 Pos)
    {

        int x, y;
        x = (int)Pos.x;
        y = (int)Pos.y;

        if (y == 0)
        {
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Create_Bug_Node(x, y, 1);
        }

        else
        {
            for (int i=y; i==0; i--)
            {

            }
        }
        
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
