using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ledFaceRobot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "ledFace_robot")
        {
            Invoke("changeScene", 0.5f);
        }
        else
        {
            Debug.Log(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "> " + "destroyed script ledFace_Robot -> current scene name is " + SceneManager.GetActiveScene().name);
            Destroy(this.gameObject);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        switch (SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 2, 2))
        {
            case "00":
                SceneManager.LoadScene("ledFace_robot01");
                break;
            case "01":
                SceneManager.LoadScene("ledFace_robot02");
                break;
            case "02":
                SceneManager.LoadScene("ledFace_robot03");
                break;
            case "03":
                SceneManager.LoadScene("ledFace_robot04");
                break;
            case "04":
                SceneManager.LoadScene("ledFace_robot05");
                break;
            case "05":
                SceneManager.LoadScene("ledFace_robot06");
                break;
            case "06":
                SceneManager.LoadScene("ledFace_robot07");
                break;
            case "07":
                SceneManager.LoadScene("ledFace_robot00");
                break;
            default:
                SceneManager.LoadScene("ledFace_robot00");
                break; //
        }
    }
}
