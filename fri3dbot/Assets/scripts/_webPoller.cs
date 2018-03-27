using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime;

public class _webPoller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);

        }
    }
	
	// Update is called once per frame
    async void Update ()
	{
	    var client = new HttpClient();
	    client.BaseAddress = new Uri("http://localhost:59576");
	    var result = await client.GetAsync("api/scene/random");
	    Debug.Log("webpoller active");
	}
}
