using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class roboFaceScript : MonoBehaviour
{
    private int moodID;
    private int newMoodID;
    public int maxEmotions = 6;


    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "roboFace-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            moodID = 0;
            newMoodID = 0;
            Invoke("determineMood", 1f);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
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
        newMoodID = UnityEngine.Random.Range(0, maxEmotions); // choose next mood between 0(inclusive) and 13(exclusive)
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
        }
        else
        {
            int moodTime = UnityEngine.Random.Range(2, 30); // time between moods (applied below, so certain animations can override ifneedbe)
            switch (moodID)
            {
                case 0:
                    //loading
                    SceneManager.LoadScene("roboFace-loading");
                    break;
                case 1:
                    //looking
                    SceneManager.LoadScene("roboFace-looking");
                    break;
                case 2:
                    //looking
                    SceneManager.LoadScene("roboFace-dj");
                    break;
                case 3:
                    //fri3d
                    SceneManager.LoadScene("roboFace-fri3d");
                    break;
                case 4:
                    //roboface party (only to be displayed after 22:00 until 6)
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
                        SceneManager.LoadScene("roboFace-party");
                    }
                    break;
                case 5:
                    //psyche
                    moodTime = 10; // simple animation, not too long
                    SceneManager.LoadScene("roboFace-psyche");
                    break;
                default:
                    //init
                    SceneManager.LoadScene("roboFace-init");
                    break;
            }
            Debug.Log("changed scene for " + moodTime.ToString() + " seconds");
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
