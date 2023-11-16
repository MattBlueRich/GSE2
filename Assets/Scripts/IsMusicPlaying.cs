using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMusicPlaying : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("MusicPlayer") != null)
        {
            GameObject musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");

            if (!musicPlayer.GetComponent<AudioSource>().isPlaying)
            {
                musicPlayer.GetComponent<AudioSource>().Play();
            }
        }
    }
}
