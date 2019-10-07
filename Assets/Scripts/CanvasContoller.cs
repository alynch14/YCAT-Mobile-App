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
        setCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setCanvas()
    {
        foreach(Button button in buttons)
        {
            

            if(buttons.IndexOf(button) == 0)
            {
                button.transform.position = new Vector3(0, 0, 0);
                button.enabled = true;
            } else
            {

            }
        }
    }

    private void setButtonDimensions()
    {
        
    }
}
