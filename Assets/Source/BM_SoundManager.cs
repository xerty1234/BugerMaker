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
public AudioSource audioSound;

public AudioClip[] audioClipEffect;
public AudioClip[] audioClipBgm;



private string isStageSoundPlay;
public string getIsStageSoundPlay() {return isStageSoundPlay;}
public string setplayStageSound(string str) 
{
	isStageSoundPlay = str;
	playStage01Sound();
	return isStageSoundPlay;
}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	// Use this for initialization
	void Start () 
	{
		audioSound = GetComponent<AudioSource>();
	}
	

	public void playEff01Sound()
	{
		audioSound.PlayOneShot(audioClipEffect[0]);
	}


	public void playEff02Sound()
	{
		audioSound.PlayOneShot(audioClipEffect[1]);
	}

	
	public void playEff03Sound()
	{
		audioSound.PlayOneShot(audioClipEffect[2]);
	}

	
	public void playEme01Sound()
	{
		audioSound.clip = audioClipBgm[1];
		audioSound.PlayOneShot(audioClipBgm[1]);
		
	}


	public void playStage01Sound()
	{
		if (isStageSoundPlay == "play")
		{		
			audioSound.clip = audioClipBgm[0];
			audioSound.Play();
			audioSound.loop = true;
		}
		

	}
	// Update is called once per frame
	void Update () 
	{

	}

	
}
