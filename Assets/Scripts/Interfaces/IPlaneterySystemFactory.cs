using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneterySystemFactory
{    
    public IPlaneterySystem Create(double mass);

}