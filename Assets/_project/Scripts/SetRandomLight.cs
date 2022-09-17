using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomLight : MonoBehaviour
{
    private void Start()
    {
        Color color = Random.ColorHSV(0, 1, 0.7f, 1, 0.7f, 1f);
        foreach(Transform child in transform)
        {
            Light light = child.GetComponent<Light>();
            if (light)
            {
                light.color = color;
            }
        }
    }
}
