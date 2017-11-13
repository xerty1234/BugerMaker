using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Create_Bugker : MonoBehaviour
{
    // 버튼의 값의 총
    const int MAX_BUTTON = 13;

    // 버거노드의 가로의 값을 저장하는 구문
    public int MAX_Width;
    // 버거노드의 세로의 값을 저장하는 구문
    public int MAX_Height;

    // 버거노드의 시작 가로 위치
    public float Start_Width;
    //버거 노드의 시작 세로 위치
    public float Start_Height;
    // 버거 노드간의 거리 가로
    public int W_length;
    // 버거 노드간의 거리 세로
    public int H_length;

    // 총 버거의 위치값을 저장하고 있는 배열
    Vector3[,] aButton_Pos;

    // 버거의 오브젝트를 저장하고 있는 오브젝트 행렬
    public GameObject [] BM_original_Node;

    //버거의 카피 오브젝트를 저장하고 있는 배열
    //public GameObject[] BM_Cpy_Node;

    int test = 0;


    int Create_BugNode ()
    {
        // 위치값 저정을 위한 Vector3 배열생성 
        aButton_Pos = new Vector3[MAX_Width, MAX_Height];
        //참조를 위한 인덱스 값 선언 (위치값 y)
        int index = 0;
        // 버거 노드의 생성을 위한 인덱스 값  (1씩 증가하면서 13까지 증가) 
        int Count = 0;

        float Last_Y_Pos = Start_Height;

        
        // 게임이 시작과 동시에 배열안에다가 각 위치의 값을 넣어준는 for문
        for (int i = 0; i < MAX_Width; i++)
        {
            // 인덱스 변수 초기화
            index = 0;
            // 기존에 변경되었던 변수 초기화
            Start_Height = Last_Y_Pos;


            for (index = 0; index < MAX_Height; index++)
            {
                // 각 배열의 값을 넣어주는 부분
                aButton_Pos[i, index].x = Start_Width;
                aButton_Pos[i, index].y = Start_Height;
                aButton_Pos[i, index].z = 0;

                //for 문이 진행되면서 위치값이 변화하기 때문에 변형된 값을 처리하는 부분 (세로)
                Start_Height = Start_Height - H_length;
            }

            //for 문이 진행되면서 위치값이 변화하기 때문에 변형된 값을 처리하는 부분 (가로)
            Start_Width = Start_Width + W_length;
        }


        // 버거노드의 가로의 값만큼 생성
        for (int i = 0; i < MAX_Width; i++)
        {
            //변수를 접근하기 위한 오브젝트 변수
            GameObject tempObject;
            // 위치값 저장을 위한 임시 변수
            Vector3 temp;

            // 저장해 놓았던 변수입력
            temp.x = aButton_Pos[i, 0].x;
            temp.y = aButton_Pos[i, 0].y;
            temp.z = 0;

            // 버거 노드의 세로의 값만큼 생성
            for (index = 0; index < MAX_Height; index++)
            {
                temp.x = aButton_Pos[i, index].x;
                temp.y = aButton_Pos[i, index].y;
                temp.z = 0;

                tempObject = Instantiate(BM_original_Node[Count], Vector3.zero, Quaternion.identity);

                //캔버스를 부모로 설정해주는 부분 이 문장을 넣어야 canvars 위치값으로 설정이 가능하다.
                tempObject.transform.SetParent(transform);

                // 위치값을 설정해 준다.
                tempObject.GetComponent<RectTransform>().localPosition = temp;
                // 크기를 설정해준다.
                tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);

                Count++;
                Count = Count % 13;

            }
        }
        return 1;


    }

        

	void Start ()
    {
        
      



    }
	
	// Update is called once per frame
	void Update ()
    {

        if (test == 0)
        {
            test = Create_BugNode();
        }

    }
}
