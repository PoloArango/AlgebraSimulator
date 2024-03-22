using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObjectWithSliders : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    void Update()
    {

      // Update the position of the object based on the slider values
        float newX = sliderX.value;
        float newY = sliderY.value;
        float newZ = sliderZ.value;

        transform.position = new Vector3(newX, newY, newZ);

    }
}
