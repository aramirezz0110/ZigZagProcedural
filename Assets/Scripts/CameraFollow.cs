using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    private Vector3 distanceBetween;
    private void Awake()
    {
        distanceBetween = transform.position - followTarget.position;
    }
    private void LateUpdate()
    {
        transform.position = followTarget.position + distanceBetween;
    }
}
