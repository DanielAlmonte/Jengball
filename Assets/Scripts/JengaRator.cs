using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaRator : MonoBehaviour
{
    public GameObject JengaTower, JengaPiece, JengaRotatedPiece;
    public int JengaTowerWidth = 3, JengaTowerHeight = 18;
    public Material[] Materials;

    Piece selectedPiece = null;

    // Start is called before the first frame update
    void Start()
    {
        GenerateJengaTower();
    }

    // Update is called once per frame
    void Update()
    {
        RegenerateJengaTower();
        SelectPiece();
    }

    public List<GameObject> JengaPiecesList = new List<GameObject>();
    public List<GameObject> JengaRotatedPiecesArr = new List<GameObject>();
    void GenerateJengaTower()
    {
        int JP = 1;

        for (var h = 0; h < (JengaTowerHeight/2); h++)
        {
            for (var w = 0; w < JengaTowerWidth; w++)
            {
                JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3(1, (h), w), Quaternion.identity) as GameObject);
                // JengaPiecesList[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];

                JengaPiecesList.Add(Instantiate(JengaRotatedPiece, new Vector3(w, ((h) + 0.5f), 1), Quaternion.identity * Quaternion.Euler (0, 90, 0)) as GameObject);
                // JengaRotatedPiecesArr[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];
            }
        }
        
        for (var t = 0; t < JengaPiecesList.Count; t++)
        {   
            JengaPiecesList[t].name = ("JengaPiece" + " " + JP++);
        }
    }

    void RegenerateJengaTower()
    {
        List<GameObject> JengaPiecesLeft = new List<GameObject>();
        JengaPiecesLeft.AddRange(GameObject.FindGameObjectsWithTag("Piece"));

        if (JengaPiecesLeft.Count < JengaPiecesList.Count || Input.GetKey(KeyCode.R))
        {    
            for (var t = 0; t < JengaPiecesList.Count; t++)
            {   
                Destroy(JengaPiecesList[t]);
            }

            JengaPiecesList.Clear();  

            GenerateJengaTower();
        }

        else 
        {
            return;
        }
    }
    void SelectPiece()
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

                    Debug.Log("selected a piece");
                }

                selectedPiece = hit.collider.gameObject.GetComponent<Piece>();
                selectedPiece.selected = true;
            }
        }
    }
}