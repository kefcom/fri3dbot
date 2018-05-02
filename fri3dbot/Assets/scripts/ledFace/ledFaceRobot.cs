using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFaceRobot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("changeScene", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        switch (SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 2, 2))
        {
            case "00":
                SceneManager.LoadScene("ledFace_Robot01");
                break;
            case "01":
                SceneManager.LoadScene("ledFace_Robot02");
                break;
            case "02":
                SceneManager.LoadScene("ledFace_Robot03");
                break;
            case "03":
                SceneManager.LoadScene("ledFace_Robot04");
                break;
            case "04":
                SceneManager.LoadScene("ledFace_Robot05");
                break;
            case "05":
                SceneManager.LoadScene("ledFace_Robot06");
                break;
            case "06":
                SceneManager.LoadScene("ledFace_Robot07");
                break;
            case "07":
                SceneManager.LoadScene("ledFace_Robot00");
                break;
            default:
                SceneManager.LoadScene("ledFace_Robot00");
                break; //
        }
    }
}
