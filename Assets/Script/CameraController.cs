using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 posOffset;
    public float smooth;
    public Vector2 xLimit;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + posOffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x,xLimit.x, xLimit.y), -0.78f, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);
    }
}
