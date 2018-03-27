using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class bendrScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0,11) == "bend-r-init")
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
        int moodTime = UnityEngine.Random.Range(20, 120); // time between moods (applied below, so certain animations can override ifneedbe)
        int moodID = UnityEngine.Random.Range(0, 9); // choose next mood between 0(inclusive) and 9 exclusive)
        switch (moodID)
        {
            case 0:
                //happy (animation)
                SceneManager.LoadScene("bend-rHappy");
                break;
            case 1:
                //angry (animation)
                SceneManager.LoadScene("bend-rAngry00");
                break;
            case 2:
                //Error (animation)
                SceneManager.LoadScene("bend-rError00");
                break;
            case 3:
                //Error2 (animation)
                SceneManager.LoadScene("bend-rError200");
                break;
            case 4:
                //drunk (animation)
                moodTime = 25;
                SceneManager.LoadScene("bend-rDrunk");
                break;
            case 5:
                //coding (animation)
                SceneManager.LoadScene("bend-rCoding00");
                break;
            case 6:
                //fri3d (animation)
                SceneManager.LoadScene("bend-rFried");
                break;
            case 7:
                //smoking (animation)
                SceneManager.LoadScene("bend-rSmoking");
                break;
            case 8:
                //looking (animation)
                SceneManager.LoadScene("bend-rLooking");
                break;
            default:
                // Happy
                SceneManager.LoadScene("bend-rHappy");
                break;
        }

        //apply mood time
        Invoke("determineMood", moodTime);
    }
}
