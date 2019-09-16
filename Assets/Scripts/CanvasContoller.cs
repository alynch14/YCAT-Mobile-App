using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    private void setCanvas()
    {
        foreach(Button button in buttons)
        {
            button.style.width = (200.0f/3.0f);
            button.style.height = (100f);

            if(buttons.IndexOf(button) == 0){
            }
            button.SetEnabled(true);
        }
    }

    private void setButtonDimensions()
    {
        
    }
}
