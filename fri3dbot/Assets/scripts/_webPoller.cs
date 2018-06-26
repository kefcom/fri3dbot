using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Assets.scripts;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class _webPoller : MonoBehaviour
{
    // Use this for initialization

    public float Timeout = 5f;
    private PollerConfiguration _config;

    // Use this for initialization
    private void Start()
    {
        Debug.Log("Loading configuration");
        _config = LoadConfiguration();
        Debug.Log("Start");
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            DontDestroyOnLoad(this);
            StartCoroutine("PollHndler");
        }
    }

    private PollerConfiguration LoadConfiguration()
    {
        PollerConfiguration config;
        try
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "\\config.json");
            using (var reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                config = JsonConvert.DeserializeObject<PollerConfiguration>(json);
            }
        }
        catch (Exception ex)
        {
            config = PollerConfiguration.GetDefaultConfiguration();
        }
        return config;
    }

    private IEnumerator PollHndler()
    {
        using (var request = UnityWebRequest.Get(string.Format("{0}/api/faces/newest", _config.Url)))
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

internal class PollerConfiguration
{
    public string Url { get; private set; }

    public static PollerConfiguration GetDefaultConfiguration()
    {
        return new PollerConfiguration()
        {
            Url = "http://localhost:5000"
        };
    }
}