using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawCube : MonoBehaviour
{
    // Objeto para manejar los cuaterniones
    QuaternionManager myQuaternion = new();

    // Componentes de cuaterniones
    [Header("Quaterion component")]
    [SerializeField] Slider angleSlider; // Slider para ajustar el �ngulo de rotaci�n
    [SerializeField] TMP_Text AngleTxt; // Texto para mostrar el �ngulo actual
    public TMP_InputField XInputField; // Campo de entrada para la coordenada X del eje de rotaci�n
    public TMP_InputField YInputField; // Campo de entrada para la coordenada Y del eje de rotaci�n
    public TMP_InputField ZInputField; // Campo de entrada para la coordenada Z del eje de rotaci�n
    Vector3 axis = new Vector3(0, 0, 0); // Vector para almacenar el eje de rotaci�n

    // Componentes de escala
    [Header("Scale component")]
    public Slider sliderScaleX; // Slider para ajustar la escala en el eje X
    public Slider sliderScaleY; // Slider para ajustar la escala en el eje Y
    public Slider sliderScaleZ; // Slider para ajustar la escala en el eje Z
    [SerializeField] Vector3 scale = Vector3.one; // Vector para almacenar la escala actual
    ScaleManager myScale = new(); // Objeto para manejar el escalado

    // Componentes de posici�n
    [Header("Position component")]
    public Slider sliderX; // Slider para ajustar la posici�n en el eje X
    public Slider sliderY; // Slider para ajustar la posici�n en el eje Y
    public Slider sliderZ; // Slider para ajustar la posici�n en el eje Z
    Vector3 position = Vector3.zero; // Vector para almacenar la posici�n actual
    PositionManager myPos = new(); // Objeto para manejar la posici�n

    private LineRenderer lineRenderer; // Componente LineRenderer para dibujar el cubo

    // V�rtices del cubo
    private Vector3[] vertices = new Vector3[]
    {
        new Vector3(-0.5f, -0.5f, -0.5f), // V�rtice 0
        new Vector3(0.5f, -0.5f, -0.5f),  // V�rtice 1
        new Vector3(0.5f, -0.5f, 0.5f),   // V�rtice 2
        new Vector3(-0.5f, -0.5f, 0.5f),  // V�rtice 3
        new Vector3(-0.5f, 0.5f, -0.5f),  // V�rtice 4
        new Vector3(0.5f, 0.5f, -0.5f),   // V�rtice 5
        new Vector3(0.5f, 0.5f, 0.5f),    // V�rtice 6
        new Vector3(-0.5f, 0.5f, 0.5f)    // V�rtice 7
    };

    // M�todo llamado al inicio
    private void Start()
    {
        // Obtener el componente LineRenderer adjunto a este objeto
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Actualizar el eje de rotaci�n desde los campos de entrada
        axis = UpdateReflexMatrix();

        // Actualizar la posici�n desde los sliders
        position = UpdatePositionSlider();

        // Actualizar la escala desde los sliders
        scale = UpdateScaleSlider();

        // Obtener el �ngulo del slider y mostrarlo en el texto
        float angle = angleSlider.value;
        AngleTxt.text = "Angulo " + angle + " �";

        // Reiniciar la posici�n del cubo
        RestartCubePosition();

        // Rotar el cubo
        RotationCube();

        // Redimensionar el cubo
        ResizeCube();

        // Establecer la posici�n del cubo
        SetPosition();

        // Dibujar el cubo en 3D
        DrawCube3D();
    }
    // M�todo para actualizar el eje de rotaci�n desde los campos de entrada
    public Vector3 UpdateReflexMatrix()
    {
        float inputX = XInputField.text == "" ? 0 : float.Parse(XInputField.text);
        float inputY = YInputField.text == "" ? 0 : float.Parse(YInputField.text);
        float inputZ = ZInputField.text == "" ? 0 : float.Parse(ZInputField.text);

        // Devolver el vector de rotaci�n construido a partir de los valores de entrada
        Vector3 vectorOut = new Vector3(inputX, inputY, inputZ);
        return vectorOut;
    }

    // M�todo para actualizar la posici�n desde los sliders
    public Vector3 UpdatePositionSlider()
    {
        // Obtener los valores de los sliders para X, Y y Z
        float newX = sliderX.value;
        float newY = sliderY.value;
        float newZ = sliderZ.value;

        // Devolver un vector con los valores actualizados
        Vector3 vectorOut = new Vector3(newX, newY, newZ);
        return vectorOut;
    }

    // M�todo para actualizar la escala desde los sliders
    public Vector3 UpdateScaleSlider()
    {
        // Obtener los valores de los sliders para X, Y y Z
        float newX = sliderScaleX.value;
        float newY = sliderScaleY.value;
        float newZ = sliderScaleZ.value;

        // Devolver un vector con los valores actualizados
        Vector3 vectorOut = new Vector3(newX, newY, newZ);
        return vectorOut;
    }

    // M�todo para reiniciar la posici�n del cubo
    private void RestartCubePosition()
    {
        // Definir nuevamente los v�rtices del cubo
        vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // V�rtice 0
            new Vector3(0.5f, -0.5f, -0.5f),  // V�rtice 1
            new Vector3(0.5f, -0.5f, 0.5f),   // V�rtice 2
            new Vector3(-0.5f, -0.5f, 0.5f),  // V�rtice 3
            new Vector3(-0.5f, 0.5f, -0.5f),  // V�rtice 4
            new Vector3(0.5f, 0.5f, -0.5f),   // V�rtice 5
            new Vector3(0.5f, 0.5f, 0.5f),    // V�rtice 6
            new Vector3(-0.5f, 0.5f, 0.5f)    // V�rtice 7
        };
    }

    // M�todo para dibujar el cubo en 3D
    private void DrawCube3D()
    {
        // Configurar el LineRenderer para dibujar el cubo
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);

        // Definir los �ndices de los v�rtices que forman las l�neas del cubo
        int[] cubeIndices = new int[]
        {
            0, 1, 1, 2, 2, 3, 3, 0, // Cara inferior
            4, 5, 5, 6, 6, 7, 7, 4, // Cara superior
            0, 4, 1, 5, 2, 6, 3, 7  // Conexiones verticales
        };

        // Dibujar las l�neas que conectan los v�rtices del cubo
        lineRenderer.positionCount = cubeIndices.Length;
        for (int i = 0; i < cubeIndices.Length; i++)
        {
            lineRenderer.SetPosition(i, vertices[cubeIndices[i]]);
        }
    }

    // M�todo para rotar el cubo
    private void RotationCube()
    {
        // Rotar cada v�rtice del cubo alrededor del eje especificado con el �ngulo dado
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myQuaternion.RotatePoint(angleSlider.value, axis, vertices[i]);
        }
    }

    // M�todo para redimensionar el cubo
    private void ResizeCube()
    {
        // Redimensionar cada v�rtice del cubo seg�n la escala especificada
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myScale.ScalePoint(scale, vertices[i]);
        }
    }

    // M�todo para establecer la posici�n del cubo
    private void SetPosition()
    {
        // Mover cada v�rtice del cubo a la posici�n especificada
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myPos.SetPointPos(position, vertices[i]);
        }
    }
}