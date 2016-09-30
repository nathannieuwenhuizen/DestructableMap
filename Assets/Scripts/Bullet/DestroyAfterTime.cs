using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
    [SerializeField]
    private float lifeTime = 5f;
	void Start () {
        StartCoroutine(Destroying());
	}
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
