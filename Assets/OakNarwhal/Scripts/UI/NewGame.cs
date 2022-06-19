using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public GameObject menu;
    private readonly List<AsyncOperation> _scenesToLoad = new();

    public void StartGame()
    {
        menu.SetActive(false);
        _scenesToLoad.Add(SceneManager.LoadSceneAsync(1));
        _scenesToLoad.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive));
        StartCoroutine(LoadScenes());
    }

    private IEnumerator LoadScenes()
    {
        foreach (var s in _scenesToLoad)
            while (!s.isDone)
                yield return null;
    }
}