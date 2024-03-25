using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public bool selected = false;

    public int collisionCount = 0;

    public bool isColliding
    {
        get { return collisionCount >= 1; }
    }

    Material pieceMaterial;
    Color selectedColor;
    [SerializeField] Material bloomMaterial;
    [SerializeField] Material noBloomMaterial;

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
            GetComponent<Rigidbody>().isKinematic = true;

            // Change the material to a material that has emission
            pieceMaterial = bloomMaterial;
            GetComponent<MeshRenderer>().material = bloomMaterial;

            // if the piece is not inside you can move up!
            if (isColliding)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, 10, 0) * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, -5, 0) * Time.deltaTime);
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    rotate += 90f;
                    gameObject.transform.localRotation = Quaternion.Euler(0.0f, rotate, 0.0f);
                }

            }
       
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.localPosition += transform.TransformDirection(new Vector3(5, 0, 0) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.localPosition += transform.TransformDirection(new Vector3(-5, 0, 0) * Time.deltaTime);
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

    void OnCollisionEnter(Collision col)
    {
        collisionCount++;
        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
            Debug.Log("Hendrik loss");
        }
    }

    void OnCollisionExit(Collision col)
    {
        collisionCount--;
    }
}
