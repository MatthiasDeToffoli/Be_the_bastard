﻿using Assets.Scripts.GameObjects.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICharacterType : MonoBehaviour {


	// Use this for initialization
	void Start () {
   
	}
    
    public void PlayerType(string pType)
    {
        PlayerAgent.instance.playerType = pType;
       // SceneManager.LoadScene("Scene Name"); SceneName = principal scene name. Load at the start of the game
    }

    // Update is called once per frame
    void Update () {
		
	}
}