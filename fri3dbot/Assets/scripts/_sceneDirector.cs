using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Assets.scripts;


public class _sceneDirector : MonoBehaviour {

    public string nextSceneName = "ledFace_Off";
    public int currentScenenumber = 0;

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            Invoke("loadRandomFace", 5f);
        }
    }

    void showTransition()
    {
        int transitionNumber = UnityEngine.Random.Range(0, 7);
        float waitingTime = UnityEngine.Random.Range(2f, 5f);
        LedData ledData = new LedData();
        switch (transitionNumber)
        {
            case 0:
                SceneManager.LoadScene("_transition_static");

                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 8,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 8,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 8,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                break;
            case 1:
                SceneManager.LoadScene("_transition_testbeeld1");

                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 25,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 25,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 25,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };

                break;
            case 2:
                SceneManager.LoadScene("_transition_testbeeld2");

                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 45,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFFFFFF"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 45,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFFFFFF"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 45,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFFFFFF"
                    }
                };
                break;
            case 3:
                SceneManager.LoadScene("_transition_xpScreensaver");

                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 23,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 23,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 23,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00"
                    }
                };
                break;
            case 4:
                SceneManager.LoadScene("_transition_blocks");
                waitingTime = 8f;

                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 2,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 2,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 2,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000"
                    }
                };
                break;
            case 5:
                SceneManager.LoadScene("_transition_Fri3dlogo");
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 1,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000",
                        speed = 1000
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 1,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000",
                        speed = 1000
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 1,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000",
                        speed = 1000
                    }
                };
                break;
            case 6:
                SceneManager.LoadScene("_transition_bsod");

                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 0,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00",
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 0,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00",

                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 0,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00",
                    }
                };
                break;

            default:
                SceneManager.LoadScene("_transition_static");
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 0,
                        animation = 8,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 1,
                        animation = 8,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                ledData = new LedData
                {
                    action = "controlLedStrip",
                    actionData =
                    {
                        stripNum = 2,
                        animation = 8,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x000000"
                    }
                };
                break;
        }



        Invoke("switchToFace", waitingTime);
    }
	
	// Update is called once per frame
	void Update () {
		//listen for keys to change face
        if(Input.GetKeyUp(KeyCode.F1) == true)
        {
            loadFace(0);
        }
        if(Input.GetKeyUp(KeyCode.F2) == true)
        {
            loadFace(1);
        }
        if (Input.GetKeyUp(KeyCode.F3) == true)
        {
            loadFace(2);
        }
        if (Input.GetKeyUp(KeyCode.F4) == true)
        {
            loadFace(3);
        }
        if(Input.GetKeyUp(KeyCode.F5) == true)
        {
            loadFace(4);
        }
        if (Input.GetKeyUp(KeyCode.F6) == true)
        {
            loadFace(5);
        }
    }


    public void switchToFace()
    {
        SceneManager.LoadScene(nextSceneName);
        // load another random scene
        float newSceneTime = UnityEngine.Random.Range(120f, 600f); //random between 2 and 10 minutes       
        TimeSpan newTime = new TimeSpan(System.DateTime.Now.TimeOfDay.Hours,System.DateTime.Now.TimeOfDay.Minutes,System.DateTime.Now.TimeOfDay.Seconds + Mathf.RoundToInt(newSceneTime));
        Debug.Log("New scene in " + newSceneTime.ToString() + " Seconds (= " + newTime.ToString()  + " )");

        //load new scene in <x> time
        Invoke("loadRandomFace", newSceneTime);
    }


    public void loadRandomFace()
    {
        int randomScene = UnityEngine.Random.Range(0, 6);
        setFace(randomScene);
        Invoke("showTransition", 1f);
    }

    public void loadFace(int faceNumber)
    {
        CancelInvoke(); // cancel previous timers
        setFace(faceNumber); // set the nextSceneName
        // no need to show transition, just apply the new face
        // however, a transition scene stopt individual face scripts, so a quick scene is required, we use a black screen for this one.
        Invoke("switchToFace",0.5f);
        SceneManager.LoadScene("_TransitionClear");

    }

    


    public void setFace(int faceNumber)
    {
        if (!Shared.Faces.ContainsKey(faceNumber))
        {
            nextSceneName = Shared.Faces[0];
            currentScenenumber = 0;
        }
        else
        {
            nextSceneName = Shared.Faces[faceNumber];
            currentScenenumber = faceNumber;
        }
    }
}
