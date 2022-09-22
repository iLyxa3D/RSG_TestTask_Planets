using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlanet : MonoBehaviour
{
    public Transform planetBody;
    public Transform trajectory;

    public void Init(float radius, float scale)
    {
        planetBody.localPosition = Vector3.right * radius;
        planetBody.localScale= Vector3.one * scale;
        trajectory.localScale = Vector3.one * radius;

        Color color = Random.ColorHSV();
        planetBody.GetComponent<Renderer>().material.color = color;
        trajectory.GetComponent<Renderer>().material.color = color; 


    }
}
