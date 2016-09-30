using UnityEngine;
using System.Collections;
/// <summary>
/// This class is used to get a 2d object looking at the mouse position.
/// </summary>
public class LookAtMouseCursor : MonoBehaviour {
    private Vector2 mousePosition;
    private Vector2 direction;
    private float angle;


    void Update()
    {
        //declares the mouseposition into a world point.
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //direction is calculated between the object and the mouse positon and then normalized.
        direction = new Vector2((mousePosition.x - transform.position.x), (mousePosition.y - transform.position.y));
        direction.Normalize();

        //Declares the angle on a x and y based coordinates.
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //updates the rotation based on the rotation and sets it forward.
        //in that way the object only rotates in the z- axis.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
