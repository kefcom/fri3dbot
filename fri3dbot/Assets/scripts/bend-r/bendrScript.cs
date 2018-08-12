using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class bendrScript : MonoBehaviour {
    private int moodID;
    private int newMoodID;
    public int maxEmotions = 11;


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0,11) == "bend-r-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            moodID = 0;
            newMoodID = 0;
            Invoke("determineMood", 1f);
            LedData ledData = new LedData();
            ledData = new LedData
            {
                action = "controlLedStrip",
                actionData =
                    {
                        stripNum = 0,
                        animation = 55,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x555555"
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
                        color = "0x555555"
                    }
            };
            GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
            ledData = new LedData
            {
                action = "controlLedStrip",
                actionData =
                    {
                        stripNum = 2,
                        animation = 55,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x0000FF"
                    }
            };
            GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }


	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name.Substring(0, 5) == "_tran")
        {
            Destroy(this.gameObject);
        }

        //listen for keys to change mood
        if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            CancelInvoke();
            if (moodID > 0)
            {
                moodID--;
            }
            else
            {
                moodID = maxEmotions;
            }
            newMoodID = moodID;
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < maxEmotions)
            {
                moodID++;
            }
            else
            {
                moodID = 0;
            }
            newMoodID = moodID;
            changeMood();
        }
    }

    void determineMood()
    {      
        newMoodID = UnityEngine.Random.Range(0, maxEmotions); // choose next mood between 0(inclusive) and 9 exclusive)
        if (newMoodID == moodID)
        {
            determineMood();
        }
        changeMood();
    }

    void changeMood()
    {
        if(newMoodID != moodID)
        {
            // scene is not ready for change yet... (animation not done yet)
            if(moodID == 5) //unless it's mood 5(coding) which doesn't have a anim_begin and anim_end trigger (no animations, only video)
            {
                moodID = newMoodID;
                changeMood();
            }
        }
        else
        {
            // change the scene
            int moodTime = UnityEngine.Random.Range(5, 30); // time between moods (applied below, so certain animations can override ifneedbe)
            LedData ledData = new LedData();
            switch (moodID)
            {
                case 0:
                    //happy (animation)
                    SceneManager.LoadScene("bend-rHappy");
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 10,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x555555"
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
                        color = "0x555555"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 2,
                        animation = 10,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                case 1:
                    //angry (animation)
                    SceneManager.LoadScene("bend-rAngry00");
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 14,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0XFF0000"
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
                        color = "0x555555"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 2,
                        animation = 14,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                case 2:
                    //Error (animation)
                    moodTime = UnityEngine.Random.Range(2, 6);
                    //beter not to show errors too long, they so sad :(
                    SceneManager.LoadScene("bend-rError00");


                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 21,
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
                        animation = 21,
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
                        animation = 21,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                case 3:
                    //Error2 (animation)
                    //beter not to show errors too long, they so sad :(
                    //except this one... cuz it's funny :)
                    SceneManager.LoadScene("bend-rError200");


                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 21,
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
                        animation = 21,
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
                        animation = 21,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);

                    break;
                case 4:
                    //drunk (animation)
                    moodTime = 15;
                    SceneManager.LoadScene("bend-rDrunk");

                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 37,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0030"
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
                        color = "0x555555"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 2,
                        animation = 37,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF3000"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);

                    break;
                case 5:
                    //coding (animation)
                    SceneManager.LoadScene("bend-rCoding00");
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 21,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x0000FF",
                        speed = 1
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
                        color = "0x0000FF"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 2,
                        animation = 21,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x00FF00",
                        speed = 1
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                case 6:
                    //fri3d (animation)
                    SceneManager.LoadScene("bend-rFried");

                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 2,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000",
                        speed = 1
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
                        color = "0xFF0000",
                        speed = 1
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                case 7:
                    //smoking (animation)
                    SceneManager.LoadScene("bend-rSmoking");

                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 50,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xffffff",
                        speed = 1
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
                        color = "0x555555"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 2,
                        animation = 50,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xffffff",
                        speed = 1
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                case 8:
                    //looking (animation)
                    SceneManager.LoadScene("bend-rLooking");

                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 55,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x555555"
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
                        color = "0x555555"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 2,
                        animation = 55,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x0000FF"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                case 9:
                    //bend-r party (only to be displayed after 22:00 until 6)
                    TimeSpan start = new TimeSpan(06, 0, 0);
                    TimeSpan end = new TimeSpan(22, 0, 0);
                    TimeSpan now = DateTime.Now.TimeOfDay;

                    if ((now > start) && (now < end))
                    {
                        // can't trigger now, choose another mood
                        determineMood();
                        return; //exit the routine instead of re-calculating moodtimes
                    }
                    else
                    {
                        // it's between 22:00 and 6:00, so Party on!
                        SceneManager.LoadScene("bend-r-party");

                        ledData = new LedData
                        {
                            action = "controlLedStrip",
                            actionData =
                    {
                        stripNum = 0,
                        animation = 28,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x0000FF",
                        speed = 500
                    }
                        };
                        GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                        ledData = new LedData
                        {
                            action = "controlLedStrip",
                            actionData =
                    {
                        stripNum = 1,
                        animation = 28,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000",
                        speed = 500
                    }
                        };
                        GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                        ledData = new LedData
                        {
                            action = "controlLedStrip",
                            actionData =
                    {
                        stripNum = 2,
                        animation = 28,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x0000FF",
                        speed = 500
                    }
                        };
                        GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    }
                    break;
                case 10:
                    //fri3dleds (runonce)
                    moodTime = 5; // only allow it to run once
                    SceneManager.LoadScene("bend-r-fri3dleds");

                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 44,
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
                        animation = 1,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0030"
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
                        color = "0x0000FF"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    break;
                default:
                    // Happy
                    SceneManager.LoadScene("bend-rHappy");

                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 0,
                        animation = 10,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0x555555"
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
                        color = "0x555555"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);
                    ledData = new LedData
                    {
                        action = "controlLedStrip",
                        actionData =
                    {
                        stripNum = 2,
                        animation = 10,
                        brightness = GameObject.Find("serialManager").GetComponent<SerialManager>().ledBrightness,
                        color = "0xFF0000"
                    }
                    };
                    GameObject.Find("serialManager").GetComponent<SerialManager>().SendLedData(ledData);

                    break;
            }

            //apply mood time
            Invoke("determineMood", moodTime);
        }
    }

    public void triggerBusy()
    {
    }

    public void triggerReady()
    {
        //only change if needed
        if(moodID != newMoodID)
        {
            moodID = newMoodID;
            changeMood();
        }
    }
}