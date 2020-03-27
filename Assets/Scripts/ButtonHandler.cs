using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ButtonHandler : MonoBehaviour
{
    public string button_id;
    public string button_name;
    public Button thisButton;

    // Use this for initialization
    void Start()
    {
        // If screenshot exists, use that for button image instead of default
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, button_name + ".png");
        if (System.IO.File.Exists(filePath))
        {
            Sprite newSprite = IMG2Sprite.instance.LoadNewSprite(filePath);
            thisButton.GetComponent<Image>().sprite = newSprite;
        }
    }

    public void LogButtonPress()
    {
        StartCoroutine(SendToDatabase());
    }

    IEnumerator SendToDatabase()
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", StaticClass.USER_ID); // Using static variable
        form.AddField("button_id", button_id);
        UnityWebRequest www = UnityWebRequest.Post("http://mobile.tuycat.com/log_press.php", form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text == "0")
        {
            Debug.Log(button_id + " press logged successfully");
        }
        else
        {
            Debug.Log("Button press failed to log. " + www.downloadHandler.text);
        }
    }

    public void GoToCamera()
    {
        StaticClass.BUTTON_IMAGE = button_name;
        SceneManager.LoadScene("Camera");
    }
}