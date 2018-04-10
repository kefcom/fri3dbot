using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class roboFaceScript : MonoBehaviour
{
    private int moodID;


    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "roboFace-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
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
                moodID = 1; // change to max emotions
            }
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < 1) // change to max emotions
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
        int moodID = UnityEngine.Random.Range(0, 2); // choose next mood between 0(inclusive) and 13(exclusive)
        changeMood();
    }

    void changeMood()
    {
        int moodTime = UnityEngine.Random.Range(2, 60); // time between moods (applied below, so certain animations can override ifneedbe)
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
            default:
                //init
                SceneManager.LoadScene("roboFace-init");
                break;
        }
    }
}
