using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clickable : MonoBehaviour
{
    // public string testFunction;
    public GameObject menu;
    public List<GameObject> NumberOfRows = new List<GameObject>();
    public List<GameObject> VolumeNumbers = new List<GameObject>();

    static int rowNumber = 0;
    static int volume = 0;

    // public int SceneID;

    static bool showingCredits = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton() {
        // showingCredits = (showingCredits == true) ? this.gameObject.GetComponent<Animation>().Play("Button") : this.gameObject.GetComponent<Animation>().Play("ButtonCredits");
        if (showingCredits == false)
        {
            if (this.gameObject.tag == "Play") 
            {
                this.gameObject.GetComponent<Animation>().Play("Button");
                Debug.Log("scene loaded");
                Invoke("LoadScene", 0.20f);
            }

            else if (this.gameObject.tag == "Options")
            {
                this.gameObject.GetComponent<Animation>().Play("Button");
                Debug.Log("options loaded");
                menu.GetComponent<Animation>().Play("ShowCredits");
                showingCredits = true;
            }

            else if (this.gameObject.tag == "Quit")
            {
                // Invoke(testFunction, 0);
                this.gameObject.GetComponent<Animation>().Play("Button");
                Debug.Log("quited"); 
                Application.Quit(); Debug.Log("quited");
            }

            else if (this.gameObject.tag == "RowsPlus" && rowNumber < 10)
            {
                Debug.Log("RowsPlus");
                this.gameObject.GetComponent<Animation>().Play("Button");
                NumberOfRows[rowNumber].SetActive(false);
                rowNumber++;
                NumberOfRows[rowNumber].SetActive(true);
            }

            else if (this.gameObject.tag == "RowsMin" && rowNumber > 0)
            {
                Debug.Log("RowsMin");
                this.gameObject.GetComponent<Animation>().Play("Button");
                NumberOfRows[rowNumber].SetActive(false);
                rowNumber--;
                NumberOfRows[rowNumber].SetActive(true);
            }
        }

        else if (showingCredits == true)
        {
            if (this.gameObject.tag == "VolumeMin" && volume > 0)
            {
                this.gameObject.GetComponent<Animation>().Play("ButtonCredits");
                Debug.Log("volume min");
                VolumeNumbers[volume].SetActive(false);
                volume--;
                VolumeNumbers[volume].SetActive(true);
            }
            else if (this.gameObject.tag == "VolumePlus" && volume < 10)
            {
                this.gameObject.GetComponent<Animation>().Play("ButtonCredits");
                Debug.Log("volume plus");
                VolumeNumbers[volume].SetActive(false);
                volume++;
                VolumeNumbers[volume].SetActive(true);
            }
            else if (this.gameObject.tag == "GoBack")
            {
                this.gameObject.GetComponent<Animation>().Play("ButtonCredits");
                menu.GetComponent<Animation>().Play("HideCredits");
                showingCredits = false;
            }
        }

        // else { return; }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    // void Test()
    // {
    //     Debug.Log("Invoke works");
    // }
}
