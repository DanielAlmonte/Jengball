using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    // The outerBox is used to show the player which piece is selected.
    public GameObject outerBox;
    public bool selected = false;

    public int collisionCount = 0;

    public bool isNotColliding
    {
        get { return collisionCount <= 0; }
    }

    Material pieceMaterial;
    Color selectedColor;

    float rotate = 0;

    // Start is called before the first frame update
    void Start()
    {
        pieceMaterial = GetComponent<MeshRenderer>().material;
        selectedColor = new Color(0f, 125.0f/255.0f, 42.0f/255.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePiece();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            selected = false;
        }
    }

        void MovePiece()
    {
        if (selected)
        {
            //Enables the outerBox/outline
            outerBox.SetActive(true);

            GetComponent<Rigidbody>().isKinematic = true;


            // If the piece is not inside you can move it up!
            if (isNotColliding)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    this.gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, 0, 10) * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    this.gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, 0, -5) * Time.deltaTime);
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    rotate += 90f;
                    
                    this.gameObject.transform.localRotation = Quaternion.Euler(-90, rotate, 0);
                }
            }   
       
            if (Input.GetKey(KeyCode.A))
            {
                this.gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, 5, 0) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, -5, 0) * Time.deltaTime);
            }
        }
        
        if (!selected)
        {
            //Disables the outerBox/outline
            outerBox.SetActive(false);

            // If peace is not selected it can fall again.
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        collisionCount++;
        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit(Collision col)
    {
        collisionCount--;
    }
}
