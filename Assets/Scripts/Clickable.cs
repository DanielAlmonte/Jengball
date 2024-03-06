using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
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
        Debug.Log(this.gameObject.name);
        this.gameObject.GetComponent<Animation>().Play("Button");
        // this.gameObject.transform.position = new Vector3(1.0f, 1.0f, 1.0f * Time.deltaTime);
    
    }
}
