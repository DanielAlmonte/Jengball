using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaRator : MonoBehaviour
{
    public GameObject JengaPiece;
    public int JengaTowerWidth = 3, JengaTowerHeight = 18;

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
    void GenerateJengaTower()
    {
        int JP = 1;

        for (var h = 0; h < (JengaTowerHeight/2); h++)
        {
            for (var w = 0; w < JengaTowerWidth; w++)
            {
                JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3(w, ((h) + 0.5f), 1), Quaternion.Euler (-90f, 0f, 0f)) as GameObject);
                JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3(1, (h), w), Quaternion.Euler (-90f, 90f, 0f)) as GameObject);
            }
        }
    }

    void RegenerateJengaTower()
    {
        List<GameObject> JengaPiecesLeft = new List<GameObject>();
        JengaPiecesLeft.AddRange(GameObject.FindGameObjectsWithTag("Piece"));

        if (JengaPiecesLeft.Count < JengaPiecesList.Count || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.R))
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
}