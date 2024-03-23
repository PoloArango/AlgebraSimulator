using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform sceneCenter;
    public float rotationSpeed = 5f;
    public float zoomSpeed = 5f;
    public float minDistance = 1f;
    public float maxDistance = 10f;

    private float currentDistance;

    void Start()
    {
        currentDistance = Vector3.Distance(transform.position, sceneCenter.position);
    }

    void Update()
    {
        // Horizontal rotation (Y axis)
        float inputHorizontalRotation = Input.GetAxis("Horizontal");
        transform.RotateAround(sceneCenter.position, Vector3.up, inputHorizontalRotation * rotationSpeed * Time.deltaTime);

        // Zoom (move closer or further)
        float inputZoom = Input.GetAxis("Mouse ScrollWheel");
        currentDistance = Mathf.Clamp(currentDistance - inputZoom * zoomSpeed, minDistance, maxDistance);
        Vector3 direction = (transform.position - sceneCenter.position).normalized;
        transform.position = sceneCenter.position + direction * currentDistance;
    }
}

