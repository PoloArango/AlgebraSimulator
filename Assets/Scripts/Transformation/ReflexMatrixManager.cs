using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexMatrixManager : MonoBehaviour
{
    // Objeto original que se va a reflejar
    [SerializeField] GameObject originalVector;

    // Vectores que representan las filas de la matriz de reflexi�n
    [Header("Reflex matrix")]
    [SerializeField] Vector3 row1 = new Vector3(1, 0, 0);
    [SerializeField] Vector3 row2 = new Vector3(0, 1, 0);
    [SerializeField] Vector3 row3 = new Vector3(0, 0, 1);

    // Matriz de reflexi�n y valores de la matriz
    private float[,] matrixValues = new float[3, 3];
    private Matrix3x3 reflexMatrix;

    // M�todo llamado al inicio del juego
    void Start()
    {
        // Inicializa la matriz de reflexi�n
        UpdateReflexMatrix();
    }

    // M�todo para actualizar la matriz de reflexi�n con los valores de los vectores
    public void UpdateReflexMatrix()
    {
        // Actualiza los valores de la matriz utilizando los vectores definidos
        matrixValues = new float[3, 3]
        {
            { row1.x, row1.y, row1.z },
            { row2.x, row2.y, row2.z },
            { row3.x, row3.y, row3.z }
        };

        // Crea una nueva instancia de la matriz de reflexi�n con los valores actualizados
        reflexMatrix = new Matrix3x3(matrixValues);
    }

    // M�todo llamado en cada frame
    void Update()
    {
        // Actualiza la matriz de reflexi�n
        UpdateReflexMatrix();

        // Obtiene la posici�n del objeto original
        Vector3 vectorOriginalPos = originalVector.transform.position;

        // Aplica la reflexi�n multiplicando la posici�n original por la matriz de reflexi�n
        this.transform.position = reflexMatrix.MultiplyVector(vectorOriginalPos);
    }
}
