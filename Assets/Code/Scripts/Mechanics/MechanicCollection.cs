using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "MechanicCollection.asset",
    menuName = "ScriptableObjects/MechanicCollection",
    order = 2 )]
public class MechanicCollection : Collection<MechanicScriptable>
{
}