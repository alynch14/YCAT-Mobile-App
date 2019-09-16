using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasContoller : MonoBehaviour
{
    private List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCanvas(List<Button> newButtons)
    {
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        buttons.Clear();

        foreach(Button button in newButtons)
        {
            buttons.Add(button);
        }
    }

    private void setButtonDimensions()
    {
        
    }
}
