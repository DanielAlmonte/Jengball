using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DisableAnim : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frame == 100)
        {
            videoPlayer.Stop();
            Debug.Log(gameObject.name);
        }
    }
}
