using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionManager
{
    // Método para rotar un punto alrededor de un eje dado un ángulo
    public Vector3 RotatePoint(float angle, Vector3 axis, Vector3 p)
    {
        // Convertir el ángulo de grados a radianes
        float radianAngle = angle * Mathf.PI / 180;

        // Llamar al método estático Rotate de MyQuaternion para realizar la rotación
        return MyQuaternion.Rotate(p, axis, radianAngle);
    }
}

public struct MyQuaternion
{
    // Componentes de un cuaternión
    private float x;
    private float y;
    private float z;
    private float w;

    // Constructor para inicializar un cuaternión
    public MyQuaternion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    // Método estático para calcular el cuaternión de rotación dado un ángulo y un eje
    private static MyQuaternion RotationQuaternion(float angle, Vector3 axis)
    {
        // Calcular el seno y coseno del ángulo dividido por 2
        float sin = Mathf.Sin(angle / 2f);
        float cos = Mathf.Cos(angle / 2f);

        // Normalizar el eje de rotación y multiplicar por el seno
        Vector3 v = Vector3.Normalize(axis) * sin;

        // Construir el cuaternión de rotación
        return new MyQuaternion(v.x, v.y, v.z, cos);
    }

    // Método estático para calcular el conjugado de un cuaternión
    private static MyQuaternion ConjugateQuaternion(MyQuaternion q)
    {
        // Invertir la parte vectorial y mantener la parte escalar
        float s = q.w;
        Vector3 v = new Vector3(-q.x, -q.y, -q.z);

        // Construir el cuaternión conjugado
        return new MyQuaternion(v.x, v.y, v.z, s);
    }

    // Método estático para calcular el producto de dos cuaterniones
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

        // Construir el cuaternión resultante
        return new MyQuaternion(v.x, v.y, v.z, s);
    }

    // Método estático para rotar un punto dado un cuaternión de rotación
    public static Vector3 Rotate(Vector3 point, Vector3 axis, float angle)
    {
        // Calcular el cuaternión de rotación
        MyQuaternion q = RotationQuaternion(angle, axis);

        // Calcular el conjugado del cuaternión de rotación
        MyQuaternion _q = ConjugateQuaternion(q);

        // Construir el cuaternión a partir del punto
        MyQuaternion p = new MyQuaternion(point.x, point.y, point.z, 0f);

        // Realizar la rotación del punto mediante cuaterniones
        MyQuaternion rotatedPoint = QuaternionProduct(q, p);
        rotatedPoint = QuaternionProduct(rotatedPoint, _q);

        // Retornar el punto rotado como un vector
        return new Vector3(rotatedPoint.x, rotatedPoint.y, rotatedPoint.z);
    }
}
