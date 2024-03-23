using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class Reflexmatrix2: MonoBehaviour
{
    // Objeto original que se va a reflejar
    [SerializeField] GameObject originalVector;

    // Campos de entrada para los valores de la matriz de reflexi�n
    [Header("Reflex matrix")]
    public TMP_InputField XInputField; // Campo de entrada para el valor X de la fila 1
    public TMP_InputField YInputField; // Campo de entrada para el valor Y de la fila 2
    public TMP_InputField ZInputField; // Campo de entrada para el valor Z de la fila 3

    // Matriz de reflexi�n y valores de la matriz
    private float[,] matrixValues = new float[3, 3];
    private Matrix3x3 reflexMatrix;

    // M�todo llamado al inicio del juego
    void Start()
    {
        // Actualiza la matriz de reflexi�n al inicio
        UpdateReflexMatrix();
    }

    // M�todo para actualizar la matriz de reflexi�n con los valores de los campos de entrada
    public void UpdateReflexMatrix()
    {
        // Obtiene los valores ingresados en los campos de entrada, si est�n vac�os se asigna el valor predeterminado 1
        float row1X = XInputField.text == "" ? 1 : float.Parse(XInputField.text);
        float row1Y = 0;
        float row1Z = 0;

        float row2X = 0;
        float row2Y = YInputField.text == "" ? 1 : float.Parse(YInputField.text);
        float row2Z = 0;

        float row3X = 0;
        float row3Y = 0;
        float row3Z = ZInputField.text == "" ? 1 : float.Parse(ZInputField.text);

        // Actualiza la matriz de valores con los valores obtenidos
        matrixValues = new float[3, 3]
        {
            { row1X, row1Y, row1Z },
            { row2X, row2Y, row2Z },
            { row3X, row3Y, row3Z }
        };

        // Crea una nueva instancia de la matriz de reflexi�n con los valores actualizados
        reflexMatrix = new Matrix3x3(matrixValues);
    }

    // M�todo llamado en cada frame
    void Update()
    {
        // Actualiza la matriz de reflexi�n
        UpdateReflexMatrix();

        // Obtiene la posici�n del objeto original
        Vector3 vectorOriginalPos = originalVector.transform.position;

        // Aplica la reflexi�n multiplicando la posici�n original por la matriz de reflexi�n
        this.transform.position = reflexMatrix.MultiplyVector(vectorOriginalPos);
    }
}