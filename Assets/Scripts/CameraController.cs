using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*    public float RotationSpeed = -1000;
    */


    GameObject cachedObject;
    GameObject selecteObject;

    Material m_Material;
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
            transform.parent.Rotate(0.0f, Input.GetAxis("Mouse X") * 1000 * Time.deltaTime, 0.0f, Space.World);
            m_Material.color = new Color(0,1,0);

        }

        // Change material colour to a little bit darker green.
        if (Input.GetKeyUp(KeyCode.Mouse1)) 
        {
            m_Material.color = ogColor;
        }
    }
    
    void SelectPiece()
    {
        // Return if left mouse button is not pressed.
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            // Check if the raycast hits piece.
            if (hit.collider.tag == "Piece")
            {
                Debug.Log("this piece");
                hit.collider.gameObject.GetComponent<Piece>().selected = true;


            }
        }
    }
}
    