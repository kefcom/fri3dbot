using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class eeveScript : MonoBehaviour {
    private int moodID;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 9) == "eeve-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            Invoke("determineMood", 5f);
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
                moodID = 6; // change to max emotions
            }
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < 6) // change to max emotions
            {
                moodID++;
            }
            else
            {
                moodID = 0;
            }
            changeMood();
        }
    }


    void determineMood()
    {

        int moodID = UnityEngine.Random.Range(0, 7); // choose next mood between x (inclusive) and x (exclusive)
        changeMood();
    }

    void changeMood()
    {
        int moodTime = UnityEngine.Random.Range(5, 60); // time between moods (applied below, so certain animations can override ifneedbe)
        switch (moodID)
        {
            case 0:
                //idle
                SceneManager.LoadScene("eeve-idle");
                break;
            case 1:
                //Happy
                SceneManager.LoadScene("eeve-happy");
                break;
            case 2:
                //fri3d
                SceneManager.LoadScene("eeve-fri3d");
                break;
            case 3:
                //idle2
                SceneManager.LoadScene("eeve-idle2");
                break;
            case 4:
                //glitch
                SceneManager.LoadScene("eeve-glitch");
                break;
            case 5:
                //idle3
                SceneManager.LoadScene("eeve-idle3");
                break;
            case 6:
                //error
                SceneManager.LoadScene("eeve-error");
                break;

            default:
                //idle
                SceneManager.LoadScene("eeve-idle");
                break;
        }

        //apply mood time
        Invoke("determineMood", moodTime);
    }
}
