using UnityEngine;
using System.Collections;

public class buttonClick : MonoBehaviour
{

    public void Awake()
    {
        
        GameObject Playbutton = GameObject.Find("UI Root/Camera/Anchor/Panel_StartUI/btPlay");
        GameObject Exitbutton = GameObject.Find("UI Root/Camera/Anchor/Panel_StartUI/btExit");
        UIEventListener.Get(Playbutton).onClick = PlayGame;
        UIEventListener.Get(Exitbutton).onClick = ExitGame;

        GameObject BackButton_selectLevel = GameObject.Find("UI Root/Camera/Anchor/Panel_LevelSelectUI/backButton");
        GameObject nextButton_selectLevel = GameObject.Find("UI Root/Camera/Anchor/Panel_LevelSelectUI/nextButton");
        UIEventListener.Get(BackButton_selectLevel).onClick = BackFromSelectLevel;
        UIEventListener.Get(nextButton_selectLevel).onClick = NextFromSelectLevel;


        GameObject BackButton_selectPlane = GameObject.Find("UI Root/Camera/Anchor/Panel_PlaneSelectUI/BackButton");
        GameObject PlayButton_selectPlane = GameObject.Find("UI Root/Camera/Anchor/Panel_PlaneSelectUI/PlayButton");
        UIEventListener.Get(BackButton_selectPlane).onClick = BackFromSelectPlane;
        UIEventListener.Get(PlayButton_selectPlane).onClick = PlayFromSelectPlane;
        
        


    }

    
    void PlayGame(GameObject button)
    {
        GameObject startPanel = GameObject.Find("UI Root/Camera/Anchor/Panel_StartUI");
        startPanel.transform.Rotate(Vector3.up, 90);
        GameObject selectLevelPanel = GameObject.Find("UI Root/Camera/Anchor/Panel_LevelSelectUI");
        selectLevelPanel.transform.Rotate(Vector3.up, -90);

    }

    void NextFromSelectLevel(GameObject button)
    {
        GameObject selectLevelPanel = GameObject.Find("UI Root/Camera/Anchor/Panel_LevelSelectUI");
        selectLevelPanel.transform.Rotate(Vector3.up, 90);
        GameObject selectPlanePanel = GameObject.Find("UI Root/Camera/Anchor/Panel_PlaneSelectUI");
        selectPlanePanel.transform.Rotate(Vector3.up, -90);
    }

    void ExitGame(GameObject button)
    {
        
        Application.Quit();
    }

    void BackFromSelectLevel(GameObject button)
    {
        GameObject startPanel = GameObject.Find("UI Root/Camera/Anchor/Panel_StartUI");
        startPanel.transform.Rotate(Vector3.up, -90);
        GameObject selectLevelPanel = GameObject.Find("UI Root/Camera/Anchor/Panel_LevelSelectUI");
        selectLevelPanel.transform.Rotate(Vector3.up, 90);
    }

    void BackFromSelectPlane(GameObject button)
    {
        GameObject selectLevelPanel = GameObject.Find("UI Root/Camera/Anchor/Panel_LevelSelectUI");
        selectLevelPanel.transform.Rotate(Vector3.up, -90);
        GameObject selectPlanePanel = GameObject.Find("UI Root/Camera/Anchor/Panel_PlaneSelectUI");
        selectPlanePanel.transform.Rotate(Vector3.up, 90);
    }

    void PlayFromSelectPlane(GameObject button)
    {
        Global.sceneName = Global.level01;
        Application.LoadLevelAsync(Global.sceneName);
    }
}