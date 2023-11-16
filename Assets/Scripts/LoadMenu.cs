using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMenu : MonoBehaviour
{
    public WipeController wipeController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameScene()
    {
        StartCoroutine(waitTillTransition());
    }

    IEnumerator waitTillTransition()
    {
        wipeController.AnimateOut(); // Transition out animation.

        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("MainGame");
    }
}
