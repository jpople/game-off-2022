using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Component that dynamically instantiates the UI List of Mechanics from a given mechanics list
 */
public class MechanicListUI : MonoBehaviour
{

    [SerializeField]
    private MechanicCollection mechanicList;

    [SerializeField]
    private MechanicItemUI mechanicItemPrefab;

    [SerializeField]
    private bool destroyChildrenOnStart = true;

    void Start()
    {
        if ( destroyChildrenOnStart )
        {
            DestroyAllChildren();
        }

        InstantiateMechanicsUIList();
    }

    private void InstantiateMechanicsUIList()
    {
        IEnumerator<MechanicScriptable> mechanicsEnumerator = mechanicList.GetEnumerator();

        // While there's a next element in the list
        while ( mechanicsEnumerator.MoveNext() )
        {
            MechanicItemUI newMechanicItem = Instantiate<MechanicItemUI>( mechanicItemPrefab, transform );
            newMechanicItem.SetMechanicUI( mechanicsEnumerator.Current );
        }

    }

    private void DestroyAllChildren()
    {
        foreach ( Transform child in this.transform )
        {
            Destroy( child.gameObject );
        }
    }
}
