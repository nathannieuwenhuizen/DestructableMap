using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
/// <summary>
/// This script is used for every object that collides with an object.
/// </summary>
public class OnTagCollisionEnter2D : MonoBehaviour
{
    [SerializeField]
    private string gameObjectTag;
    [SerializeField]
    private CircleCollider2D circleCollider;

    //When it collides with an object.
    void OnCollisionEnter2D(Collision2D coll)
    {
        //executes the interface functions "OnCollision" for itself and the other.
        ExecuteEvents.Execute<ITagCollider>(coll.gameObject, null,(x,y)=>x.OnCollision(circleCollider));
        ExecuteEvents.Execute<ITagCollider>(this.gameObject, null, (x, y) => x.OnCollision(circleCollider));
    }
}
