using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// trying somehthing hereeeeeeeee
// need to this at home



// adding something betweeen the rounds

public class RoundManager : MonoBehaviour
{
    public bool functionCalled = false;
    
    [SerializeField] private Image playerIcon;

    CameraController cameraController;
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        if(cameraController.selectedPiece == null) return;
        if(!cameraController.selectedPiece.isNotColliding)
        {
            if (!functionCalled)
            {
                functionCalled = true;
                Debug.Log("next player");
                
                ChangePlayerIcon();
                return; 
            }
        }

        if(cameraController.selectedPiece.isNotColliding)
        {
            if (functionCalled)
            {
                functionCalled = false;
                return; 
            }
        }
        
        
    }

    void ChangePlayerIcon()
    {
        playerIcon.enabled = !playerIcon.enabled;
    }


 
}
