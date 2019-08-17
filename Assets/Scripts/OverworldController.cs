using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour
{
    [HideInInspector]
    public bool freezeInput {get; set;}
    public static OverworldController instance = null;

    private AsyncOperation asyncMicrogameLoad = null;
    private string currentMicrogameName = null;

    private GameObject currentActivatingEnemy = null;

    // Start is called before the first frame update
    void Start()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginMicrogame(string microgameName, GameObject activatingEnemy)
    {
        freezeInput = true;
        StartCoroutine(LoadMicrogameAsync(microgameName));
        StartCoroutine(ExecuteMicrogameScene(microgameName));
        currentMicrogameName = microgameName;
        currentActivatingEnemy = activatingEnemy;
    }

    public void EndMicrogame()
    {
        freezeInput = false;
        StartCoroutine(UnloadMicrogameAsync(currentMicrogameName));
        currentMicrogameName = null;
        asyncMicrogameLoad = null;
        Destroy(currentActivatingEnemy);
        currentActivatingEnemy = null;
    }
        
    IEnumerator ExecuteMicrogameScene(string microgameSceneName)
    {
        yield return new WaitForSeconds(1.0f);
        asyncMicrogameLoad.allowSceneActivation = true;
        while (!asyncMicrogameLoad.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(microgameSceneName));
    }

    IEnumerator LoadMicrogameAsync(string microgameSceneName)
    {
        asyncMicrogameLoad = SceneManager.LoadSceneAsync(microgameSceneName, LoadSceneMode.Additive);
        asyncMicrogameLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncMicrogameLoad.isDone)
        {
            yield return null;
        }
    }
    IEnumerator UnloadMicrogameAsync(string microgameSceneName)
    {
        AsyncOperation asyncMicrogameUnload = SceneManager.UnloadSceneAsync(microgameSceneName);
        asyncMicrogameUnload.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncMicrogameUnload.isDone)
        {
            yield return null;
        }
    }
}
