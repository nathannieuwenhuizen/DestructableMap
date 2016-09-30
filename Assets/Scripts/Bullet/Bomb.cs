using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
/// <summary>
/// This class handles the bomb collision and interaction with the world. 
/// </summary>
public class Bomb : MonoBehaviour, ITagCollider {

    [SerializeField]
    private GameObject explosion;

    public void OnCollision(CircleCollider2D cc)
    {
        Explode();
    }
    void Explode()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
