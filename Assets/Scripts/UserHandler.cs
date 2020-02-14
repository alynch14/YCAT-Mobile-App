using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UserHandler : MonoBehaviour
{
    public static int user_id; // Static variable

    public InputField username_field;
    public InputField password_field;
    public GameObject invalid_text;

    private string key_user = "Username";
    private string key_pass = "Password";

    // Use this for initialization
    void Start()
    {
        invalid_text.SetActive(false);

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
        user_id = new int();
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username_field.text);
        form.AddField("password", password_field.text);
        WWW www = new WWW("http://mobile.tuycat.com/login.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            Debug.Log("User successfully logged in");

            // Retrieves user ID
            try {
                user_id = Int32.Parse(www.text.Substring(1));
            }
            catch (FormatException) {
                Debug.Log("Failed to parse: " + www.text.Substring(1));
            }

            // Sets user's prefered username and password
            PlayerPrefs.SetString(key_user, username_field.text);
            PlayerPrefs.SetString(key_pass, password_field.text);

            // Log button press
            this.GetComponent<ButtonHandler>().LogButtonPress();

            // Redirects to starting screen
            SceneManager.LoadScene("Start Screen");
        }
        else
        {
            invalid_text.SetActive(true);
            Debug.Log("User failed to login. " + www.text);
        }
    }
}
