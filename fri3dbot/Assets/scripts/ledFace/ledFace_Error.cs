using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Error : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("changeScene", 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        switch (SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 2,2))
        {
            case "00":
                GameObject.Find("scriptHolder").GetComponent<ledFaceScript>().triggerBusy();
                SceneManager.LoadScene("ledFace_Error01");
                break;
            case "01":
                SceneManager.LoadScene("ledFace_Error02");
                break;
            case "02":
                GameObject.Find("scriptHolder").GetComponent<ledFaceScript>().triggerReady();
                SceneManager.LoadScene("ledFace_Error00");
                break;
            default:
                SceneManager.LoadScene("ledFace_Error00");
                break;
        }
    }
}
