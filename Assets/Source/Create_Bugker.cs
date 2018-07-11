using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Button mgr과 연개하여 버튼의 애니메이션 첫번째 설정을 담당하는 함수
// BackGround 오브젝트에 연결되어있다.

public class Create_Bugker : MonoBehaviour
{


    bool CreateBugerComplete = false;
    bool isAnimation = false;
  
    public Vector3 localOrder;
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

    // 버거노드의 이동 스피드
    public int MoveSpeed_Animation;

    // 총 버거의 위치값을 저장하고 있는 배열
    public Vector3[,] aButton_Pos;

    public List<GameObject> LBug_Node;

    // 버거의 오브젝트를 저장하고 있는 오브젝트 행렬
    public GameObject[] BM_original_Node;

    //버거오더의 오브젝트를 저장하고 있는 오브젝트 실행
    public GameObject[] BM_Order;


    private GameObject swap_order;

    int[] NodeCount;

    private int select_orderNum;



    public List<GameObject> Order_List;


    public void AnimationEnd () { if (isAnimation != false ) isAnimation = false; }
    public void AnimationStart () { if (isAnimation != true) isAnimation = true; }
    public bool getAniState () { return isAnimation; }

    public void setselect_orderNum (int index) { this.select_orderNum = index; }
    public int  getselect_orderNum() { return this.select_orderNum; }
    public void reset_orderNum() { this.select_orderNum = 0; }

    // 버거 스위치함수
    public void Create_BugerComplete() { CreateBugerComplete = true; }
    public void Create_BugerStart ()   {CreateBugerComplete = false;}
    public bool isCreateBugerComplete() {return CreateBugerComplete; }



    // 버거의 위치이동할때 에니메이션을 위하여 만든 구조체
    // 위치값과 해당 노드의 인덱스
    struct AnimationNode
    {
        public int x;
        public int y;
        public int index;
    };

    // 에니메이션에 해당되는 노드들이 들어가있는 리스트 
    List<AnimationNode> ANode;

    // 주문 배열의 크기를 알아오는 함수 2018.02.12 LTS
    public int getBM_OrederMAXindex()  {
        int temp;
        temp = BM_Order.Length;
        return temp;
    }

    // 모든 노드에 값이 있으면 랜덤으로 하나를 생성하고
    // 노드에 값이 없으면 그 값을 생성 하는 함수
    public void Count_Add_BugNode(int index)
    {
        NodeCount[index] += 1;
    }

    // 노드의 값을 삭제하는 함수
    public void Count_Delete_BugNode(int index)
    {
        NodeCount[index] -= 1;
    }


    // 어떤 버거노드를 생성 할지를 결정하는 함수
    public int Create_Node_generator()
    {
        int temp;

        // 13개의 노드중에 없는것을 우선 찾고 그 값을 리턴해준다.
        for (int i = 0; i < MAX_BUTTON; i++)
        {
            if (NodeCount[i] == 0)
            {
                temp = i;
                return temp;
            }
        }
        // 만약 모든 값이 있다면 랜덤으로 값을 넣어준다.
        temp = Random.Range(0, 13);
        return temp;

    }

    // 버거의 위치로 포지션의 값을 구하는 함수 
    public Vector2 Return_Bug_Positon(int x, int y)
    {
        Vector2 temp;
        temp = new Vector2(0, 0);


        temp.x = aButton_Pos[x, y].x;
        temp.y = aButton_Pos[x, y].y;

        return temp;
    }

    // 버거노드가 체크되면 어디서 체크 되었는지를 반환하는 변수 (값이 있으면 값을 리턴 값이 없으면 0을 리턴)
    public Vector2 Check_Button(Vector3 target)
    {
        Vector2 temp = new Vector2(0, 0);
        int Width, height = 0;


        for (Width = 0; Width < MAX_Width; Width++)
        {
            for (height = 0; height < MAX_Height; height++)
            {
                // 체크가 되면 위치를 넘기고 함수를 종료한다.
                if (target.x >= aButton_Pos[Width, height].x - 5
                      && target.x <= aButton_Pos[Width, height].x + 5
                     && target.y >= aButton_Pos[Width, height].y - 5
                     && target.y <= aButton_Pos[Width, height].y + 5)
                {
                    temp.x = Width;
                    temp.y = height;
                    return temp;
                }
            }
        }


        // 만약 일치하는 것이 없으면 0을 리턴
        return temp;

    }

    // 버거를 생성하는 함수
    public void Create_Bug_Node(int Xindex, int Yindex, int Count)
    {
        //변수를 접근하기 위한 오브젝트 변수
        GameObject tempObject;
        // 위치값 저장을 위한 임시 변수
        Vector3 temp;

        temp.x = aButton_Pos[Xindex, Yindex].x;
        temp.y = aButton_Pos[Xindex, Yindex].y;
        temp.z = 0;

        //Count 변수에 숫자에 따른 생성
        tempObject = Instantiate(BM_original_Node[Count], Vector3.zero, Quaternion.identity);

        //캔버스를 부모로 설정해주는 부분 이 문장을 넣어야 canvars 위치값으로 설정이 가능하다.
        tempObject.transform.SetParent(transform);

        // 위치값을 설정해 준다.
        tempObject.GetComponent<RectTransform>().localPosition = temp;
        // 크기를 설정해준다.
        tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);

        // 버거의 노드를  리스트에 넣어준다.
        LBug_Node.Add(tempObject);

        // 버거노드가 얼마나 있는지를 판단하는 배열에 값을 넣어준다.
        Count_Add_BugNode(Count);

    }

    // 터치된 버거노드의 위치를 알려주는 함수 
    // 선택된 위치값과 원래의 위치값이 같으면 그 노드가 선택되어있는 것임으로 for로 서치해서 인덱스를 리턴해준다.
    public int Saarch_Bug(int Xindex, int Yindex)
    {
        // 노드의 사이즈 임시변수
        int NodeSize;
        //변환될 노드의 인덱스 임시변수
        int temp;
        // 비교할 위치값 (배열의 저장되어 있는 변수의 값으로 비교 ) 
        Vector3 BugPos;
        // 선택된 위치값 
        Vector3 BPos;

        // 비교 대상인 변수를 임시변수에 저장하는 부분
        BPos.x = aButton_Pos[Xindex, Yindex].x;
        BPos.y = aButton_Pos[Xindex, Yindex].y;
        BPos.z = 0;

        // 만약 서치가 되지 않으면 1000을 이용하여 오류체크
        temp = 1000;

        // 노드의 크기를 알아오는 함수
        NodeSize = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node.Count;


        // 리스트 사이즈 만큼 탐색을 한다.
        for (int i = 0; i < NodeSize; i++)
        {
            // 리스트를 탐색하여 위치값을 가져오는 문장
            BugPos = GameObject.Find("BackGround").GetComponent<Create_Bugker>().LBug_Node[i].GetComponent<RectTransform>().localPosition;

            // 만약 클릭한 사이즈와 노드의 값이 같다면 그노드의 위치값을 알려주는 함수
            if (BPos.x >= BugPos.x - 5
                && BPos.x <= BugPos.x + 5
                && BPos.y >= BugPos.y - 5
                && BPos.y <= BugPos.y + 5)
            {
                temp = i;
                return temp;
            }

        }

        return temp;

    }

    // 버거노드의 위치를 바꾸어주는 함수
    public void Change_Bug(int Xindex, int Yindex)
    {


        AnimationNode temp;
       

        // 0일때 리턴하는 함수
        if (Yindex == 0)
            return;

        temp.x = Xindex;
        temp.y = Yindex;
        temp.index = Saarch_Bug(Xindex, Yindex - 1);

 
        ANode.Add(temp);


    }

    void Check_Animation()
    {
        int index;

        // 노드의 값이 없으면 해당 함수를 종료한다.
        if (ANode.Count == 0)
            return;

        // 노드 갯수만큼 애니메이션 처리를 해야하기 때문에 for문을 이용한 애니메이션 처리
        for (int i = 0; i < ANode.Count; i++)
        {
            // 각 노드의 값을 함수에 전달 애니메이션을 처리하는 함수 애니메이션이 끝이나면 index :1 이면 애니메이션 종료
            index = Change_Animation(ANode[i].x, ANode[i].y, ANode[i].index);

            // 1이면 더이상 애니메이션을 할 이유가 없으므로 해당 노드를 리스트에서 정리해준다.
            if (index == 1)
            {
                ANode.RemoveAt(i);
               
            }

        }

   
    }

    // 해당 노드의 애니메이션 처리하는 함수 (Animationnode의 인자값을 받는다)
    // 버거 애니메이션이 실행 될때 버거의 입력을 받지 말아야 한다.
    int Change_Animation(int x, int y, int index)
    {

        AnimationStart();
        // 게임오브젝트의 값을 받아오는 함수
        GameObject tempObject;
        // 현재 위치값을 가지고 있는 변수
        Vector3 Current_Pos;
        // 목적지 위치값을 가지고 있는 변수
        Vector3 Last_Pos;

        // 인덱스 값을 이용 변화해야하는 오브젝트 값을 가져온다.
        tempObject = LBug_Node[index];

        // 오브젝트에서 현재 오브젝트의 위치값을 가져온다.
        Current_Pos = tempObject.GetComponent<RectTransform>().localPosition;

        // 인덱스 값을 이용하여 목적지 위치값을 가져온다.
        Last_Pos.x = aButton_Pos[x, y].x;
        Last_Pos.y = aButton_Pos[x, y].y;
        Last_Pos.z = 0;


        // 현제 위치값과 목적지 위치값이 벗어난다면 도착을 한것이기 때문에 도착판단을 하고 목적지 값을 넣어준다.
        if (Current_Pos.y <= Last_Pos.y)
        {
            Current_Pos = Last_Pos;
            tempObject.GetComponent<RectTransform>().localPosition = Current_Pos;
            AnimationEnd();
           
            return 1;
        }

        // 아니라면 애니메이션 이동 값 만큼 위치를 이동해주고 해당 이동값을 오브젝트에 저장한다.
        else
        {
            Current_Pos.y += -MoveSpeed_Animation;
            tempObject.GetComponent<RectTransform>().localPosition = Current_Pos;
            return 0;
        }
    } 
        // 버거를 처음 생성하는 함수
    int Create_BugNode ()
    {
        // 위치값 저정을 위한 Vector3 배열생성 
        aButton_Pos = new Vector3[MAX_Width, MAX_Height];
        NodeCount = new int[MAX_BUTTON];
     
        //참조를 위한 인덱스 값 선언 (위치값 y)
        int index = 0;
        // 버거 노드의 생성을 위한 인덱스 값  (1씩 증가하면서 13까지 증가) 
        int Count = 0;

        float Last_Y_Pos = Start_Height;
        LBug_Node = new List< GameObject >();
        ANode = new List<AnimationNode>();
        Order_List = new List<GameObject> ();

        // 노드 카운터를 초기화 시키는 함수
        for (int i =0; i< MAX_BUTTON; i++ )
        {
            NodeCount[i] = 0;
        }

        
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
           
            // 위치값 저장을 위한 임시 변수
            Vector3 temp;

            // 저장해 놓았던 변수입력
            temp.x = aButton_Pos[i, 0].x;
            temp.y = aButton_Pos[i, 0].y;
            temp.z = 0;

            // 버거 노드의 세로의 값만큼 생성
            for (index = 0; index < MAX_Height; index++)
            {

                Create_Bug_Node(i, index, Count);
                
                Count++;
                Count = Count % 13;
            }
        }
        return 1;


    }

    /*
     * 만들어야 하는 버거의 오더를 생성하는 함수
     * 버거의 배열을 불러오고 출력하는 함수를 만들어야 한다. (2018.02.19)
     * 2018.02.08
     * LTS 
     */
    public void Create_Order (int index)
    {
        GameObject tempObject;

        setselect_orderNum(index);

        //tempObject = Instantiate(BM_Order[index], Vector3.zero, Quaternion.identity);
        tempObject = BM_Order[index];
        tempObject.transform.SetParent(transform);
        tempObject.GetComponent<RectTransform>().localPosition = localOrder;

        tempObject.GetComponent<RectTransform>().localPosition = new Vector3(-10f, 100f, 0f);
        tempObject.transform.localScale = new Vector3(1f,1f, 0f);
        tempObject.transform.rotation = new Quaternion(0f, 0.0f, 0f,0f);

       // Debug.Log(tempObject.GetComponent<RectTransform>().localPosition);
        Order_List.Add(tempObject);
    }

    /*
     * 시간이 지나면 오더 버거 삭제 루틴 (모두 삭제 루틴)
     * 2018.02.12
     * LTS
     */
    public void Delete_Order ()
    {
        GameObject tempObject;
        GameObject[] NextObjects;

        NextObjects = GameObject.Find("Screen").GetComponent<BM_Making_Bug>().getSelect_BugCreate(getselect_orderNum());
      

        for (int i=0; i<Order_List.Count; i++)
        {
            tempObject = Order_List[i];
            //setPostion(tempObject, NextObjects[0]);
            Destroy(tempObject);
            Order_List.RemoveAt(i);
        }
     
    }
        // 교체가 이루어 지지만 위치값이 변동되어서 삭제되는것 처럼 보임
        // 마지막 버거가 완성되었을때 모든 노드를 원상 복귀해놓을 함수가 필요함

    public void swapPostion(GameObject target, GameObject target2)
    {
       
      
        swap_order.transform.parent = target.transform.parent;
        swap_order.transform.localPosition = target.transform.localPosition;


        target.transform.SetParent(target2.transform.parent);
        target.transform.localPosition = target2.transform.localPosition;

        target2.transform.SetParent(swap_order.transform.parent);
        target2.transform.localPosition = swap_order.transform.localPosition;

    }

    public void setPostion (GameObject target, GameObject inputObj)
    {
        target.transform.SetParent(inputObj.transform.parent);
        target.transform.localPosition = inputObj.transform.localPosition;
    }

    public void FinalChange_bugOrder ()
    {      
        GameObject tempObject;
     

        for (int i = 0; i < Order_List.Count; i++)
        {
            tempObject = Order_List[i];
            setPostion(tempObject, swap_order);
            Order_List.RemoveAt(i);
        }

    }


    // 입력이 맞았을 경우 버거를 체인지 하는 함수
    public void Change_bugOrder(int checkIndex)
    {
        GameObject tempObject;
        GameObject nextObject;
        GameObject[]  NextObjects;

        NextObjects = GameObject.Find("Screen").GetComponent<BM_Making_Bug>().getSelect_BugCreate(getselect_orderNum());
        nextObject = NextObjects[checkIndex];

        for (int i = 0; i < Order_List.Count; i++)
        {
            // Debug.Log(Order_List.Count);
            tempObject = Order_List[i];


            if (tempObject != null && nextObject != null)
            {
               
                swapPostion(nextObject, tempObject);
                Order_List.RemoveAt(i);
            }

        }


        if (nextObject != null)
             Order_List.Add(nextObject);
    }


    void Start ()
    {
        Create_BugNode();
        swap_order = new GameObject();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Check_Animation();
    }
}
