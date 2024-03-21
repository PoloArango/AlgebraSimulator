using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    [Header("Inital Panel")]
    public GameObject initialPanel;

    //Scenes of the different options of the initial panel

    [Header("Cross product elements")]
    [SerializeField] private GameObject[] crossProductElements;
    [Header("Dot product elements")]
    [SerializeField] private GameObject[] dotProductElements;
    [Header("Reflex elements")]
    [SerializeField] private GameObject[] reflexElements;
    [Header("Quaternion elements")]
    [SerializeField] private GameObject[] quaternionElements;
    [Header("Matrix transform elements")]
    [SerializeField] private GameObject[] matrixTransformElements;
    [Header("Rotation elements")]
    [SerializeField] private GameObject[] rotationElements;
   
    // Start is called before the first frame update
    void Start()
    {
        initialPanel.SetActive(true);
    }

    public void TrueCrossProductElements()
    {
        TrueElements(crossProductElements);
    }
    public void TrueDotProductElements()
    {
        TrueElements(dotProductElements);
    }
    public void TrueReflexElements()
    {
        TrueElements(reflexElements);
    }
    public void TrueQuaternionElements()
    {
        TrueElements(quaternionElements);
    }
    public void TrueMatrixTransformElements()
    {
        TrueElements(matrixTransformElements);
    }
    public void TrueRotationElements()
    {
        TrueElements(rotationElements);
    }
    public void BackElements()
    {
        Back(rotationElements);
        Back(matrixTransformElements);
        Back(quaternionElements);
        Back(reflexElements);
        Back(dotProductElements);
        Back(crossProductElements);
    }

    private void TrueElements(GameObject[] elementos)
    {
        foreach (GameObject elemento in elementos)
        {
            elemento.SetActive(true);
        }
        initialPanel.SetActive(false);
    }

    private void Back(GameObject[] elementos)
    {
        foreach (GameObject elemento in elementos)
        {
            elemento.SetActive(false);
        }
        initialPanel.SetActive(true);
    }

}
