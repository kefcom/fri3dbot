﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ledFaceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0,11) == "ledFace_Off")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            Invoke("determineMood", 1f);
        }


    }


	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name.Substring(0, 5) == "_tran")
        {
            Destroy(this.gameObject);
        }
    }

    void determineMood()
    {
        int moodTime = UnityEngine.Random.Range(2, 60); // time between moods (applied below, so certain animations can override ifneedbe)
        int moodID = UnityEngine.Random.Range(0, 13); // choose next mood between 0(inclusive) and 13(exclusive)
        //int moodID = 12; //remove, only for testing

        switch (moodID)
        {
            case 0:
                //happy (random)
                SceneManager.LoadScene("ledFace_Happy00");
                break;
            case 1:
                //angry (random)
                SceneManager.LoadScene("ledFace_Angry00");
                break;
            case 2:
                //Error (sequence)
                SceneManager.LoadScene("ledFace_Error00");
                break;
            case 3:
                //Looking (random)
                SceneManager.LoadScene("ledFace_Looking00");
                break;
            case 4:
                //Sleeping (random)
                //only trigger between 19:00 and 7:00
                TimeSpan start = new TimeSpan(07, 0, 0);
                TimeSpan end = new TimeSpan(19, 0, 0);
                TimeSpan now = DateTime.Now.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    // can't trigger now, choose another mood
                    determineMood();
                }else
                {
                    // it's between 19:00 and 7:00, so go right ahead sleepy...
                    moodTime = UnityEngine.Random.Range(60, 300); // sleep for 1 to 5 minutes
                    SceneManager.LoadScene("ledFace_Sleeping00");
                }              
                break;
            case 5:
                //Special (blow kiss)
                //override new mood time
                moodTime = 2;
                SceneManager.LoadScene("ledFace_Love00");
                break;
            case 6:
                //Party-drink (fixed sequence)
                //only trigger between 22:00 and 4:00
                start = new TimeSpan(04, 0, 0);
                end = new TimeSpan(22, 0, 0);
                now = DateTime.Now.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    // can't trigger now, choose another mood
                    determineMood();
                }
                else
                {
                    // it's between 22:00 and 4:00, so Party on!
                    moodTime = 10; //fixed animation time
                    SceneManager.LoadScene("ledFace_Party00");
                }
                break;
            case 7:
                //Special2 (love fri3d)
                //override new mood time
                moodTime = 5;
                SceneManager.LoadScene("ledFace_Love01");
                break;
            case 8:
                //Game (sequence once)
                moodTime = 15;
                SceneManager.LoadScene("ledFace_Game00");
                break;
            case 9:
                //Robot (sequence)
                SceneManager.LoadScene("ledFace_Robot00");
                break;
            case 10:
                //Confused (sequence)
                SceneManager.LoadScene("ledFace_Confused00");
                break;
            case 11:
                //Leughing (random)
                SceneManager.LoadScene("ledFace_Laughing00");
                break;
            case 12:
                //Crash (single frame with unity physx)
                moodTime = 15;
                SceneManager.LoadScene("ledFace_Crash00");
                break;
            case 13:
                //Special (heart eyes)
                //override new mood time
                moodTime = 2;
                SceneManager.LoadScene("ledFace_Love02");
                break;
            case 14:
                //Game2 (sequence)
                SceneManager.LoadScene("ledFace_Game200");
                break;


            default:
                // Happy
                SceneManager.LoadScene("ledFace_Happy00");
                break;
        }

        //apply mood time
        Invoke("determineMood", moodTime);
    }
}