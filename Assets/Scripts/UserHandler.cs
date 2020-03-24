using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;

public class UserHandler : MonoBehaviour
{
    public InputField username_field;
    public InputField password_field;
    public GameObject invalid_text;

    private string key_user = "Username";
    private string key_pass = "Password";

    // Use this for initialization
    void Start()
    {
        // Displays user's prefered username and password if appicable
        username_field.text = (PlayerPrefs.GetString(key_user) != null) ? PlayerPrefs.GetString(key_user) : "";
        password_field.text = (PlayerPrefs.GetString(key_pass) != null) ? PlayerPrefs.GetString(key_pass) : "";
    }

    public void SignIn()
    {
        StartCoroutine(LoginUser());
    }

    public void SignOut()
    {
        Debug.Log("User successfully logged out");
        StaticClass.USER_ID = new int();
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username_field.text);
        form.AddField("password", password_field.text);
        UnityWebRequest www = UnityWebRequest.Post("http://mobile.tuycat.com/login.php", form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text[0] == '0')
        {
            Debug.Log("User successfully logged in");

            // Retrieves user ID
            try {
                StaticClass.USER_ID = Int32.Parse(www.downloadHandler.text.Substring(1));
            }
            catch (FormatException) {
                Debug.Log("Failed to parse: " + www.downloadHandler.text.Substring(1));
            }

            // Sets user's prefered username and password
            PlayerPrefs.SetString(key_user, username_field.text);
            PlayerPrefs.SetString(key_pass, password_field.text);

            // Redirects to starting screen
            SceneManager.LoadScene("Start Screen");
        }
        else
        {
            invalid_text.SetActive(true);
            Debug.Log("User failed to login. " + www.downloadHandler.text);
        }
    }
}
