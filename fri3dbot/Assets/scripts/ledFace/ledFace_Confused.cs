using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ledFace_Confused : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("changeScene", 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        switch (SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 2, 2))
        {
            case "00":
                GameObject.Find("scriptHolder").GetComponent<ledFaceScript>().triggerBusy();
                SceneManager.LoadScene("ledFace_Confused01");
                break;
            case "01":
                SceneManager.LoadScene("ledFace_Confused02");
                break;
            case "02":
                SceneManager.LoadScene("ledFace_Confused03");
                break;
            case "03":
                SceneManager.LoadScene("ledFace_Confused04");
                break;
            case "04":
                SceneManager.LoadScene("ledFace_Confused05");
                break;
            case "05":
                SceneManager.LoadScene("ledFace_Confused06");
                break;
            case "06":
                SceneManager.LoadScene("ledFace_Confused07");
                break;
            case "07":
                SceneManager.LoadScene("ledFace_Confused08");
                break;
            case "08":
                GameObject.Find("scriptHolder").GetComponent<ledFaceScript>().triggerReady();
                SceneManager.LoadScene("ledFace_Confused00");
                break;
            default:
                SceneManager.LoadScene("ledFace_Confused00");
                break;
        }
    }
}
