using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RotationManager : MonoBehaviour
{
    // �ngulo de rotaci�n, ajustable desde el Inspector
    [SerializeField]
    [Range(0, 360)]
    private float angle = 0.0f;

    // Referencia al componente TMP_Text para mostrar el �ngulo
    [SerializeField]
    private TMP_Text AngleTxt;

    // Matriz de rotaci�n
    private Matrix2x2 RotationMatrix = new Matrix2x2(new float[2, 2]{
        {1, 0},
        {0, 1}
    });

    // Referencia al componente Slider para ajustar el �ngulo
    [SerializeField]
    private Slider angleSlider;

    // Posici�n inicial del objeto
    private Vector2 initPos = new Vector2();

    // M�todo llamado al inicio
    private void Start()
    {
        // Almacena la posici�n inicial del objeto
        initPos = transform.position;
    }

    private void Update()
    {
        // Reinicia la posici�n del objeto
        this.transform.position = initPos;

        // Obtiene la posici�n del objeto en forma de vector 2D
        Vector2 p = transform.position;

        // Actualiza el �ngulo desde el valor del Slider en la interfaz de usuario
        angle = angleSlider.value;
        AngleTxt.text = "Angulo " + angle + " �";

        // Calcula el coseno y el seno del �ngulo (en radianes)
        float cos = Mathf.Cos(angle * Mathf.PI / 180f);
        float sin = Mathf.Sin(angle * Mathf.PI / 180f);

        // Actualiza la matriz de rotaci�n con los nuevos valores
        RotationMatrix.UpdateMatrix(new float[2, 2]
        {
            {cos, -sin},
            {sin, cos}
        });

        // Calcula la nueva posici�n del objeto despu�s de la rotaci�n y la actualiza
        this.transform.position = RotationMatrix.MultiplyVector(p);
    }
}
