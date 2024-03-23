using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVector : MonoBehaviour
{
    // Punto de origen del vector (por defecto, el origen del mundo)
    private Vector3 p0 = Vector3.zero;

    // Punto final del vector (inicialmente igual a la posición del objeto)
    private Vector3 p1 = new Vector3();

    // Referencia al componente LineRenderer
    private LineRenderer lineRenderer;

    void Start()
    {
        // Obtener el componente LineRenderer adjunto a este objeto
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Actualizar el punto final del vector con la posición actual del objeto
        p1 = transform.position;

        // Establecer los puntos de inicio y fin para el LineRenderer
        lineRenderer.SetPositions(new Vector3[] { p0, p1 });
    }
}
