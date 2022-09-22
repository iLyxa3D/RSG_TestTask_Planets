using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainController : MonoBehaviour
{

    PlaneterySystemFactory planeterySystemFactory;

    private void Awake()
    {
        Config.massClasses = Resources.LoadAll<MassClass>("PlanetsSetup");
        
        if (Config.massClasses.Length == 0)
            Debug.Log("Can't find planets setup");
        else
        {
            Config.smallestObject = Config.massClasses[0];
            foreach (MassClass m in Config.massClasses)
            {
                Debug.LogFormat("Found {0}", m.name);
                if (m.planetMassTo < Config.smallestObject.planetMassTo)
                    Config.smallestObject = m;
            }
        }
    }

    void Start()
    {
        planeterySystemFactory = gameObject.AddComponent<PlaneterySystemFactory>();
    }

    public void CreateSystemClick()
    {        
        double totalMass = Config.defaultTotalMassValue;
        double.TryParse(View.instance.totalMassValue.text, out totalMass);
        if (totalMass < 0)
        {
            totalMass = 0;
            Debug.Log("Wrong mass value:" + View.instance.totalMassValue.text);
        }

        IPlaneterySystem system = planeterySystemFactory.Create(totalMass);
        Debug.Log("Total planets: " + system.planeteryObjects.Count);
    }

   

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
            Camera.main.transform.position += Vector3.forward * 10f;
        else
            if (Input.GetKeyUp(KeyCode.DownArrow))
            Camera.main.transform.position -= Vector3.forward * 10f;

    }

}
