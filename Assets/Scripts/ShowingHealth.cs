using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ShowingHealth : MonoBehaviour, ITagCollider {

    [SerializeField]
    private int health = 100;

    public void OnCollision(CircleCollider2D cc)
    {
        health -= 10;
        Debug.Log("health = "+health);
    }
}
