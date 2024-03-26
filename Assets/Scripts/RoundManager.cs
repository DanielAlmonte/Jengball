using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// trying somehthing hereeeeeeeee
// need to this at home

public class RoundManager : MonoBehaviour
{
    public bool player1Turn = true, player2Turn = false;
    
    [SerializeField] private Image player1Icon;
    [SerializeField] private Image player2Icon;

   

    CameraController cameraController;
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        
        player1Icon.color = Color.white;
        player2Icon.color = Color.white;

        
    }

    void Update()
    {
        CheckWhosTurn();
    }

       void CheckWhosTurn()
    {
        if(cameraController.selectedPiece == null) return;        
        if(!cameraController.selectedPiece.isColliding) return; 

        // player 1 aan de ganng
        if(cameraController.selectedPiece.selected)
        {
            Debug.Log("player 1 turn");
            player1Turn = true;
            player2Turn = false;
        }
        else
        {
            Debug.Log("player 2 turn");
            player1Turn = false;
            player2Turn = true;
        }        
        ChangePlayerIcon();
    }

    void ChangePlayerIcon()
    {
        if(player1Turn) 
        {
            player1Icon.color = Color.red;
            player2Icon.color = Color.white;
        }
        if(player2Turn)
        {
            player2Icon.color = Color.green;
            player1Icon.color = Color.white;
        }
    }

 
}
