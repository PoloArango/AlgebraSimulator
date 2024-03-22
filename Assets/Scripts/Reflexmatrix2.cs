using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class Reflexmatrix2: MonoBehaviour
{
    [SerializeField] GameObject originalVector;

    [Header("Reflex matrix")]
    public TMP_InputField XInputField;
    public TMP_InputField YInputField;
    public TMP_InputField ZInputField;


    private float[,] matrixValues = new float[3, 3];
    private Matrix3x3 reflexMatrix;

    // Start is called before the first frame update
    void Start()
    {
        UpdateReflexMatrix();
    }

    public void UpdateReflexMatrix()
    {
        float row1X = XInputField.text == "" ? 1 : float.Parse(XInputField.text);
        float row1Y = 0;
        float row1Z = 0;


        float row2X = 0;
        float row2Y = YInputField.text == "" ? 1 : float.Parse(YInputField.text);
        float row2Z = 0;

        float row3X = 0;
        float row3Y = 0;
        float row3Z = ZInputField.text == "" ? 1 : float.Parse(ZInputField.text);

        matrixValues = new float[3, 3]
        {
            { row1X, row1Y, row1Z },
            { row2X, row2Y, row2Z },
            { row3X, row3Y, row3Z }
        };
        reflexMatrix = new Matrix3x3(matrixValues);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateReflexMatrix();
        Vector3 vectorOriginalPos = originalVector.transform.position;
        this.transform.position = reflexMatrix.MultiplyVector(vectorOriginalPos);
    }
}
