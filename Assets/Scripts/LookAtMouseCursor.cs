using UnityEngine;
using System.Collections;

public class LookAtMouseCursor : MonoBehaviour {
    private Vector2 mousePos;
    private Vector2 direction;
    private float angle;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2((mousePos.x - transform.position.x), (mousePos.y - transform.position.y));
        direction.Normalize();

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
