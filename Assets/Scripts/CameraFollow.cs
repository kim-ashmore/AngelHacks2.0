using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* From Brakey's Video */

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.25f;
    public Vector3 offset;

    void LateUpdate () {

      Vector3 desiredPosition = target.position + offset;

      // Without smooth Camera positioning
      transform.position = desiredPosition;

      // With smooth positioning
      //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
      //transform.position = smoothedPosition;

      transform.LookAt(target);
    }
}
