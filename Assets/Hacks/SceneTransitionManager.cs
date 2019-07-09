using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public int activeScene;
    static SceneTransitionManager _instance;
    static public SceneTransitionManager Instance => _instance ?? new GameObject().AddComponent<SceneTransitionManager>();
    public bool LoadOnStart = false;
    bool loading = false;
    int stageCount = 0;

    void Awake()
    {
        stageCount = SceneManager.sceneCountInBuildSettings;
        if (_instance != this && _instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.name != "Gameplay")
                activeScene = scene.buildIndex;
            Debug.Log(scene.name);
        }

        SceneManager.sceneLoaded += (a, b) => loading = false;
        if(LoadOnStart)
        {
            StartCoroutine(Load(2));
        }
    }

    bool locked = false;

    public void GameStart()
    {
        if (locked)
            return;
        StartCoroutine(Load(2));
    }

    public void NextStage()
    {
        if (locked)
            return;
        StartCoroutine(Transition(activeScene + 1));
    }

    IEnumerator Transition(int stage)
    {
        Debug.Log($"{stage} {activeScene} {stageCount}");
        if (stage >= stageCount)
            stage = 2;
        locked = true;
        loading = true;

        yield return new WaitForSeconds(2f);

        var unload = SceneManager.GetSceneByBuildIndex(activeScene);
        var load = SceneManager.GetSceneByBuildIndex(stage);
        try
        {
            SceneManager.UnloadSceneAsync(activeScene);
        }
        catch (System.ArgumentException e)
        {
            Debug.LogError($"failed to unload {activeScene}, {e.Message}");
        }
        SceneManager.LoadSceneAsync(stage, LoadSceneMode.Additive);
        activeScene = stage;
        Debug.Log("loading..." + stage);
        while (loading)
            yield return null;
        Debug.Log("Loaded!" + stage);
        MoveSuga();
        yield return new WaitForSeconds(.25f);
        locked = false;
    }

    IEnumerator Load(int stage)
    {
        loading = true;
        locked = true;

        SceneManager.LoadSceneAsync("gameplay", LoadSceneMode.Single);
        while (loading)
            yield return null;
        loading = true;
        SceneManager.LoadSceneAsync(stage, LoadSceneMode.Additive);
        activeScene = stage;

        while (loading)
            yield return null;

        yield return new WaitForSeconds(.1f);

        MoveSuga();
        locked = false;
    }

    void MoveSuga()
    {
        var suga = FindObjectOfType<SugaMoni>();
        var spawn = FindObjectOfType<Spawn>();
        suga.Disable = false;
        suga.transform.position = spawn.transform.position;
    }
}
