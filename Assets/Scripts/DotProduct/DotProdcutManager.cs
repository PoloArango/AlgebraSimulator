using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DotProdcutManager : MonoBehaviour
{
    [SerializeField] GameObject Vector1; // Primer vector
    [SerializeField] GameObject Vector2; // Segundo vector
    [SerializeField] TMP_Text v1dotv2Txt; // Texto para mostrar el resultado del producto punto

    void Update()
    {
        // Obtener las posiciones de los vectores GameObject
        Vector3 v1 = Vector1.transform.position;
        Vector3 v2 = Vector2.transform.position;

        // Calcular el producto punto y mostrar el resultado en el texto
        v1dotv2Txt.text = "V1.V2 = " + DotProduct(v1, v2, Vector3.zero);
    }

    // Método para calcular el producto punto de dos vectores
    private string DotProduct(Vector3 p0, Vector3 p1, Vector3 c)
    {
        // Normaliza los vectores desde el centro del mundo
        Vector3 a = (p0 - c).normalized;
        Vector3 b = (p1 - c).normalized;

        // Calcula el producto punto
        float adotb = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);

        // Devuelve el resultado formateado como string
        return adotb.ToString("F1"); // "F1" significa que mostrará solo un dígito decimal
    }
}
