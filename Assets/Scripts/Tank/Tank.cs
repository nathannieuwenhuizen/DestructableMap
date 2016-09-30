using UnityEngine;
using System.Collections;
/// <summary>
/// TankMovement handles the movement of the tank and the inputs.
/// </summary>
public class Tank : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D rigidBody2D;
    [SerializeField]
    private float aceleration;
    private float directionX;

    void Update()
    {
        //directionx is declared by the input times aceleration.
        directionX = Input.GetAxis("Horizontal")*aceleration;

        //force is added to the rigidbody.
        rigidBody2D.AddForce(Vector2.right *directionX);
    }
}

