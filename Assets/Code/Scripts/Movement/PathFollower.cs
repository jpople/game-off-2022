using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Make the GameObject move toward the given path of gameobjects, going to their transform in order one-by-one.
 */
public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private GameObjectCollection path;

    [SerializeField]
    private bool teleportToFirstNode = false;

    [SerializeField]
    [Range(0, 10)]
    private float speed = 1.0f;

    [SerializeField]
    [Range(0, 5)]
    private int pauseBetweenNodes = 0; // seconds

    // TODO : Able to pause the movement depending on a player state? (Ex: Combat)
    // TODO : Able to change path runtime?
    // TODO : Add some logging on node/path reached?
    // TODO : Delay start based on condition/time?
    // TODO : Able to loop path?

    void Start()
    {
        StartCoroutine( FollowPath() );
    }

    private IEnumerator FollowPath()
    {
        IEnumerator<GameObject> pathEnumerator = path.GetEnumerator();

        bool isFirstNode = true;

        while ( pathEnumerator.MoveNext() )
        {
            if ( isFirstNode )
            {
                isFirstNode = false;

                // Skip moving and start the character's movement from the first node
                if ( teleportToFirstNode )
                {
                    transform.position = pathEnumerator.Current.transform.position;
                    continue;
                }
            }

            // Move to next node
            yield return StartCoroutine( MoveToNode( pathEnumerator.Current.transform ) ); // Pause execution until MoveToNode is finished

            // Pause between nodes
            if ( pauseBetweenNodes > 0f )
            {
                yield return new WaitForSeconds( pauseBetweenNodes );
            }
        }

    }

    private IEnumerator MoveToNode( Transform node )
    {
        while ( Vector2.Distance( transform.position, node.position ) > 0.05f )
        {
            // TODO : Add some easing or acceleration curve for smoother movements?

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards( transform.position, node.position, step );

            yield return null; // Wait until next frame
        }
    }
}
