using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProductManager : MonoBehaviour
{// GameObjects que representan los vectores y el resultado del producto cruz
    [SerializeField] GameObject vector1; // Primer vector
    [SerializeField] GameObject vector2; // Segundo vector
    [SerializeField] GameObject v1Crossv2; // Resultado del producto cruz

    void Update()
    {
        // Obtener las posiciones de los GameObjects que representan los vectores
        Vector3 v1 = vector1.transform.position;
        Vector3 v2 = vector2.transform.position;

        // Calcular el producto cruz y establecer la posición del resultado
        v1Crossv2.transform.position = CrossProduct(v1, v2);
    }

    // Método para calcular el producto cruz de dos vectores
    private Vector3 CrossProduct(Vector3 p, Vector3 q)
    {
        // Calcular las componentes del resultado del producto cruz
        float x = p.y * q.z - p.z * q.y;
        float y = p.z * q.x - p.x * q.z;
        float z = p.x * q.y - p.y * q.x;

        // Crear un nuevo vector con las componentes calculadas
        return new Vector3(x, y, z);
    }
}
