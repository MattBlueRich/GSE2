using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // This function is called by 'onClick()', from inside the UI PlayButton.
    public void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Load the game!");
    }
}
