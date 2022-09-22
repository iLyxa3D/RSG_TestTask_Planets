using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlaneterySystemFactory : MonoBehaviour, IPlaneterySystemFactory
{

    private PlaneterySystem system;

    public IPlaneterySystem Create(double mass)
    {
        if (system != null)
            Destroy(system.gameObject);

        GameObject systemGameObject = new GameObject("Planetary System");
        PlaneterySystem systemComponent = systemGameObject.AddComponent<PlaneterySystem>();

        systemGameObject.transform.position = Vector3.zero;
        systemGameObject.transform.rotation = Quaternion.identity;

        double massLeft = mass;
        int smallestObjectCounter = 0;

        do
        {
            //Debug.Log(massLeft); 

            List<MassClass> lowerTotalMassTypes = new List<MassClass>();
            foreach (MassClass massClass in Config.massClasses)
                if (massClass.planetMassTo <= massLeft)
                    lowerTotalMassTypes.Add(massClass);

            if (lowerTotalMassTypes.Count > 0)
            {
                GameObject planetGameObject = Instantiate(View.instance.planetPrefab, systemGameObject.transform);
                planetGameObject.name = "Planet " + systemComponent.planeteryObjects.Count.ToString();
                planetGameObject.transform.localPosition = Vector3.zero;
                planetGameObject.transform.localRotation = Quaternion.identity;

                PlaneteryObject planeteryComponent = planetGameObject.GetComponent<PlaneteryObject>();
                systemComponent.planeteryObjects.Add(planeteryComponent);

                planeteryComponent.massClass = lowerTotalMassTypes[Random.Range(0, lowerTotalMassTypes.Count)];
                planeteryComponent.mass = Random.Range(
                    planeteryComponent.massClass.planetMassFrom, planeteryComponent.massClass.planetMassTo
                    );                
                
                float radius =
                    systemComponent.planeteryObjects.Sum(po => po.radius) +
                    planeteryComponent.massClass.planetRadiusTo * Config.planetStepFactor +
                    Config.sunSize;

                float scale = Random.Range(
                    planeteryComponent.massClass.planetRadiusFrom, planeteryComponent.massClass.planetRadiusTo
                    ) * Config.planetStepFactor;

                planeteryComponent.Init(radius, scale);

                if (planeteryComponent.massClass == Config.smallestObject)
                    smallestObjectCounter++;

                massLeft -= planeteryComponent.mass;
            }
            else
            {
                Debug.Log("No planets in the list for this mass: " + massLeft);
                massLeft = 0;
            }


        }
        while (massLeft > 0 && smallestObjectCounter < Config.smallestObjectsLimit);

        system = systemComponent;        

        return systemComponent;
    }

    private void Update()
    {
        if (system != null)
            system.UpdateRotation(Time.deltaTime);
    }

}
