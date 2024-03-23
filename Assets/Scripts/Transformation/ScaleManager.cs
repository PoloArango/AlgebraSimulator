using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager
{
    // Matriz de escala para almacenar la transformación de escala
    Matrix3x3 scaleMatrix = new Matrix3x3(new float[3, 3]
    {
        {1, 0, 0},
        {0, 1, 0},
        {0, 0, 1}
    });

    // Método para escalar un punto dado un factor de escala y el punto en sí
    public Vector3 ScalePoint(Vector3 scale, Vector3 p)
    {
        // Actualiza la matriz de escala con los nuevos valores de escala
        scaleMatrix.UpdateMatrix(new float[3, 3]
        {
            { scale.x, 0, 0 },
            { 0, scale.y, 0 },
            { 0, 0, scale.z }
        });

        // Multiplica el punto por la matriz de escala y retorna el punto escalado
        return scaleMatrix.MultiplyVector(p);
    }
}
