using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool selected = false;

    Material pieceMaterial;
    [SerializeField] Material bloomMaterial;
    [SerializeField] Material noBloomMaterial;
    Color selectedColor;

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
    }

    void MovePiece()
    {
        if (selected)
        {
            // Change the material to a material that has emission
            pieceMaterial = bloomMaterial;
            GetComponent<MeshRenderer>().material = bloomMaterial;

            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, 0, 5) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.localPosition += transform.TransformDirection(new Vector3(0, 0, -5) * Time.deltaTime);
            }
        }
        
        if (!selected)
        {
            // Change the material with a material without emission.
            pieceMaterial = noBloomMaterial;
            GetComponent<MeshRenderer>().material = noBloomMaterial;

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject, 0.5f);
        }
        
        else {
            return;
        }
    }
}
