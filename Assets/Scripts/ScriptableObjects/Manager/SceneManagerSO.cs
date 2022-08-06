using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManagerSO", menuName = "ScriptableObjects/Manager/SceneManagerSO")]
[System.Serializable] public class SceneManagerSO : ScriptableObject
{
    #region Methods

    public void LoadScene(string sceneName)
    {
        Debug.Log("Load Scene: " + sceneName);
        // Add closing scene event
        SceneManager.LoadScene(sceneName);
        // Add event to unityevent<string> manager for scene change so Game.cs know what scene is loaded
    }

    public string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        // Add quit event
        Application.Quit();
    }

    #endregion
}
