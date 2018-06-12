using System.Collections;
using System.Collections.Generic;
using Assets.scripts;
using Newtonsoft.Json;
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
        }
    }

    private IEnumerator PollHndler()
    {
        using (var request = UnityWebRequest.Get("http://localhost:5000/api/faces/newest"))
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
                var requestDTO = JsonConvert.DeserializeObject<Shared.RequestDTO>(response);
                if (requestDTO != null)
                {
                    if (Shared.Faces.ContainsKey(requestDTO.RequestedFaceId))
                    {
                        var overlayScript = GameObject.Find("overlayScript").GetComponent<_OverlayScript>();
                        var lastCode = overlayScript.lastSecurityCode;
                        var currentCode = overlayScript.currentSecurityCode;
                        if (requestDTO.AuthorizationCode == currentCode || requestDTO.AuthorizationCode == lastCode)
                        {
                            overlayScript.generateSecurityCode();
                            GameObject.Find("sceneDirector").GetComponent<_sceneDirector>().loadFace(requestDTO.RequestedFaceId);
                            _lastUsedScenes.Add(response);
                        }
                    }
                    else
                    { 
                        // -1 means no new Face to be loaded, just continue
                        Debug.Log(string.Format("No new face to be loaded. Received {0}", requestDTO.RequestedFaceId));
                    }
                }
            }
        }

        Debug.Log("webpoller active");

        yield return new WaitForSeconds(Timeout);
        StartCoroutine("PollHndler");
    }
}