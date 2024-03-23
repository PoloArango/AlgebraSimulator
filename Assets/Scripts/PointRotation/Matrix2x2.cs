using UnityEngine;

public class Matrix2x2
{
    // Array para almacenar los valores de la matriz
    public float[,] values = new float[2, 2];

    // Constructor que inicializa la matriz con valores dados
    public Matrix2x2(float[,] inputValues)
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
        // Verifica si la matriz de entrada es de tama�o 2x2
        if (inputValues.GetLength(0) != 2 || inputValues.GetLength(1) != 2)
        {
            // Muestra un mensaje de error si la matriz no es del tama�o correcto
            Debug.LogError("Input values must be a 2x2 matrix");
            return;
        }

        // Asigna los valores de la matriz de entrada a la matriz actual
        values = inputValues;
    }

    // M�todo para multiplicar la matriz por un vector 2D
    public Vector2 MultiplyVector(Vector2 vector)
    {
        // Crea un nuevo vector para almacenar el resultado de la multiplicaci�n
        Vector2 result = new Vector2();

        // Realiza la multiplicaci�n de la matriz por el vector
        result.x = values[0, 0] * vector.x + values[0, 1] * vector.y;
        result.y = values[1, 0] * vector.x + values[1, 1] * vector.y;

        // Retorna el resultado de la multiplicaci�n
        return result;
    }
}

