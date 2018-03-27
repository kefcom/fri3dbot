using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class eeveScript : MonoBehaviour {

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 9) == "eeve-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            Invoke("determineMood", 5f);
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
        int moodTime = UnityEngine.Random.Range(5, 60); // time between moods (applied below, so certain animations can override ifneedbe)
        int moodID = UnityEngine.Random.Range(0, 7); // choose next mood between x (inclusive) and x (exclusive)
        //int moodID = 12; //remove, only for testing

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
