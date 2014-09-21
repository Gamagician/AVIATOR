using UnityEngine;
using System.Collections;

public class AppStart : MonoBehaviour {

	
    AsyncOperation async;
    int progress = 0;

    // Use this for initialization
	void Start () {

        StartCoroutine(loadScene(Global.sceneName));
	
	}
    IEnumerator loadScene(string sceneName)
    {
        async = Application.LoadLevelAsync(sceneName);
        yield return async;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
