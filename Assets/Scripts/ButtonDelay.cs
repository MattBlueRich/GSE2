using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDelay : MonoBehaviour
{

    public GameObject Mask;
    
    private void Awake()
    {
        Mask.SetActive(false);

        StartCoroutine(WaitToDisplay(10.0f));
        
    }

    IEnumerator WaitToDisplay(float seconds)
    {
        yield return new WaitForSeconds(seconds); 
        Mask.SetActive(true);
    }
}



