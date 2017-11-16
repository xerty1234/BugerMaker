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
        Remove_BugNode(Result);
        Change_of_location(Result);
    }

    // 클릭된 버거를 삭제하는 함수 
    void Remove_BugNode(Vector2 BPos)
    {
        int x, y = 0;
        int temp;
        x = (int) BPos.x;
        y = (int) BPos.y;

       temp =  GameObject.Find("BackGround").GetComponent<Create_Bugker>().Saarch_Bug(x,y);

        // 오류가 나오게 되면 1000을 리턴함으로 오류 문장 삽입 예정
        if (temp == 1000)
            return;

        else
        {
            Destroy(GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node[temp]);
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node.RemoveAt(temp);

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
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Create_Bug_Node(x, 0, 1);
            for (int i=y; i>0; i--)
            {
                GameObject.Find("BackGround").GetComponent<Create_Bugker>().Change_Bug(x, i);

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
