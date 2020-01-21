using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPath : MonoBehaviour
{
    public static NavigationPath Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private string path = "";

    public void AppendToPath(string sceneName)
    {
        path += sceneName;
    }

    public string GetCurrentPath()
    {
        return path;
    }

    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
