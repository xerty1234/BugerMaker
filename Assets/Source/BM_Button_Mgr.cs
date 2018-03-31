using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 각 버거 노드의 생성, 삭제 담당하는 스크립트

public class BM_Button_Mgr : MonoBehaviour
{

    public int NodeNum;


    // 버튼이 선택 될시 해당 버튼 노드 삭제와 노드 위치 변경 및, 새로운 노드 생성을 담당하는 함수
    public void Select_Button()
    {
        Vector3 temp;
        Vector2 Result;
        bool isAnimation = false;


        temp = this.GetComponent<RectTransform>().localPosition;
        Result = GameObject.Find("BackGround").GetComponent<Create_Bugker>().Check_Button(temp);

      //  isAnimation = GameObject.Find("BackGround").GetComponent<Create_Bugker>().getAniState();
      //  if (isAnimation == false)
      //      return;

        // 여기서 버거의 노드를 정리하는 문장을 만드러야 한다.
        Debug.Log(Result);

        // 클릭된 버거를 삭제하는 함수 (클릭된 위치정보)   
        Remove_BugNode(Result);
        Change_of_location(Result);

        // 여기에 버거가 맞는 노드인가를 체크하는 문장이 필요!
        /* 버거 체크 배열이 있는가??  2018.02.12
         *
         */

        GameObject.Find("BackGround").GetComponent<BM_Making_Bug>().check_select_bug(NodeNum);
        

      

    }

    // 클릭된 버거를 삭제하는 함수 
    void Remove_BugNode(Vector2 BPos)
    {
        int x, y = 0;
        int temp;

        x = (int)BPos.x;
        y = (int)BPos.y;

        temp = GameObject.Find("BackGround").GetComponent<Create_Bugker>().Saarch_Bug(x, y);

        // 오류가 나오게 되면 1000을 리턴함으로 오류 문장 삽입 예정
        if (temp == 1000)
            return;

        else
        {
            // 노드를 삭제하는 함수
            Destroy(GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node[temp]);
            // 노드를 리스트에서 제거하는 함수
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node.RemoveAt(temp);
            // 어떤 노드가 삭제되어서 그 값을 삭제해주는 함수
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Count_Delete_BugNode(NodeNum);


        }

    }



    // 버거의 위치를 바꾸어주는 함수
    void Change_of_location(Vector2 Pos)
    {

        int x, y;
        int index;
        x = (int)Pos.x;
        y = (int)Pos.y;

        // 어떤 노드가 생성이 되어야 하는지 알려주는 문장
        index = GameObject.Find("BackGround").GetComponent<Create_Bugker>().Create_Node_generator();

        if (y == 0)
        {
            // 첫번째 노드가 눌렸을때 첫번째 자리에 노드 생성
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Create_Bug_Node(x, y, index);
        }

        // 첫번째가 아닌 노드가 눌렸을때
        else
        {
            // 노드 생성
            GameObject.Find("BackGround").GetComponent<Create_Bugker>().Create_Bug_Node(x, 0, index);

            // 그리고 노드의 자리를 이동해준다.
            for (int i = y; i > 0; i--)
            {
                GameObject.Find("BackGround").GetComponent<Create_Bugker>().Change_Bug(x, i);

            }
        }

    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
