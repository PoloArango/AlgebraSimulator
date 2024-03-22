using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    [Header("Inital Panel")]
    public GameObject initialPanel;

    //Scenes of the different options of the initial panel

    [Header("Cross product elements")]
    [SerializeField] private GameObject[] crossProductElementsInit;
    [SerializeField] private GameObject[] crossProductElementsEnd;
    [Header("Dot product elements")]
    [SerializeField] private GameObject[] dotProductElementsInit;
    [SerializeField] private GameObject[] dotProductElementsEnd;
    [Header("Reflex elements")]
    [SerializeField] private GameObject[] reflexElementsInit;
    [SerializeField] private GameObject[] reflexElementsEnd;
    [Header("Quaternion elements")]
    [SerializeField] private GameObject[] quaternionElementsInit;
    [SerializeField] private GameObject[] quaternionElementsEnd;
    [Header("Matrix transform elements")]
    [SerializeField] private GameObject[] matrixTransformElementsInit;
    [SerializeField] private GameObject[] matrixTransformElementsEnd;
    [Header("Rotation elements")]
    [SerializeField] private GameObject[] rotationElementsInit;
    [SerializeField] private GameObject[] rotationElementsEnd;

    // Start is called before the first frame update
    void Start()
    {
        initialPanel.SetActive(true);
    }

    public void TrueCrossProductElements()
    {
        TrueElements(crossProductElementsInit);
    }
    public void TrueDotProductElements()
    {
        TrueElements(dotProductElementsInit);
    }
    public void TrueReflexElements()
    {
        TrueElements(reflexElementsInit);
    }
    public void TrueQuaternionElements()
    {
        TrueElements(quaternionElementsInit);
    }
    public void TrueMatrixTransformElements()
    {
        TrueElements(matrixTransformElementsInit);
    }
    public void TrueRotationElements()
    {
        TrueElements(rotationElementsInit);
    }
    public void BackElements()
    {
        Back(rotationElementsInit);
        Back(rotationElementsEnd);
        Back(matrixTransformElementsInit);
        Back(matrixTransformElementsEnd);
        Back(quaternionElementsInit);
        Back(quaternionElementsEnd);
        Back(reflexElementsInit);
        Back(reflexElementsEnd);
        Back(dotProductElementsInit);
        Back(dotProductElementsEnd);
        Back(crossProductElementsInit);
        Back(crossProductElementsEnd);
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
