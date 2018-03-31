using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class _webPoller : MonoBehaviour
{
    private List<string> _lastUsedScenes = new List<string>();
	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);

        }
    }
	
	// Update is called once per frame
    void Update ()
    {
        var request = UnityWebRequest.Get("http://localhost:59576/api/scenes/new");
        request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            Debug.Log("Received code" + request.responseCode);
            var scene = request.downloadHandler.text;
            _lastUsedScenes.Add(scene);
        }
        Debug.Log("webpoller active");
	}
}
