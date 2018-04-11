﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Looking : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float randomTime = Random.Range(0.5f, 5f);
        Invoke("changeScene", randomTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        GameObject.Find("scriptHolder").GetComponent<ledFaceScript>().triggerReady();
        int randomScene = Random.Range(0, 4);
        switch (randomScene)
        {
            case 0:
                SceneManager.LoadScene("ledFace_Looking00");
                break;
            case 1:
                SceneManager.LoadScene("ledFace_Looking01");
                break;
            case 2:
                SceneManager.LoadScene("ledFace_Looking02");
                break;
            case 3:
                SceneManager.LoadScene("ledFace_Looking03");
                break;
            default:
                SceneManager.LoadScene("ledFace_Looking00");
                break;
        }
    }
}
