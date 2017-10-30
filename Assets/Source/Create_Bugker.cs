using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Create_Bugker : MonoBehaviour
{

    // 버거의 아이콘들을 배치하는 스크립트
   // public int MAX_BM_NodeCount;
    public GameObject [] BM_Node;
    Vector2 Pos;
	
	void Start ()
    {
       // BM_Node = new GameObject[MAX_BM_NodeCount];
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition.x);
            Debug.Log(Input.mousePosition.y);
        }

	}
}
