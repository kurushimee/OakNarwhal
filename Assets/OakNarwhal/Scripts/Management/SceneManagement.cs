using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void InitLoading(int loadID, int unloadID)
    {
        UnloadCurrentScene(unloadID);
        LoadNewScene(loadID);
    }

    private static void UnloadCurrentScene(int sceneToUnload)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }

    private static void LoadNewScene(int sceneToLoad)
    {
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }
}