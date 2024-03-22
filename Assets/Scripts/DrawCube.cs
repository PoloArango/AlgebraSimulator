using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawCube : MonoBehaviour
{
    QuaternionManager myQuaternion = new();
    [Header("Quaterion component")]
    [SerializeField] Slider angleSlider;
    [SerializeField] TMP_Text AngleTxt;
    float angle = 0;
    public TMP_InputField XInputField;
    public TMP_InputField YInputField;
    public TMP_InputField ZInputField;
    Vector3 axis = new Vector3(0, 0, 0);

    [Header("Scale component")]
    public Slider sliderScaleX;
    public Slider sliderScaleY;
    public Slider sliderScaleZ;
    [SerializeField] Vector3 scale = Vector3.one;
    ScaleManager myScale = new();

    [Header("Position component")]
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    Vector3 position = Vector3.zero;
    PositionManager myPos = new();

    private LineRenderer lineRenderer;

    private Vector3[] vertices = new Vector3[]
    {        
        new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
        new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
        new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
        new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
        new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
        new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
        new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
        new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7

    };

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        axis = UpdateReflexMatrix();
        position = UpdatePositionSlider();
        scale = UpdateScaleSlider();

        angle = angleSlider.value;
        AngleTxt.text = "Angulo " + angle + " °";

        RestartCubePosition();
        RotationCube();
        ResizeCube();
        SetPosition();
        DrawCube3D();
    }

    public Vector3 UpdateReflexMatrix()
    {
        float inputX = XInputField.text == "" ? 0 : float.Parse(XInputField.text);
        float inputY = YInputField.text == "" ? 0 : float.Parse(YInputField.text);
        float inputZ = ZInputField.text == "" ? 0 : float.Parse(ZInputField.text);

        Vector3 vectorOut = new Vector3(inputX, inputY, inputZ);

        return vectorOut;
    }

    public Vector3 UpdatePositionSlider()
    {
        float newX = sliderX.value;
        float newY = sliderY.value;
        float newZ = sliderZ.value;

        Vector3 vectorOut = new Vector3(newX, newY, newZ);

        return vectorOut;
    }

    public Vector3 UpdateScaleSlider()
    {
        float newX = sliderScaleX.value;
        float newY = sliderScaleY.value;
        float newZ = sliderScaleZ.value;

        Vector3 vectorOut = new Vector3(newX, newY, newZ);

        return vectorOut;
    }




    private void RestartCubePosition()
    {
        vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
            new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
            new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
            new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
            new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
            new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
            new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
            new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7

        };
    }

    private void DrawCube3D()
    {
        // vertex on linerenderer
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);

        // define lines that conect vertex
        int[] cubeIndex = new int[]
        {
            0,1,1,2,2,3,3,0, // bottom cube face
            4,5,5,6,6,7,7,4, // upper cube face
            0,4,1,5,2,6,3,7
        };

        // draw lines
        lineRenderer.positionCount = cubeIndex.Length;
        for(int i = 0; i < cubeIndex.Length; i++)
        {
            lineRenderer.SetPosition(i, vertices[cubeIndex[i]]);
        }
    }

    private void RotationCube()
    {
        for (int i = 0;i < vertices.Length;i++)
        {
            vertices[i] = myQuaternion.RotatePoint(angle, axis, vertices[i]);
        }
    }

    private void ResizeCube()
    {
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myScale.ScalePoint(scale, vertices[i]);
        }
    }

    private void SetPosition()
    {
        for(int i=0; i < vertices.Length; i++)
        {
            vertices[i] = myPos.SetPointPos(position, vertices[i]);
        }
    }
}
