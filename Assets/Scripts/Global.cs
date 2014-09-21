using UnityEngine;
using System.Collections;

public class Global
{
    public static string sceneName="StartUI";
    public static string startUI = "StartUI";
    public static string loadingForm = "Loading";
    public static string level01 = "level01";
    public static string level02 = "level02";
    public static string level03 = "level03";

    public static string currentLevel = level01;

    public enum buttonEvent
    {
        Exit=1,
        LoadScene=2
    }
}