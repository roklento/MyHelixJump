using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed;

    private void Start()
    {
        offset = transform.localPosition - target.localPosition;

    }

    private void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.localPosition, target.localPosition + offset, smoothSpeed);
        transform.position = newPos;
    }
}
