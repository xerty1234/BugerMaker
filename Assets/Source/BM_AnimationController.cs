using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_AnimationController : MonoBehaviour
{

    private bool AnimationLook;
    private bool startTime;
    //private float nextTime = 0.0f;
    private float DeleTime = 0.2f;
    private float currentTime = 0.0f;

    public void AnimationLookON()
    {
        AnimationLook = true;
        startTime = false;

    }

    public void AnimationLookOFF()
    {
        AnimationLook = false;
        Debug.Log("실행이 되나?");
        
    }

    public bool getAnimationLook()  {return AnimationLook;}
   

    



    // Use this for initialization
    void Start ()
    {
        AnimationLook = false;
        startTime = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (AnimationLook == true)
        {
            if (startTime == false)
            {
                currentTime = Time.time + DeleTime;
                startTime = true;
            }


            if (Time.time > currentTime)
            {
                // nextTime = Time.time + DeleTime;
                currentTime = 0.0f;
                startTime = false;
                AnimationLookOFF();
            }
        }
      
  
	}
}
