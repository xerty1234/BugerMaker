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
    public int Start_Width;
    //버거 노드의 시작 세로 위치
    public int Start_Height;
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
        aButton_Pos = new Vector3[MAX_Width, MAX_Height];
        int index = 0;
        int Count = 0;



        // 게임이 시작과 동시에 배열안에다가 각 위치의 값을 넣어준는 for문
        for (int i = 0; i < MAX_Width; i++)
        {
            index = 0;
            // 각 배열의 값을 넣어주는 부분 
            aButton_Pos[i, index].x = Start_Width;
            aButton_Pos[i, index].y = Start_Height;
            aButton_Pos[i, index].z = 0;

            //for 문이 진행되면서 위치값이 변화하기 때문에 변형된 값을 처리하는 부분 (가로)
            Start_Width = Start_Width + W_length;

            for (index = 0; index < MAX_Height; index++)
            {
                // 각 배열의 값을 넣어주는 부분
                aButton_Pos[i, index].x = Start_Width;
                aButton_Pos[i, index].y = Start_Height;
                aButton_Pos[i, index].z = 0;

                //for 문이 진행되면서 위치값이 변화하기 때문에 변형된 값을 처리하는 부분 (세로)
                Start_Height = Start_Height - H_length;
            }
        }


        // 버거노드의 가로의 값만큼 생성
        for (int i = 0; i < MAX_Width; i++)
        {

            index = 0;

            // node의 값을 복사 생성 (기존의 노드값을 복사)
            //Instantiate(childrenPrefab).transform.SetParent(transform)
            // UI를 복사하기 위하여, (그냥 복사를 하게되면 이미지가 보이지 않는다)
            // canvars 객체의 및에 있어야 이미지가 보이게 됨으로 현 캔버스 위치에 있는 복사 원본의 위치값 또한 같이 복사해준다.
            Vector3 temp;
            temp.x = Start_Width;
            temp.y = Start_Height;
            temp.z = 0;
            Instantiate(BM_original_Node[index], temp, Quaternion.identity).transform.SetParent(transform);
            

            //Instantiate(temp, aButton_Pos[i, index], Quaternion.identity);
            // count의 값을 증가함으로써 node의 값을 변형시키기위한 인덱스 변수 증가
           // Count++;

            // 버거노드의 세로의 값만큼 생성
          //  for (index = 0; index < MAX_Height; index++)
          //  {
                // node의 값을 복사 생성 (기존의 노드값을 복사)
          //      Instantiate(BM_original_Node[index], aButton_Pos[i, index], Quaternion.identity).transform.SetParent(transform);
                // count의 값을 증가함으로써 node의 값을 변형시키기위한 인덱스 변수 증가
          //      Count++;
          //  }
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
