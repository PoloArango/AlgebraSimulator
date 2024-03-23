using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix3x3
{
    // Array para almacenar los valores de la matriz
    public float[,] values = new float[3, 3];

    // Constructor para inicializar la matriz con valores dados
    public Matrix3x3(float[,] inputValues)
    {
        // Llama al m�todo para establecer los valores de la matriz
        SetMatrixValues(inputValues);
    }

    // M�todo para actualizar la matriz con nuevos valores
    public void UpdateMatrix(float[,] inputValues)
    {
        // Llama al m�todo para establecer los valores de la matriz
        SetMatrixValues(inputValues);
    }

    // M�todo privado para establecer los valores de la matriz
    private void SetMatrixValues(float[,] inputValues)
    {
        // Verifica si la matriz de entrada es de tama�o 3x3
        if (inputValues.GetLength(0) != 3 || inputValues.GetLength(1) != 3)
        {
            // Muestra un mensaje de error si la matriz no es del tama�o correcto
            Debug.LogError("Input values must be 3x3 matrix");
            return;
        }

        // Asigna los valores de la matriz de entrada a la matriz actual
        values = inputValues;
    }

    // M�todo para multiplicar la matriz por un vector 3D
    public Vector3 MultiplyVector(Vector3 vector)
    {
        // Vector para almacenar el resultado de la multiplicaci�n
        Vector3 result = new Vector3();

        // Realiza la multiplicaci�n de la matriz por el vector
        result.x = values[0, 0] * vector.x + values[0, 1] * vector.y + values[0, 2] * vector.z;
        result.y = values[1, 0] * vector.x + values[1, 1] * vector.y + values[1, 2] * vector.z;
        result.z = values[2, 0] * vector.x + values[2, 1] * vector.y + values[2, 2] * vector.z;

        // Retorna el resultado de la multiplicaci�n
        return result;
    }
}
