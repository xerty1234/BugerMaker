using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************
* @classDescription 사운드 관리 스크립트
* @author LTS Corp.
* @version 1.0
* -------------------------------------------------------------------------------
* Modification Information
* Date              Developer           Content
* ----------        -------------       -------------------------
* 2020/05/24        이태섭              신규생성
* 
* -------------------------------------------------------------------------------
* Copyright (C) 2020 by LTS Corp. All rights reserved.
*********************************************************************************/

[RequireComponent(typeof(AudioSource))]

public class BM_SoundManager : MonoBehaviour {



public static BM_SoundManager instance;
AudioSource myAudio;

public AudioClip sndEff01;		//효과음1
public AudioClip sndEff02;		// 효과음2
public AudioClip sndEff03;		// 효과음3
public AudioClip sndStage01;	// 스테이지 BGM1
public AudioClip sndEme01;		// 위기 BGM


	private void Awake()
	{
		if (instance == null)
		{
			instance =this;
		}
	}

	// Use this for initialization
	void Start () 
	{
		myAudio = GetComponent<AudioSource>();
	}
	

	public void playEff01Sound()
	{
		myAudio.PlayOneShot(sndEff01);
	}


	public void playEff02Sound()
	{
		myAudio.PlayOneShot(sndEff02);
	}

	
	public void playEff03Sound()
	{
		myAudio.PlayOneShot(sndEff03);
	}

	
	public void playEme01Sound()
	{
		myAudio.PlayOneShot(sndEme01);
	}


	public void playStage01Sound()
	{
		myAudio.PlayOneShot(sndStage01);
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
