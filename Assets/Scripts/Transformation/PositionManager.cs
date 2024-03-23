using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager
{
    // Matriz de posición y valores de la matriz
    Matrix4x4Class positionMatrix = new Matrix4x4Class(new float[4, 4]
    {
        {1,0,0,0},
        {0,1,0,0},
        {0,0,1,0},
        {0,0,0,1},
    });

    // Método para establecer la posición de un punto
    public Vector3 SetPointPos(Vector3 newPos, Vector3 _p)
    {
        // Actualiza la matriz de posición con los nuevos valores de posición
        positionMatrix.UpdateMatrix(new float[4, 4]
        {
            { 1,0,0,newPos.x },
            { 0,1,0,newPos.y },
            { 0,0,1,newPos.z},
            { 0,0,0,1 }
        });

        // Convierte el punto a un vector homogéneo de 4 dimensiones
        Vector4 p = new Vector4(_p.x, _p.y, _p.z, 1);

        // Aplica la transformación de posición multiplicando el punto por la matriz de posición
        Vector4 newP = positionMatrix.MultiplyVector(p);

        // Convierte el resultado de nuevo a un vector tridimensional y lo devuelve
        return new Vector3(newP.x, newP.y, newP.z);
    }
}