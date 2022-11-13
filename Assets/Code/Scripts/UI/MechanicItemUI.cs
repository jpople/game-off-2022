using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Component that controls the display of clickable Mechanics items in the UI list.
 * */
public class MechanicItemUI : MonoBehaviour
{
    // TODO : Add description field that expands on selection
    // TODO : Actually "Select" the scriptable on toggle.

    [SerializeField]
    private Text mechanicNameText;

    //[SerializeField]
    //private Text mechanicDesc;

    [SerializeField]
    private MechanicScriptable mechanicScriptable;

    private void Start()
    {
        // For testing, should be created and set dynamically by MechanicListUI
        if ( mechanicScriptable != null )
        {
            SetMechanicUI( mechanicScriptable );
        }
    }

    public void SetMechanicUI( MechanicScriptable scriptable )
    {
        this.mechanicScriptable = scriptable;
        this.name = scriptable.MechanicName;

        mechanicNameText.text = scriptable.MechanicName;
        //mechanicDesc.text = scriptable.Description;
    }

}
