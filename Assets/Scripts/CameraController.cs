using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //making piece in peace
    public Piece selectedPiece = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectPiece();
    }

    public void SelectPiece()
    {
        // Return if left or right mouse button is not pressed.
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            // Check if the raycast hits piece.
            if (hit.collider.tag == "Piece")
            {
                if (selectedPiece != null)
                {
                    //deselectPiece doe iets
                    selectedPiece.selected = false;

/*                    Debug.Log("selected a piece");
*/                }

                selectedPiece = hit.collider.gameObject.GetComponent<Piece>();
                selectedPiece.selected = true;
            }
        }
    }


}   