using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu( fileName = "MechanicData", menuName = "ScriptableObjects/MechanicData", order = 1 )]
public class MechanicScriptable : ScriptableObject
{
    // TODO : Add an interface related to the action done on mechanic use?

    [SerializeField]
    private string mechanicName;

    [SerializeField]
    [TextArea]
    private string description;

    [SerializeField]
    private string kind;

    public string MechanicName { get => mechanicName; }
    public string Description { get => description;  }
    public string Kind { get => kind; }
}
