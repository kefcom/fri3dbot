using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFaceParty_stop_drinking : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("removeGlass",3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void removeGlass()
    {
        SceneManager.LoadScene("ledFace_Party02");
    }
}
