using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationPlane();

    }

    void RotationPlane()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, 0.5f, 0.0f, Space.Self);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, -0.5f, 0.0f, Space.Self);

        }
    }
}
