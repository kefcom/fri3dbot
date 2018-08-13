using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class gearheadScript : MonoBehaviour {
    private int moodID;
    private int newMoodID;
    public int maxEmotions = 7;


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "gearHead_init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            moodID = 0;
            newMoodID = 0;
            Invoke("determineMood", 1f);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 37, "0xFF0000", 500);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 0, "0xaFF0000", 500);
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
        newMoodID = UnityEngine.Random.Range(0, maxEmotions); // choose next mood between x (inclusive) and x (exclusive)
        if(newMoodID == moodID)
        {
            determineMood();
        }
        changeMood();
    }

    void changeMood()
    {
        if (newMoodID != moodID)
        {
            // scene is not ready for change yet... (animation not done yet)
            if (moodID == 0) // unless mood is 0, then you may change regardless
            {
                moodID = newMoodID;
                changeMood();
            }
        }
        else
        {
            int moodTime = UnityEngine.Random.Range(2, 60); // time between moods (applied below, so certain animations can override ifneedbe)
            switch (moodID)
            {
                case 0:
                    //idle
                    SceneManager.LoadScene("gearHead_idle");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0xaFF0000", 500);
                    break;
                case 1:
                    //idle2
                    SceneManager.LoadScene("gearHead_idle2");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0xa0000FF", 500);
                    break;
                case 2:
                    //happy (more like derpy)
                    SceneManager.LoadScene("gearHead_happy");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 5, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 5, "0xaFF0000", 500);
                    break;
                case 3:
                    //stuck
                    SceneManager.LoadScene("gearHead_gearStuck");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 14, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 14, "0xaFF0000", 500);
                    break;
                case 4:
                    //fri3d
                    SceneManager.LoadScene("gearHead_fri3d");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 12, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 12, "0xaFF0000", 500);
                    break;
                case 5:
                    //gearhead party (only to be displayed after 22:00 until 6)
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
                        SceneManager.LoadScene("gearhead-party");
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 10, "0xFF0000", 500);
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 10, "0xaFF0000", 500);
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 10, "0xaFF0000", 500);
                    }
                    break;
                case 6:
                    //high
                    SceneManager.LoadScene("gearHead_high");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 46, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 2, "0xaFF0000", 500);
                    break;
                default:
                    // idle
                    SceneManager.LoadScene("gearHead_idle");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xaFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0xaFF0000", 500);
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
        if (moodID != newMoodID)
        {          
            moodID = newMoodID;
            changeMood();           
        }
    }
}
