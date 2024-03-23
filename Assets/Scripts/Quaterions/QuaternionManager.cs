using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionManager
{
    // M�todo para rotar un punto alrededor de un eje dado un �ngulo
    public Vector3 RotatePoint(float angle, Vector3 axis, Vector3 p)
    {
        // Convertir el �ngulo de grados a radianes
        float radianAngle = angle * Mathf.PI / 180;

        // Llamar al m�todo est�tico Rotate de MyQuaternion para realizar la rotaci�n
        return MyQuaternion.Rotate(p, axis, radianAngle);
    }
}

public struct MyQuaternion
{
    // Componentes de un cuaterni�n
    private float x;
    private float y;
    private float z;
    private float w;

    // Constructor para inicializar un cuaterni�n
    public MyQuaternion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    // M�todo est�tico para calcular el cuaterni�n de rotaci�n dado un �ngulo y un eje
    private static MyQuaternion RotationQuaternion(float angle, Vector3 axis)
    {
        // Calcular el seno y coseno del �ngulo dividido por 2
        float sin = Mathf.Sin(angle / 2f);
        float cos = Mathf.Cos(angle / 2f);

        // Normalizar el eje de rotaci�n y multiplicar por el seno
        Vector3 v = Vector3.Normalize(axis) * sin;

        // Construir el cuaterni�n de rotaci�n
        return new MyQuaternion(v.x, v.y, v.z, cos);
    }

    // M�todo est�tico para calcular el conjugado de un cuaterni�n
    private static MyQuaternion ConjugateQuaternion(MyQuaternion q)
    {
        // Invertir la parte vectorial y mantener la parte escalar
        float s = q.w;
        Vector3 v = new Vector3(-q.x, -q.y, -q.z);

        // Construir el cuaterni�n conjugado
        return new MyQuaternion(v.x, v.y, v.z, s);
    }

    // M�todo est�tico para calcular el producto de dos cuaterniones
    private static MyQuaternion QuaternionProduct(MyQuaternion q1, MyQuaternion q2)
    {
        // Extraer las partes escalares y vectoriales de ambos cuaterniones
        float s1 = q1.w;
        float s2 = q2.w;
        Vector3 v1 = new Vector3(q1.x, q1.y, q1.z);
        Vector3 v2 = new Vector3(q2.x, q2.y, q2.z);

        // Calcular el producto de los cuaterniones
        float s = s1 * s2 - Vector3.Dot(v1, v2);
        Vector3 v = s1 * v2 + s2 * v1 + Vector3.Cross(v1, v2);

        // Construir el cuaterni�n resultante
        return new MyQuaternion(v.x, v.y, v.z, s);
    }

    // M�todo est�tico para rotar un punto dado un cuaterni�n de rotaci�n
    public static Vector3 Rotate(Vector3 point, Vector3 axis, float angle)
    {
        // Calcular el cuaterni�n de rotaci�n
        MyQuaternion q = RotationQuaternion(angle, axis);

        // Calcular el conjugado del cuaterni�n de rotaci�n
        MyQuaternion _q = ConjugateQuaternion(q);

        // Construir el cuaterni�n a partir del punto
        MyQuaternion p = new MyQuaternion(point.x, point.y, point.z, 0f);

        // Realizar la rotaci�n del punto mediante cuaterniones
        MyQuaternion rotatedPoint = QuaternionProduct(q, p);
        rotatedPoint = QuaternionProduct(rotatedPoint, _q);

        // Retornar el punto rotado como un vector
        return new Vector3(rotatedPoint.x, rotatedPoint.y, rotatedPoint.z);
    }
}
