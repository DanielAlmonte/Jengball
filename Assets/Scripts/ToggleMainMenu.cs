using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ToggleMainMenu : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject introPlayer;
    public GameObject menu;
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
            // menu.transform.Translate(Vector3.up * speed * Time.deltaTime);
             menu.transform.position = Vector3.MoveTowards(menu.transform.position, targetPosition, speed * Time.deltaTime);
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
