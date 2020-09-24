using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;


    void Update()
    {
            
    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x + 6f, transform.position.y, transform.position.z);
        }
    }
}
