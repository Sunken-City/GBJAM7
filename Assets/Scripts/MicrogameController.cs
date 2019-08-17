using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicrogameController : MonoBehaviour
{
    public GameObject MicrogameSubScene = null;
    public static MicrogameController instance = null;
    private bool HasWon = false;
    public float timeLimitSeconds = 5.0f;
    private float currentTimerSeconds = 0.0f;

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
        currentTimerSeconds += Time.deltaTime;
        if(currentTimerSeconds > timeLimitSeconds)
        {
            ReturnToOverworld();
        }
    }

    public void ReturnToOverworld()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("PrototypeOverworld"));
        OverworldController.instance.EndMicrogame();
        Destroy(MicrogameSubScene);
    }

    public void WinMicrogame()
    {
        HasWon = true;
        Debug.Log("Large winner!!!");
    }

    public bool HasNotYetWon()
    {
        return !HasWon;
    }
}
