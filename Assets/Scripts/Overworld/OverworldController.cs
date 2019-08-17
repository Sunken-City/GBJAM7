using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour
{
    [HideInInspector]
    public bool freezeInput {get; set;}
    public static OverworldController instance = null;

    private AsyncOperation _asyncMicrogameLoad = null;
    private string _currentMicrogameName = null;

    private GameObject _currentActivatingEnemy = null;

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
        _currentMicrogameName = microgameName;
        _currentActivatingEnemy = activatingEnemy;
    }

    public void EndMicrogame()
    {
        freezeInput = false;
        StartCoroutine(UnloadMicrogameAsync(_currentMicrogameName));
        _currentMicrogameName = null;
        _asyncMicrogameLoad = null;
        Destroy(_currentActivatingEnemy);
        _currentActivatingEnemy = null;
    }
        
    IEnumerator ExecuteMicrogameScene(string microgameSceneName)
    {
        yield return new WaitForSeconds(1.0f);
        _asyncMicrogameLoad.allowSceneActivation = true;
        while (!_asyncMicrogameLoad.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(microgameSceneName));
    }

    IEnumerator LoadMicrogameAsync(string microgameSceneName)
    {
        _asyncMicrogameLoad = SceneManager.LoadSceneAsync(microgameSceneName, LoadSceneMode.Additive);
        _asyncMicrogameLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!_asyncMicrogameLoad.isDone)
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
