﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public string button_id;

    public void LogButtonPress()
    {
        StartCoroutine(SendToDatabase());
    }

    IEnumerator SendToDatabase()
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", UserHandler.user_id); // Using static variable
        form.AddField("button_id", button_id);
        WWW www = new WWW("http://mobile.tuycat.com/log_press.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log(button_id + " press logged successfully");
        }
        else
        {
            Debug.Log("Button press failed to log. " + www.text);
        }
    }
}