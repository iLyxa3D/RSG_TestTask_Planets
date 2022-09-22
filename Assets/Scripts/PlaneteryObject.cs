using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneteryObject : MonoBehaviour, IPlaneteryObject
{
    private MassClass _massClass;
    private double _mass;
    public Vector3 _rotationDirection;
    private float _radius;

    public MassClass massClass { 
        get { return _massClass; } set { _massClass = value; }
    }
    public double mass {
        get { return _mass; } set { _mass = value; }         
    }


    public float radius { 
        get { return _radius; } set { _radius = value; }
    }


    public Transform planetBody;
    public Transform trajectory;

    public void Init(float radius, float scale)
    {
        _radius = radius;
        _rotationDirection = Random.insideUnitSphere;

        planetBody.localPosition = Vector3.right * radius;
        planetBody.localScale = Vector3.one * scale;
        trajectory.localScale = Vector3.one * radius * 2f;

        Color color = Random.ColorHSV();
        planetBody.GetComponent<Renderer>().material.color = color;
        trajectory.GetComponent<Renderer>().material.color = color;

        transform.localRotation = Quaternion.Euler(_rotationDirection * 360f); 
    }

    public void Rotate(float amount)
    {
        transform.localRotation *= Quaternion.Euler(Vector3.forward * amount);
    }


    
}
