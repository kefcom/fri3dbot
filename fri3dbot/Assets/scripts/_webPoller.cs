using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _webPoller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            GameObject.Find("sceneDirector").GetComponent<_sceneDirector>().loadFace(0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("webpoller active");
	}
}
