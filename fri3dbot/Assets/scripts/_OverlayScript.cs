using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _OverlayScript : MonoBehaviour {

    public GameObject canvasPrefab = null;
    public float lastPosition = 0f;
    private GameObject thisCanvas = null;
    private GameObject thisTextField = null;
    private string thisScene = null;

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            thisScene = SceneManager.GetActiveScene().name;
            DontDestroyOnLoad(this);

        }

        //instantiate overlay object
        thisCanvas = Instantiate(canvasPrefab, this.gameObject.transform.position  , this.gameObject.transform.rotation);
        thisCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        thisCanvas.GetComponent<Canvas>().worldCamera = Camera.main;

        //OverlayText
        thisTextField = GameObject.Find("overlayText").gameObject;
        thisTextField.GetComponent<Text>().text = "test";

        //set position of text
        lastPosition = 0f;
        // 0 - -425
        Debug.Log(lastPosition);
        Vector3 newPosition = new Vector3(lastPosition, thisTextField.transform.position.y, thisTextField.transform.position.z);
        thisTextField.transform.position = newPosition;

    }
   

    // Update is called once per frame
    void Update () {
        if(SceneManager.GetActiveScene().name != thisScene)
        {
            Debug.Log("test");
            //instantiate overlay object
            thisCanvas = Instantiate(canvasPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            thisCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
            thisCanvas.GetComponent<Canvas>().worldCamera = Camera.main;

            //OverlayText
            thisTextField = GameObject.Find("overlayText").gameObject;
            thisTextField.GetComponent<Text>().text = "test";
            thisScene = SceneManager.GetActiveScene().name;
        }
        lastPosition = (lastPosition - 0.1f);
        Vector3 newPosition = new Vector3 (lastPosition, thisTextField.transform.position.y, thisTextField.transform.position.z);
        thisTextField.transform.position = newPosition;

    }

    public static float GetSizeOfText(Text text, string word)
    {
        float width = 0.0f;
        CharacterInfo charInfo;
        foreach (char c in word)
        {
            text.font.GetCharacterInfo(c, out charInfo, text.fontSize);

            width += charInfo.advance;

        }
        return width;
    }
}
