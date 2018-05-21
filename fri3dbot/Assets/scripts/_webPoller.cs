using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class _webPoller : MonoBehaviour
{
    private readonly List<string> _lastUsedScenes = new List<string>();
    // Use this for initialization

    public float Timeout = 5f;

    // Use this for initialization
    private void Start()
    {
        Debug.Log("Start");
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            DontDestroyOnLoad(this);
            StartCoroutine("PollHndler");
            GameObject.Find("sceneDirector").GetComponent<_sceneDirector>().loadFace(0);
        }
    }

    private IEnumerator PollHndler()
    {
        using (var request = UnityWebRequest.Get("http://localhost:53549/api/scenes/random"))
        {
            Debug.Log("Received code" + request.responseCode);
            var scene = request.downloadHandler.text;
            _lastUsedScenes.Add(scene);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var response = request.downloadHandler.text;
                if (!string.IsNullOrEmpty(response))
                {
                    var faceCode = int.Parse(response);
                    GameObject.Find("sceneDirector").GetComponent<_sceneDirector>().loadFace(faceCode);
                    _lastUsedScenes.Add(response);
                }
            }
        }

        Debug.Log("webpoller active");


        yield return new WaitForSeconds(Timeout);
        StartCoroutine("PollHndler");
    }
}