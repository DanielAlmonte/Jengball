using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{

    public GameObject JengaPiece;
    public GameObject Barrier;
    public List<GameObject> JengaPiecesList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PausedScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Barrier.SetActive(false);
        }
    }

    void PausedScreen()
    {
        int width = 0;
        int height = 0;
        int maxAmountOfPieces = 320;

        int piecesInRow = 0;
    
        while(JengaPiecesList.Count < maxAmountOfPieces)
        {
            JengaPiecesList.Add(Instantiate(JengaPiece, new Vector3((gameObject.transform.position.x + width), height, 0), Quaternion.Euler (-90f, 90f, 0f)) as GameObject);
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