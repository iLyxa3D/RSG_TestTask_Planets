using UnityEngine;

[CreateAssetMenu(fileName = "New Planet Type", menuName = "ScriptableObjects/Add planet type", order = 1)]
public class MassClass: ScriptableObject
{
    public string planetTypeName;
    public float planetMassFrom;
    public float planetMassTo;
    public float planetRadiusFrom;
    public float planetRadiusTo;
}