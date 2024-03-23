using UnityEngine;

public class Matrix4x4Class
{
    // 4x4 matrix values
    public float[,] values = new float[4, 4];

    // Constructor to initialize the matrix with input values
    public Matrix4x4Class(float[,] inputValues)
    {
        SetMatrixValues(inputValues);
    }

    // Method to update the matrix with new values
    public void UpdateMatrix(float[,] inputValues)
    {
        SetMatrixValues(inputValues);
    }

    // Set the matrix values with input values
    private void SetMatrixValues(float[,] inputValues)
    {
        // Check if input values represent a 4x4 matrix
        if (inputValues.GetLength(0) != 4 || inputValues.GetLength(1) != 4)
        {
            Debug.LogError("Input values must be a 4x4 matrix");
            return;
        }

        // Update the matrix values
        values = inputValues;
    }

    // Multiply the matrix with a 4-dimensional vector
    public Vector4 MultiplyVector(Vector4 vector)
    {
        Vector4 result = new Vector4();

        // Perform matrix multiplication
        result.x = values[0, 0] * vector.x + values[0, 1] * vector.y + values[0, 2] * vector.z + values[0, 3] * vector.w;
        result.y = values[1, 0] * vector.x + values[1, 1] * vector.y + values[1, 2] * vector.z + values[1, 3] * vector.w;
        result.z = values[2, 0] * vector.x + values[2, 1] * vector.y + values[2, 2] * vector.z + values[2, 3] * vector.w;
        result.w = values[3, 0] * vector.x + values[3, 1] * vector.y + values[3, 2] * vector.z + values[3, 3] * vector.w;

        return result;
    }
}

