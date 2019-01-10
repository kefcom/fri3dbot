using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class eeveScript : MonoBehaviour {
    private int moodID;
    private int newMoodID;
    public int maxEmotions = 9;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 9) == "eeve-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            moodID = 0;
            newMoodID = 0;
            Invoke("determineMood", 1f);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 55, "0x00FF00", 500);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x00FF00", 500);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 55, "0x00FF00", 500);
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
        if (newMoodID == moodID)
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
            if (moodID == 4)
            {
                moodID = newMoodID;
                changeMood();
            }

        }
        else
        {
            int moodTime = UnityEngine.Random.Range(5, 60); // time between moods (applied below, so certain animations can override ifneedbe)
            switch (moodID)
            {
                case 0:
                    //idle
                    SceneManager.LoadScene("eeve-idle");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 2, "0x00FF00", 500);
                    break;
                case 1:
                    //Happy
                    SceneManager.LoadScene("eeve-happy");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 24, "0x00FF00", 1);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 24, "0x00FF00", 1);
                    break;
                case 2:
                    //fri3d
                    SceneManager.LoadScene("eeve-fri3d");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x0FF000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 2, "0x0000FF", 500);
                    break;
                case 3:
                    //idle2
                    SceneManager.LoadScene("eeve-idle2");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x0000FF", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 2, "0x0000FF", 500);
                    break;
                case 4:
                    //glitch
                    moodTime = UnityEngine.Random.Range(2, 6);
                    //beter not to show errors too long, they so sad :(
                    SceneManager.LoadScene("eeve-glitch");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 21, "0x0000FF", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0x0000FF", 500);
                    break;
                case 5:
                    //idle3
                    SceneManager.LoadScene("eeve-idle3");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x0000FF", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 2, "0x0000FF", 500);
                    break;
                case 6:
                    //error
                    moodTime = UnityEngine.Random.Range(2, 6);
                    //beter not to show errors too long, they so sad :(
                    SceneManager.LoadScene("eeve-error");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 21, "0x0000FF", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0x0000FF", 500);
                    break;
                case 7:
                    //eeve party (only to be displayed after 22:00 until 6)
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
                        SceneManager.LoadScene("eeve-party");
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 28, "0x0000FF", 500);
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 28, "0xFF0000", 500);
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 28, "0x0000FF", 500);
                    }
                    break;
                case 8:
                    //amazed
                    SceneManager.LoadScene("eeve-amazed");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 43, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x0000FF", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 43, "0x0000FF", 500);
                    break;

                default:
                    //idle
                    SceneManager.LoadScene("eeve-idle");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 2, "0x00FF00", 500);
                    break;
            }
            Debug.Log("new mood in: " + moodTime.ToString() + " seconds");
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
