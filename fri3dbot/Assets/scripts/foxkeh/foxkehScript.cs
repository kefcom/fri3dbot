using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class foxkehScript : MonoBehaviour {
    private int moodID;
    private int newMoodID;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 11) == "foxkeh-Init")
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
                moodID = 7; // change to max emotions
            }
            newMoodID = moodID;
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < 7) // change to max emotions
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

        newMoodID = UnityEngine.Random.Range(0, 7); // choose next mood between x (inclusive) and x (exclusive)
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
            int moodTime = UnityEngine.Random.Range(5, 30); // time between moods (applied below, so certain animations can override ifneedbe)
            switch (moodID)
            {
                case 0:
                    //Looking
                    SceneManager.LoadScene("foxkeh-Looking");
                    break;
                case 1:
                    //idle
                    SceneManager.LoadScene("foxkeh-Idle");
                    break;
                case 2:
                    //fri3d
                    SceneManager.LoadScene("foxkeh-Fri3d");
                    break;
                case 3:
                    //tilt
                    SceneManager.LoadScene("foxkeh-Tilt");
                    break;
                case 4:
                    //badge
                    SceneManager.LoadScene("foxkeh-Badge");
                    break;
                case 5:
                    //coon
                    SceneManager.LoadScene("foxkeh-Coon");
                    break;
                case 6:
                    //foxkeh party (only to be displayed after 22:00 until 6)
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
                        SceneManager.LoadScene("foxkeh-party");
                    }
                    break;
                default:
                    //idle
                    SceneManager.LoadScene("foxkeh-Looking");
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
