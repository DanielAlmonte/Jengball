using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainMenuController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject introPlayer;
    public Vector3 targetPosition;
    public float speed = 10;
    bool moveUp = false;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = introPlayer.gameObject.GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        Intro();
        if (moveUp == true)
        {
            // this.transform.rotation = Quaternion.Euler(0, 225, 0);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void Intro()
    {
        if (videoPlayer.isPlaying && videoPlayer.frame == 173)
        {
            videoPlayer.Stop();
            introPlayer.gameObject.SetActive(false);
            moveUp = true;
        }
        else { return; }
    }
}
