using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasContoller : MonoBehaviour
{
    private NavigationPath navigationPath = NavigationPath.Instance;
    public Text pathTraversed;

    // Start is called before the first frame update
    void Start()
    {
        if (pathTraversed == null)
        {
            pathTraversed = gameObject.GetComponentInChildren<Text>();
        }

        print(navigationPath.GetCurrentPath());
        string sceneName = SceneManager.GetActiveScene().name;
        print(sceneName);
        pathTraversed.text = navigationPath.GetCurrentPath() + sceneName + "/";
        navigationPath.AppendToPath(sceneName + "/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setButtonDimensions()
    {
        
    }
}
