using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{

    public GameObject JengaPiece;
    public List<GameObject> JengaPiecesList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PausedScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PausedScreen()
    {
        int width = 0;
        int height = 0;
        int maxAmountOfPieces = 320;

        int piecesInRow = 0;

        // if (JengaPiecesList.Count < maxAmountOfPieces)
        // {
        //     for (int w = 0; w < 10; w++)
        //     {
        //         for (int h = 0; h < 10; h++)
        //         {
        //             maxAmountOfPieces++;
        //             JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3(width, height, 0), Quaternion.identity) as GameObject);
        //             width += 3;
        //             if (w == 10)
        //             {
        //                 w = 0;
        //                 width = 0;
        //                 height += 3;
        //             }

        //         }
        //     }
        // }
    
        while(JengaPiecesList.Count < maxAmountOfPieces)
        {
            JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3((gameObject.transform.position.x + width), height, 0), Quaternion.identity) as GameObject);
            width += 3;
            piecesInRow++;
            if (piecesInRow == 10)
            {
                piecesInRow = 0;
                width = 0;
                height += 1;
            }
        }
    }
}
