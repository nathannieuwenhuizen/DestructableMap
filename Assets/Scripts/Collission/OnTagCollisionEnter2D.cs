using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class OnTagCollisionEnter2D : MonoBehaviour
{
    [SerializeField]
    private string gameObjectTag;
    [SerializeField]
    private CircleCollider2D circleCollider;
    [SerializeField]
    private GameObject explosion;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == gameObjectTag)
        {
            ExecuteEvents.Execute<ITagCollider>(coll.gameObject, null,(x,y)=>x.OnCollision(circleCollider));
            Destroy(gameObject);
            Instantiate(explosion, transform.position,Quaternion.identity);
        }
    }
}
