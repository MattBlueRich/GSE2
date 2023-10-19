using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public WipeController wipeController;
    private void Awake()
    {
        wipeController.GetComponent<Image>().color = new Color(0, 0, 0, 0); // Hides transition on start.
    }

    // This function is called by 'onClick()', from inside the UI PlayButton.
    public void loadScene()
    {
        StartCoroutine(transition());
    }

    IEnumerator transition()
    {
        wipeController.GetComponent<Image>().color = new Color(1,1,1,1);
        wipeController.AnimateOut();
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Load the game!");
    }
}
