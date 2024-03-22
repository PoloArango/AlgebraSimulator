using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrueFalse : MonoBehaviour
{
    [SerializeField] private GameObject[] UIExample;
    [SerializeField] private GameObject[] UIPractice;

    private bool ElementsTrue = true; 

    public void AltTrueFalse()
    {
        if (ElementsTrue)
        {
            FalseObject(UIExample);
            TrueObject(UIPractice);
        }
        else
        {
            FalseObject(UIPractice);
            TrueObject(UIExample);
        }

        ElementsTrue = !ElementsTrue;
    }

    private void TrueObject(GameObject[] conjunto)
    {
        foreach (GameObject elemento in conjunto)
        {
            elemento.SetActive(true);
        }
    }

    private void FalseObject(GameObject[] conjunto)
    {
        foreach (GameObject elemento in conjunto)
        {
            elemento.SetActive(false);
        }
    }
}
