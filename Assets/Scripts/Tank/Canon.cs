using UnityEngine;
using System.Collections;
/// <summary>
/// Canon is used to fire a projectile with a momentum that is determined 
/// by the force variable that would be charged when the input button is pressed.
/// </summary>
public class Canon : MonoBehaviour {
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float maxForce;
    private float force;
    [SerializeField]
    private GameObject chargeBar;

	void Update () {
        //when the button is pressed.
        if (Input.GetButtonDown("Fire1"))
            StartCoroutine(Charging());

        //updates the chargebar with the force variable.
        chargeBar.transform.localScale = new Vector2(force/maxForce, 1);
	}

    //when charging
    IEnumerator Charging()
    {
        //if the button is pressed and the force doesn't exceed the maxforce.
        while(Input.GetButton("Fire1") && force < maxForce)
        {
            //the force builds up.
            force += 10;
            yield return new WaitForFixedUpdate();
        }
        //when released, it shoots.
        Shoot();
        //resets the force.
        force = 0;
    }
    void Shoot()
    {
        //calculates the direction the projectile is given force to.
        Vector2 parentPos = this.transform.parent.position;
        Vector2 direction = new Vector2(transform.position.x - parentPos.x, transform.position.y - parentPos.y);

        //instantiates the projectile
        GameObject spawnedProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        //gives it a direction.
        spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
}
