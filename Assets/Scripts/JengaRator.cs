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
        RemoveTest();
    }

    List<GameObject> JengaPiecesArr = new List<GameObject>();
    List<GameObject> JengaRotatedPiecesArr = new List<GameObject>();
    void GenerateJengaTower()
    {
        // Instantiate(JengaTower, new Vector3(0,0,0), Quaternion.identity);

        int JP = 1;


        for (var h = 0; h < (JengaTowerHeight/2); h++)
        {
            for (var w = 0; w < JengaTowerWidth; w++)
            {
                JengaPiecesArr.Add(Instantiate(JengaPiece, new Vector3((w + (JengaTowerWidth/2f)), h*2, 1), Quaternion.identity) as GameObject);
                // JengaPiecesArr[w].name = ("JengaPiece" + " " + JP++);
                // JengaPiecesArr[w].tag = "JengaPiece";

                // Debug.Log(JengaPiecesArr[w].name);

                // JengaPiecesArr[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];

                JengaRotatedPiecesArr.Add(Instantiate(JengaRotatedPiece, new Vector3(2.5f, (h*2 + 1 ), (w * 1)), Quaternion.identity) as GameObject);
                // JengaRotatedPiecesArr[w].name = ("JengaRotatedPiece" + " " + JP++);
                // JengaRotatedPiecesArr[w].tag = "JengaPiece";

                // Debug.Log(JengaRotatedPiecesArr[w].name);

                // JengaRotatedPiecesArr[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];
            }
        }
        
        for (var t = 0; t < 27; t++)
        {   JengaPiecesArr[t].name = ("JengaPiece" + " " + JP++);
            // Debug.Log(JengaPiecesArr[t]);

            JengaRotatedPiecesArr[t].name = ("JengaRotatedPiece" + " " + JP++);
            // Debug.Log(JengaRotatedPiecesArr[t]);
        }





        // int ArrSize = JengaTowerWidth * JengaTowerHeight/2;
        
        // GameObject[] JengaPiecesArr = new GameObject[ArrSize];
        // GameObject[] JengaRotatedPiecesArr = new GameObject[ArrSize];

        // for (var h = 0; h < (JengaTowerHeight/2); h++)
        // {
        //     for (var w = 0; w < JengaTowerWidth; w++)
        //     {
        //         JengaPiecesArr[w] = Instantiate(JengaPiece, new Vector3((w + (JengaTowerWidth/2f)), h*2, 1), Quaternion.identity);
        //         JengaPiecesArr[w].name = ("JengaPiece" + " " + JP++);
        //         JengaPiecesArr[w].tag = "JengaPiece";

        //         // Debug.Log(JengaPiecesArr[w].name);

        //         // JengaPiecesArr[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];

        //         JengaRotatedPiecesArr[w] = Instantiate(JengaRotatedPiece, new Vector3(2.5f, (h*2 + 1 ), (w * 1)), Quaternion.identity);
        //         JengaRotatedPiecesArr[w].name = ("JengaPiece" + " " + JP++);
        //         JengaRotatedPiecesArr[w].tag = "JengaPiece";

        //         // Debug.Log(JengaRotatedPiecesArr[w].name);

        //         // JengaRotatedPiecesArr[w].GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];
        //     }
        // }
    }

    void RemoveTest()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Destroy(JengaPiecesArr[3]);
        }
        // for (var t = 0; t < 27; t++)
        // {   JengaPiecesArr[t].name = ("JengaPiece" + " " + JP++);
        //     Debug.Log(JengaPiecesArr[t]);

        //     JengaRotatedPiecesArr[t].name = ("JengaRotatedPiece" + " " + JP++);
        //     Debug.Log(JengaRotatedPiecesArr[t]);
        // }
    }
}
