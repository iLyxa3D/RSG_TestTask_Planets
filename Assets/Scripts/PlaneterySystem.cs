using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneterySystem : MonoBehaviour, IPlaneterySystem
{
    private List<IPlaneteryObject> _planeteryObjects = new List<IPlaneteryObject>();
    public List<IPlaneteryObject> planeteryObjects {
        get { return _planeteryObjects; }
        set { _planeteryObjects = value; } 
    }

    public void UpdateRotation(float deltaTime)
    {
        float rotationAmount = deltaTime * Config.rotationSpeedBoost;
        foreach (IPlaneteryObject po in _planeteryObjects)
            po.Rotate(rotationAmount);
                
    }
    
}
