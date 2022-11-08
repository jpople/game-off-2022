using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRegister : MonoBehaviour
{
    /*
     * Automatically reads all its children and register them in a list in a gameobject, so they can be used as a path later.
     * Register them through a scriptableObject allows to not have the script differently references each other (player <--> pathRegister) to find
     * the value, and avoid manually linking stuff in the inspector in the scene.
     */
    [SerializeField]
    private GameObjectCollection path;

    private void OnEnable()
    {
        path.Clear();

        foreach ( Transform child in this.transform )
        {
            path.Add( child.gameObject );
        }
    }

    private void OnDisable()
    {
        path.Clear();
    }

    // TODO : Add Editor-only define for Gizmos?

    // Function that draw debugs elements in the scene
    private void OnDrawGizmos()
    {

        List<GameObject> nodes;

        // Get all children gameobjects

        if ( path == null || path.Count == 0 )
        {
            // If the scriptable isn't init, manually read all children
            nodes = new List<GameObject>();
            foreach ( Transform child in this.transform )
            {
                nodes.Add( child.gameObject );
            }
        }
        else
        {
            if ( path == null )
                return;

            nodes = (List<GameObject>) path.List;
        }

        if ( nodes == null || nodes.Count == 0 )
            return;

        //Draw a point on each gameobject, and a lines linking them in a path
        GameObject previousNode = null;
        Gizmos.color = Color.green;
        foreach ( GameObject node in nodes )
        {
            Gizmos.DrawWireSphere( node.transform.position, 0.2f );

            if ( previousNode != null )
            {
                Gizmos.DrawLine( previousNode.transform.position, node.transform.position );
            }

            previousNode = node;
        }
    }
}
