using System.Collections;
using System.Collections.Generic;
using Assets.scripts;
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
        using (var request = UnityWebRequest.Get("http://localhost:53549/api/scenes/newest"))
        {
            yield return request.SendWebRequest();

            Debug.Log("HTTP Response" + request.responseCode);
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
                    if (Shared.Faces.ContainsKey(faceCode))
                    {
                        GameObject.Find("sceneDirector").GetComponent<_sceneDirector>().loadFace(faceCode);
                        _lastUsedScenes.Add(response);
                    }
                    else
                    { 
                        // -1 means no new Face to be loaded, just continue
                        Debug.Log(string.Format("No new face to be loaded. Received {0}", faceCode));
                    }
                }
            }
        }

        Debug.Log("webpoller active");


        yield return new WaitForSeconds(Timeout);
        StartCoroutine("PollHndler");
    }
}