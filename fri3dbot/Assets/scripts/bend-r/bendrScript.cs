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
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 55, "0x555555", 500);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x555555", 500);
            GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 55, "0x0000FF", 500);
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
            switch (moodID)
            {
                case 0:
                    //happy (animation)
                    SceneManager.LoadScene("bend-rHappy");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 10, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 10, "0x555555", 500);
                    break;
                case 1:
                    //angry (animation)
                    SceneManager.LoadScene("bend-rAngry00");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 14, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 14, "0xFF0000", 500);
                    break;
                case 2:
                    //Error (animation)
                    moodTime = UnityEngine.Random.Range(2, 6);
                    //beter not to show errors too long, they so sad :(
                    SceneManager.LoadScene("bend-rError00");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 21, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0x00FF00", 500);
                    break;
                case 3:
                    //Error2 (animation)
                    //beter not to show errors too long, they so sad :(
                    //except this one... cuz it's funny :)
                    SceneManager.LoadScene("bend-rError200");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 21, "0x00FF00", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0x00FF00", 500);
                    break;
                case 4:
                    //drunk (animation)
                    moodTime = 15;
                    SceneManager.LoadScene("bend-rDrunk");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 37, "0xFF0030", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 37, "0xFF0030", 500);
                    break;
                case 5:
                    //coding (animation)
                    SceneManager.LoadScene("bend-rCoding00");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 21, "0x0000FF", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x0000FF", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 21, "0x0000FF", 500);
                    break;
                case 6:
                    //fri3d (animation)
                    SceneManager.LoadScene("bend-rFried");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 2, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 2, "0xFF0000", 500);
                    break;
                case 7:
                    //smoking (animation)
                    SceneManager.LoadScene("bend-rSmoking");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 50, "0xFFFFFF", 1);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 50, "0xFFFFFF", 1);
                    break;
                case 8:
                    //looking (animation)
                    SceneManager.LoadScene("bend-rLooking");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 55, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 55, "0x0000FF", 500);
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
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 28, "0x0000FF", 500);
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 28, "0xFF0000", 500);
                        GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 28, "0x00FF00", 500);
                    }
                    break;
                case 10:
                    //fri3dleds (runonce)
                    moodTime = 5; // only allow it to run once
                    SceneManager.LoadScene("bend-r-fri3dleds");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 44, "0xFF0000", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 1, "0xFF0030", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 1, "0x0000FF", 500);
                    break;
                default:
                    // Happy
                    SceneManager.LoadScene("bend-rHappy");
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToLogo(0, 10, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToBody(0, 2, "0x555555", 500);
                    GameObject.Find("serialManager").GetComponent<SerialManager>().sendDataToEars(0, 10, "0x555555", 500);
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