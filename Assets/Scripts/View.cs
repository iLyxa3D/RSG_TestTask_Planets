using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class View : MonoBehaviour
{
    public static View instance;

    public TMP_InputField totalMassValue;
    public GameObject planetPrefab;

    private void OnEnable()
    {
        SetDefaultValues();
    }

    private void Awake()
    {
        instance = this;
    }

    public void SetDefaultValues()
    {
        totalMassValue.text = Config.defaultTotalMassValue.ToString();
    }

    
}
