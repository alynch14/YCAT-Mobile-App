using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{

    public GameObject textBox;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
//        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTextBox()
    {
        
    }

    public void exit()
    {
        Application.Quit();
    }
}
