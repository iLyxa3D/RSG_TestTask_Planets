using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneteryObject
{
    public MassClass massClass { get; set; }
    public double mass { get; set; }
    
    public float radius { get; set; }    
    public void Rotate(float rotationAmount);
}