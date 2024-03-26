using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnOffInput : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCamera;
    void Start()
    {
        if (freeLookCamera == null)
        {
            Debug.LogError("Component to toggle is not assigned!", this);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            ToggleComponent();
        }

        if (Input.GetMouseButtonUp(1)) // Right mouse button
        {
            ToggleComponent();
        }
    }

    void ToggleComponent()
    {
        if (freeLookCamera != null)
        {
            freeLookCamera.enabled = !freeLookCamera.enabled;
            Debug.Log(freeLookCamera.GetType().Name + " is now " + (freeLookCamera.enabled ? "enabled" : "disabled"));
        }
    }
}
