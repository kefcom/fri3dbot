using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class _sceneDirector : MonoBehaviour {

    public string nextSceneName = "ledFace_Off";

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            Invoke("loadRandomScene", 5f);
        }
    }

    void showTransition()
    {
        int transitionNumber = Random.Range(0, 5);
        switch(transitionNumber)
        {
            case 0:
                SceneManager.LoadScene("_transition_static");
                break;
            case 1:
                SceneManager.LoadScene("_transition_testbeeld1");
                break;
            case 2:
                SceneManager.LoadScene("_transition_testbeeld2");
                break;
            case 3:
                SceneManager.LoadScene("_transition_xpScreensaver");
                break;
            case 4:
                SceneManager.LoadScene("_transition_blocks");
                break;


            default:
                SceneManager.LoadScene("_transition_static");
                break;
        }
        float waitingTime = Random.Range(2f, 5f);
        Invoke("loadScene",waitingTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void loadScene()
    {
        SceneManager.LoadScene(nextSceneName);
        // load another random scene
        float newSceneTime = Random.Range(120f, 600f); //random between 2 and 10 minutes       
        Invoke("loadRandomScene", newSceneTime);
    }


    public void loadRandomScene()
    {
        int randomScene = Random.Range(0, 4);
        switch(randomScene)
        {
            case 0:
                // led matrix face
                nextSceneName = "ledFace_Off";
                break;
            case 1:
                //bend-r rodruigez
                nextSceneName = "bend-r-init";
                break;
            case 2:
                //eeve
                nextSceneName = "eeve-init";
                break;
            case 3:
                //gearhead
                nextSceneName = "gearHead_init";
                break;

            default:
                // led matrix face
                nextSceneName = "ledFace_Off";
                break;

        }
        Invoke("showTransition", 1f);
    }
}
