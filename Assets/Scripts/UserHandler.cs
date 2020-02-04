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

    public void SignIn()
    {
        StartCoroutine(LoginUser());
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
            try {
                // Retrieves user ID
                user_id = Int32.Parse(www.text.Substring(1));
            }
            catch (FormatException) {
                Debug.Log("Failed to parse: " + www.text.Substring(1));
            }

            // Redirect to starting screen
            SceneManager.LoadScene("Start Screen");
        }
        else
        {
            Debug.Log("User failed to login. " + www.text);
        }
    }
}
