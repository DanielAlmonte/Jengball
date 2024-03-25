using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clickable : MonoBehaviour
{
    public List<GameObject> Numbers = new List<GameObject>();

    static int number = 0;

    public int SceneID;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     this.gameObject.GetComponent<Animator>().Play("Button");
        // }
    }

    private void OnMouseUpAsButton() {
        
        this.gameObject.GetComponent<Animation>().Play("Button");

        if (this.gameObject.tag == "Play") 
        {
            Invoke("LoadScene", 0.45f);
        }

        else if (this.gameObject.tag == "Options") { SceneManager.LoadScene(SceneID); }

        else if (this.gameObject.tag == "Quit") { Application.Quit(); Debug.Log("quited");}

        else if (this.gameObject.tag == "Plus")
        {
            if (number < 10)
            {    
                Numbers[number].SetActive(false);
                number++;
                Numbers[number].SetActive(true);
            }
        }

        else if (this.gameObject.tag == "Min")
        {
            if (number > 0)
            {    
                Numbers[number].SetActive(false);
                number--;
                Numbers[number].SetActive(true);
            }
        }

        else { return; }

        // this.gameObject.transform.position = new Vector3(1.0f, 1.0f, 1.0f * Time.deltaTime);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneID);
    }
}
