using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class roboFaceScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "roboFace-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            Invoke("determineMood", 1f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 5) == "_tran")
        {
            Destroy(this.gameObject);
        }
    }

    void determineMood()
    {
        int moodTime = UnityEngine.Random.Range(2, 60); // time between moods (applied below, so certain animations can override ifneedbe)
        int moodID = UnityEngine.Random.Range(0, 2); // choose next mood between 0(inclusive) and 13(exclusive)
        //int moodID = 12; //remove, only for testing

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
