using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// The sceneloader class handles every scene load method.
/// </summary>
public class SceneLoader : MonoBehaviour {
    
    void Start()
    {
        Time.timeScale = 1f;
    }
    //Loads a scene with the scene name.
    public void LoadNewScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    //loads next scene in build.
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //loads the scene that is active.
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
