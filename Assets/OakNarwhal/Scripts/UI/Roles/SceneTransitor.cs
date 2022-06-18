using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    [SerializeField] private int sceneID;
    [SerializeField] private bool unlocked = true;
    private event Action OnSceneLoad;

    public bool IsAvailable()
    {
        return unlocked;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneID);
        OnSceneLoad?.Invoke();
    }

    public void Lock() => unlocked = false;
    public void Unlock() => unlocked = true;
}