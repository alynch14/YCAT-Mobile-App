using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class DeviceCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    public RawImage background;
    public AspectRatioFitter fit;

    public GameObject button_screenshot;

    // Start is called before the first frame update
    void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for(int i=0; i< devices.Length; i++)
        {
            //if(!devices[i].isFrontFacing) <-------------------------------------------------------------------------- REMEMBER TO CHANGE BACK ! ! !
            if (devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if(backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;

        camAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!camAvailable)
            return;

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = (backCam.videoVerticallyMirrored) ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    
    public void TakeScreenshot()
    {
        // Takes a picture of the screen and saves it in the Screenshots Assets folder
        StartCoroutine(SnapShot());
    }

    IEnumerator SnapShot()
    {
        // Prepare file details
        string folderPath = Application.persistentDataPath;
        string fileName = StaticClass.BUTTON_IMAGE + ".png";

        // Hides button before screenshot
        button_screenshot.SetActive(false);
        yield return new WaitForSeconds(0.0001F);

        // Takes a screenshot and saves it to a folder
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, fileName));

        // Turns off camera and redirects back to start screen
        yield return new WaitForSeconds(0.0001F);
        backCam.Stop();
        SceneManager.LoadScene("Start Screen");
    }
}
