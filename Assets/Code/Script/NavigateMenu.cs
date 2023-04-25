using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        Debug.Log("Load scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
        
    }
}
