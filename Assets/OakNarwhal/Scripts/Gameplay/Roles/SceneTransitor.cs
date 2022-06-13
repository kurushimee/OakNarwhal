using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    [SerializeField] private int _sceneID = 0;
    [SerializeField] private bool _unlocked = true;

    public bool IsAvalaible()
    {
        return _unlocked;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneID);
    }

    public void Lock()
    {
        _unlocked = false;
    }

    public void Unlock()
    {
        _unlocked = true;
    }
}
