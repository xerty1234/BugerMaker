using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Button_Mgr : MonoBehaviour {

    

   public  void Select_Button ()
    {
        Vector3 temp;
        Vector2 Result;
        temp = this.GetComponent<RectTransform>().localPosition;
        Result = GameObject.Find("BackGround").GetComponent<Create_Bugker>().Check_Button(temp.x, temp.y);
        Debug.Log(Result);

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
