using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaRator : MonoBehaviour
{
    public GameObject JengaTower, JengaPiece, JengaRotatedPiece;
    public int JengaTowerWidth = 3, JengaTowerHeight = 18;
    public Material[] Materials;

    // Start is called before the first frame update
    void Start()
    {
        GenerateJengaTower();
    }

    // Update is called once per frame
    void Update()
    {
        RegenerateJengaTower();
    }

    public List<GameObject> JengaPiecesList = new List<GameObject>();
    public List<GameObject> JengaRotatedPiecesArr = new List<GameObject>();
    void GenerateJengaTower()
    {
        // Instantiate(JengaTower, new Vector3(0,0,0), Quaternion.identity);

        int JP = 1;

        for (var h = 0; h < (JengaTowerHeight/2); h++)
        {
            for (var w = 0; w < JengaTowerWidth; w++)
            {
                // JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3((w + (JengaTowerWidth/2f)), h*2, 1), Quaternion.identity) as GameObject);
                // // JengaPiecesList[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];

                // JengaRotatedPiecesArr.Add(Instantiate(JengaRotatedPiece, new Vector3(2.5f, (h*2 + 1 ), (w * 1)), Quaternion.identity) as GameObject);
                // // JengaRotatedPiecesArr[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];

                JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3(1, (h * 2), w), Quaternion.identity) as GameObject);
                // JengaPiecesList[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];

                JengaPiecesList.Add(Instantiate(JengaRotatedPiece, new Vector3(w, ((h * 2) + 1), 1), Quaternion.identity * Quaternion.Euler (0, 90, 0)) as GameObject);
                // JengaRotatedPiecesArr[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];
            }
        }
        
        for (var t = 0; t < JengaPiecesList.Count; t++)
        {   
            JengaPiecesList[t].name = ("JengaPiece" + " " + JP++);
            // Debug.Log(JengaPiecesList[t]);
            
            // JengaPiecesList[t].AddComponent<Rigidbody>();
            // JengaPiecesList[t].AddComponent<BoxCollider>();

            // JengaRotatedPiecesArr[t].name = ("JengaRotatedPiece" + " " + JP++);
            // Debug.Log(JengaRotatedPiecesArr[t]);
            
            // JengaRotatedPiecesArr[t].AddComponent<Rigidbody>();
            // JengaRotatedPiecesArr[t].AddComponent<BoxCollider>();
        }
    }

    void RegenerateJengaTower()
    {
        if (Input.GetKey(KeyCode.R))
        {    
            for (var t = 0; t < JengaPiecesList.Count; t++)
            {   
                Destroy(JengaPiecesList[t]);

                // Destroy(JengaRotatedPiecesArr[t]);
            }

            JengaPiecesList.Clear(); 
            // JengaRotatedPiecesArr.Clear();

            GenerateJengaTower();
        }
    }
}