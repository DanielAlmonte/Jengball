using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Paused : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    bool paused = false;

    bool resume = false;

    bool keyEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        // videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        PausedScreen();
    }

    void PausedScreen()
    {
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.P)) && keyEnabled == true)
        {
            videoPlayer.Play();
            paused = true;
            keyEnabled = false;
        }

        if (paused == true)
        {
            if (videoPlayer.frame == 155 && resume == false)
            {
                videoPlayer.Pause();
                keyEnabled = true;
                resume = true;
            }

            if (videoPlayer.frame >= 215 && resume == true)
            {
                Debug.Log("Stop");
                keyEnabled = true;
                paused = false;
                resume = false;
                videoPlayer.Stop();
            }
        }
    }
}
