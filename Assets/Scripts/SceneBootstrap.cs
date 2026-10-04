using UnityEngine;
using UnityEngine.SceneManagement;

// Plays 3DScene with 2DScene loaded additively, so pressing Play in 3DScene alone works.
public static class SceneBootstrap
{
    private const string MainSceneName = "3DScene";
    private const string PaintingSceneName = "2DScene";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void LoadPaintingScene()
    {
        if (SceneManager.GetActiveScene().name != MainSceneName) return;
        if (SceneManager.GetSceneByName(PaintingSceneName).isLoaded) return;
        SceneManager.LoadScene(PaintingSceneName, LoadSceneMode.Additive);
    }
}
