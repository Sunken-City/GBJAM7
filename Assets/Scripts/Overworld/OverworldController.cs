using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour
{
    public enum State
    {
        PLAYING = 0,
        MICROGAME_TRANSITION,
        MICROGAME,
        PLAYING_TRANSITION,
        NUM_STATES
    }
    public static OverworldController instance = null;

    [HideInInspector]
    public bool freezeInput {get; set;}

    [HideInInspector]
    public bool allowGangUp { get; set; }

    [HideInInspector]
    public string currentSceneName = "";

    [HideInInspector]    
    public MicrogameController.State lastMicrogameState = MicrogameController.State.NOT_STARTED;

    public GameObject victoryFanfare = null;
    public GameObject lossFanfare = null;
    public GameObject battleFanfare = null;

    public float microgameTimescale = 1.0f;

    private State _state = State.PLAYING;
    private float _timeInState = 0.0f;
    private AsyncOperation _asyncMicrogameLoad = null;
    private string _currentMicrogameName = null;
    private List<string> _microgameNameQueue = new List<string>();
    private GameObject _currentActivatingEnemy = null;
    private List<GameObject> _activatingEnemyQueue = new List<GameObject>();
    private GameObject _playerReference = null;
    private GameObject _cameraReference = null;
    private GameObject _currentPlayingSound = null;
    private AudioSource _bgmSource = null;

    // Start is called before the first frame update
    void Start()
    {
        if(!instance)
        {
            instance = this;
            currentSceneName = SceneManager.GetActiveScene().name;
        }

        _playerReference = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(_playerReference, "The player should be tagged as 'Player'");
        _cameraReference = GameObject.FindGameObjectWithTag("MainCamera");
        Debug.Assert(_playerReference, "Need a Main Camera to reference in Overworld Controller");
        _bgmSource = GetComponent<AudioSource>();
        _bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _timeInState += Time.deltaTime;
        if(_state == State.MICROGAME_TRANSITION)
        {
            _cameraReference.GetComponent<SimpleBlit>().transitionValue = Mathf.Clamp01(_timeInState);
        }
        else if(_state == State.PLAYING_TRANSITION)
        {
            _cameraReference.GetComponent<SimpleBlit>().transitionValue = Mathf.Clamp01(1.0f - _timeInState);
        }
    }

    void ChangeToState(State newState)
    {
        _state = newState;
        _timeInState = 0.0f;
    }

    public void BeginMicrogame(string microgameName, GameObject activatingEnemy)
    {
        _bgmSource.Pause();
        if (_currentPlayingSound)
        {
            Destroy(_currentPlayingSound);
            _currentPlayingSound = null;
        }
        if (_currentMicrogameName != null)
        {
            _microgameNameQueue.Add(microgameName);
            _activatingEnemyQueue.Add(activatingEnemy);
        }
        else
        {
            lastMicrogameState = MicrogameController.State.PLAYING;
            allowGangUp = true;
            if (battleFanfare)
            {
                Instantiate(battleFanfare);
            }
            ChangeToState(State.MICROGAME_TRANSITION);
            freezeInput = true;
            StartCoroutine(LoadMicrogameAsync(microgameName));
            StartCoroutine(ExecuteMicrogameScene(microgameName));
            _currentMicrogameName = microgameName;
            _currentActivatingEnemy = activatingEnemy;
        }
    }

    public void EndMicrogame()
    {
        ChangeToState(State.PLAYING_TRANSITION);
        StartCoroutine(UnloadMicrogameAsync(_currentMicrogameName));
        allowGangUp = false;
        freezeInput = false;
        _currentMicrogameName = null;
        _asyncMicrogameLoad = null;

        if(lastMicrogameState == MicrogameController.State.WON)
        {
            Destroy(_currentActivatingEnemy);

            if(victoryFanfare)
            {
                _currentPlayingSound = Instantiate(victoryFanfare);
            }
        }
        else
        {
            _currentActivatingEnemy.GetComponent<EnemyScript>().Reset();
            if(lossFanfare)
            {
                _currentPlayingSound = Instantiate(lossFanfare);
            }
        }
        _currentActivatingEnemy = null;
        waitForFanfare();
        if(_activatingEnemyQueue.ToArray().Length != 0)
        {
            GameObject enemy = _activatingEnemyQueue[0];
            string microgame = _microgameNameQueue[0];
            _activatingEnemyQueue.RemoveAt(0);
            _microgameNameQueue.RemoveAt(0);
            BeginMicrogame(microgame, enemy);
        }
    }

    public async void waitForFanfare()
    {
        bool isPlaying = true;
        while(isPlaying)
        {
            isPlaying = _currentPlayingSound ? _currentPlayingSound.GetComponent<AudioSource>().isPlaying : true;
            await Task.Delay(100);
        }

        _bgmSource.UnPause();
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
        ChangeToState(State.MICROGAME);
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

        float startTime = Time.time;
        // Wait until the asynchronous scene fully unloads
        while (!asyncMicrogameUnload.isDone)
        {
            yield return null;
        }
        
        float elapsedTime = Time.time - startTime;
        float timeToWait = Mathf.Clamp01(1.0f - elapsedTime);

        yield return new WaitForSeconds(timeToWait);
        
        ChangeToState(State.PLAYING);
    }

    public void SetBGM(AudioClip bgm)
    {
        _bgmSource.clip = bgm;
        _bgmSource.Play();
    }

    public void SetBGMPitch(float scale)
    {
        _bgmSource.pitch = scale;
    }
}
