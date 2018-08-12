using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SerialManager : MonoBehaviour
{
    private SerialController _serialController;
    public int ledBrightness;

    private void Start()
    {
        setLedBrightnessByTime();

        Debug.Log("Start serialmanager");
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            DontDestroyOnLoad(this);
        }
        
    }

    void update()
    {
        setLedBrightnessByTime();
    }

    void setLedBrightnessByTime()
    {
        switch (DateTime.Now.TimeOfDay.Hours)
        {
            case 0:
                ledBrightness = 64;
                break;
            case 1:
                ledBrightness = 64;
                break;
            case 2:
                ledBrightness = 64;
                break;
            case 3:
                ledBrightness = 32;
                break;
            case 4:
                ledBrightness = 32;
                break;
            case 5:
                ledBrightness = 32;
                break;
            case 6:
                ledBrightness = 64;
                break;
            case 7:
                ledBrightness = 128;
                break;
            case 8:
                ledBrightness = 255;
                break;
            case 9:
                ledBrightness = 255;
                break;
            case 10:
                ledBrightness = 255;
                break;
            case 11:
                ledBrightness = 255;
                break;
            case 12:
                ledBrightness = 255;
                break;
            case 13:
                ledBrightness = 255;
                break;
            case 14:
                ledBrightness = 255;
                break;
            case 15:
                ledBrightness = 255;
                break;
            case 16:
                ledBrightness = 255;
                break;
            case 17:
                ledBrightness = 255;
                break;
            case 18:
                ledBrightness = 255;
                break;
            case 19:
                ledBrightness = 255;
                break;
            case 20:
                ledBrightness = 128;
                break;
            case 21:
                ledBrightness = 128;
                break;
            case 22:
                ledBrightness = 64;
                break;
            case 23:
                ledBrightness = 64;
                break;
            default:
                ledBrightness = 64;
                break;
        }
    }

    public void SendLedData(LedData ledData)
    {
        var ports = SerialPort.GetPortNames();
        //if (ports.Length != 1)
        //{
        //    return;
        //    //throw new Exception("No ports found, or too many ports to choose from");
        //}

        //var port = ports.First();
        var port = "com8";
        _serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        _serialController.portName = port;

        var message = JsonConvert.SerializeObject(ledData);
        message += Environment.NewLine;
        _serialController.SendSerialMessage(message);
    }

    void SendTestData()
    {
        var ports = SerialPort.GetPortNames();
        //if (ports.Length != 1)
        //{
        //    return;
        //    //throw new Exception("No ports found, or too many ports to choose from");
        //}
        
        //var port = ports.First();
        var port = "com8";
        _serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        _serialController.portName = port;
        Debug.Log("ledBrightness: " + ledBrightness.ToString());
        var ledData = new LedData
        {
            action = "controlLedStrip",
            actionData =
            {
                stripNum = 0,
                animation = 15,
                brightness = ledBrightness,
                color = "44fd15"
            }
        };

        Debug.Log("brightness: " + ledData.actionData.brightness.ToString());
        var message = JsonConvert.SerializeObject(ledData);
        message += Environment.NewLine;
        _serialController.SendSerialMessage(message);
    }


}
public class LedData
{
    public LedData()
    {
        actionData = new ActionData();
    }
    public string action { get; set; }
    public ActionData actionData { get; set; }
}

public class ActionData
{
    public int stripNum { get; set; }
    public int brightness { get; set; }
    public int animation { get; set; }
    public string color { get; set; }
    public int speed { get; set; }
}