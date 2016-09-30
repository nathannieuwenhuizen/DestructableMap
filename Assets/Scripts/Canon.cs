using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
    [SerializeField]
    private GameObject bomb;
    private Vector2 mousePos;
    [SerializeField]
    private float maxForce;
    private float force;
    [SerializeField]
    private GameObject chargeBar;
	void Update () {

        if (Input.GetButtonDown("Fire1"))
            StartCoroutine(Charging());

        chargeBar.transform.localScale = new Vector2(force/maxForce, 1);
	}
    IEnumerator Charging()
    {
        
        while(Input.GetButton("Fire1") && force < maxForce)
        {
            force += 10;
            yield return new WaitForFixedUpdate();
        }
        Shoot();
        force = 0;
    }
    void Shoot()
    {
        Vector2 parentPos = this.transform.parent.position;
        Vector2 direction = new Vector2(transform.position.x - parentPos.x, transform.position.y - parentPos.y);

        GameObject spawnedBomb = Instantiate(bomb, transform.position, Quaternion.identity) as GameObject;

        spawnedBomb.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
}
