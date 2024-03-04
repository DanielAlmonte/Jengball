using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    // Boolean for if peace is selected
    public bool selected = false;

    public bool pieceInside = true;

    Material pieceMaterial;
    [SerializeField] Material bloomMaterial;
    [SerializeField] Material noBloomMaterial;
    Color selectedColor;

    // Start is called before the first frame update
    void Start()
    {
        pieceMaterial = GetComponent<MeshRenderer>().material;
        selectedColor = new Color(0f, 125.0f/255.0f, 42.0f/255.0f);

/*        pieceOutside = true;
*/    }

    // Update is called once per frame
    void Update()
    {
        MovePiece();
    }

    void MovePiece()
    {
        if (selected)
        {
            // Change the material to a material that has emission
            pieceMaterial = bloomMaterial;
            GetComponent<MeshRenderer>().material = bloomMaterial;

            if (pieceInside)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    gameObject.transform.localPosition += transform.TransformDirection(new Vector3(5, 0, 0) * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    gameObject.transform.localPosition += transform.TransformDirection(new Vector3(-5, 0, 0) * Time.deltaTime);
                }
            }

            else
            {
                GetComponent<Rigidbody>().isKinematic = true;
                
                // wE Up
                if (Input.GetKey(KeyCode.W))
                {
                    gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, 5, 0) * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, -5, 0) * Time.deltaTime);
                }
            }
        }
        
        if (!selected)
        {
            // Change the material with a material without emission.
            pieceMaterial = noBloomMaterial;
            GetComponent<MeshRenderer>().material = noBloomMaterial;

            // if peace is not selected it can fall again.
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }



    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Piece")
        {
            pieceInside = true;
            Debug.Log("true kinematic!!!!");
        }
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject, 0.5f);
        }

        else
        {
            return;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Piece")
        {
            pieceInside = false;
            Debug.Log("false kinematic!!!!");
        }
    }
}
