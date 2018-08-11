using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SerialManager : MonoBehaviour {
    private SerialController _serialController;

    private void Start()
    {
        
        Debug.Log("Start");
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            DontDestroyOnLoad(this);
            StartCoroutine("SendTestData");
        }
    }

    public void SendLedData(LedData ledData)
    {
        var ports = SerialPort.GetPortNames();
        if (ports.Length != 1)
        {
            return;
            //throw new Exception("No ports found, or too many ports to choose from");
        }

        var port = ports.First();
        _serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        _serialController.portName = port;

        var message = JsonConvert.SerializeObject(ledData);
        message += Environment.NewLine;
        _serialController.SendSerialMessage(message);
    }

    void SendTestData()
    {
        var ports = SerialPort.GetPortNames();
        if (ports.Length != 1)
        {
            return;
            //throw new Exception("No ports found, or too many ports to choose from");
        }

        var port = ports.First();
        _serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        _serialController.portName = port;

        var ledData = new LedData
        {
            action = "controlLedStrip",
            actionData =
            {
                stripNum = 0,
                animation = 4,
                brightness = 128,
                color = "44fd15"
            }
        };
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
}