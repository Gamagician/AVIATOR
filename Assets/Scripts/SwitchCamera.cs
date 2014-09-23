using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

    GameObject maincamera;
    GameObject fixedcamera; 
    GameObject smoothcamera;

    int selectionGridInt = 0;
    string[] selectionStrings = {"follow cam", "fixed cam", "smooth cam"};

	// Use this for initialization
    void OnGUI()
    {

        //Gameover, back to first camera	. 
        if (FlyingController.gameover == 2)
        {
            selectionGridInt = 0;
            maincamera.camera.enabled = true;
            fixedcamera.camera.enabled = false;
            smoothcamera.camera.enabled = false;
        }

    //Camera switching
        else if (FlyingController.gameover != 2)
        {
            selectionGridInt = 0;

            if (selectionGridInt == 0)
            {
                maincamera.camera.enabled = true;
                fixedcamera.camera.enabled = false;
                smoothcamera.camera.enabled = false;

            }
            if (selectionGridInt == 1)
            {
                maincamera.camera.enabled = false;
                fixedcamera.camera.enabled = true;
                smoothcamera.camera.enabled = false;
            }
            if (selectionGridInt == 2)
            {
                maincamera.camera.enabled = false;
                fixedcamera.camera.enabled = false;
                smoothcamera.camera.enabled = true;

            }


        }
    }	

}
