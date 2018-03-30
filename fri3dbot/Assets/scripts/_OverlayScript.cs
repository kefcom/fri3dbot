using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _OverlayScript : MonoBehaviour
{

    public GameObject canvasPrefab = null;
    public float lastPosition = 0f;
    private GameObject thisCanvas = null;
    private GameObject thisTextField = null;
    private GameObject thisCodeField = null;
    private string thisScene = null;
    public int currentSecurityCode = 123;
    public int lastSecurityCode = 321;
    public float securityCodeTime = 60f;
    public string overlayText = "";


    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            thisScene = SceneManager.GetActiveScene().name;
            DontDestroyOnLoad(this);

        }
        spawnOverlay();
        generateSecurityCode();
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != thisScene)
        {
            spawnOverlay();
        }

    }
    
    public void spawnOverlay()
    {
        //instantiate overlay object
        thisCanvas = Instantiate(canvasPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        thisCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        thisCanvas.GetComponent<Canvas>().worldCamera = Camera.main;

        //OverlayText
        thisTextField = GameObject.Find("bottomText").gameObject;
        thisTextField.GetComponent<Text>().text = overlayText;
        thisScene = SceneManager.GetActiveScene().name;

        //override colors for some faces
        //bend-r (background is gray)
        if (SceneManager.GetActiveScene().name.Substring(0,6) == "bend-r")
        {
            thisTextField.GetComponent<Text>().color = Color.black;
            thisCodeField.GetComponent<Text>().color = Color.black;
        }
    }

    public void generateSecurityCode()
    {
        lastSecurityCode = currentSecurityCode;
        currentSecurityCode = Random.Range(100, 999);
        //updateOverlay
        thisCodeField = GameObject.Find("topText").gameObject;
        thisCodeField.GetComponent<Text>().text = currentSecurityCode.ToString() ;
        Invoke("generateSecurityCode", securityCodeTime);
    }

    public void setOverlayText(string text)
    {
        overlayText = text;
        //OverlayText
        thisTextField = GameObject.Find("bottomText").gameObject;
        thisTextField.GetComponent<Text>().text = overlayText;
    }
}