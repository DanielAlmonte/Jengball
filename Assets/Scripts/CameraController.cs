using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotationSpeed = 1000;
    Material m_Material;

    // Original colour of the platform.
    Color ogColor;

    [SerializeField] GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        m_Material = platform.GetComponent<Renderer>().material;
        ogColor = m_Material.color;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        SelectPiece();
    }


    void CameraRotation()
    {
        // Rotate the camera when right mouse button is pressed.
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.parent.Rotate(0.0f, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0.0f, Space.World);
            m_Material.color = new Color(0, 1, 0);
        }

        // Change material colour to a little bit darker green.
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            m_Material.color = ogColor;
        }
    }

    void SelectPiece()
    {
        // Return if left or right mouse button is not pressed.
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
        Debug.Log("test");

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            List<GameObject> pieces = new List<GameObject>();
            pieces.AddRange(GameObject.FindGameObjectsWithTag("Piece"));

            // Check if the raycast hits piece.
            if (hit.collider.tag == "Piece")
            {
                for (int i = 0; i < 2; i++)
                {
                    pieces[i].GetComponent<Piece>().selected = false;
                }

                hit.collider.gameObject.GetComponent<Piece>().selected = true;

                if (hit.collider.gameObject.GetComponent<Piece>().selected == true)
                {
                    Debug.Log("deselect piece!");
                    return;
                }

                hit.collider.gameObject.GetComponent<Piece>().selected = true;
                Debug.Log("select piece!");
            }
        }
    }
}   