using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Laughing : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float randomTime = Random.Range(0.1f, 0.3f);
        Invoke("changeScene", randomTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        //switch (SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 2,2))
        int randomScene = Random.Range(0, 3);
        switch (randomScene)
        {
            case 0:
                SceneManager.LoadScene("ledFace_Laughing00");
                break;
            case 1:
                SceneManager.LoadScene("ledFace_Laughing01");
                break;
            case 2:
                SceneManager.LoadScene("ledFace_Laughing02");
                break;
            default:
                SceneManager.LoadScene("ledFace_Laughing00");
                break;
        }
    }
}
