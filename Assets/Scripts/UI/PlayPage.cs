using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPage : MonoBehaviour {

    public Text play;
	// Use this for initialization
	void Start () {
        play.text = "Play !";
	}

    public void LoadGame()
    {
        SceneManager.LoadScene("TestMail");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
