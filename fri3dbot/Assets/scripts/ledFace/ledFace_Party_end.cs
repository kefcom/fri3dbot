using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Party_end : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("nextScene", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void nextScene()
    {
        GameObject.Find("scriptHolder").GetComponent<ledFaceScript>().triggerReady();
        SceneManager.LoadScene("ledFace_Party03");
    }


}
