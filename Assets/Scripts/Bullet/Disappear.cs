using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Disappear : MonoBehaviour {

    [SerializeField]
    private float scaleSpeed = 0.01f;
    
    private Vector3 scale;
    void Start()
    {
        scale = transform.localScale;
        StartCoroutine(Shrinking());
    }
    void Update()
    {
        transform.localScale = scale;
    }

    IEnumerator Shrinking()
    {
        while (scale.x > 0)
        {
            scale.x -= scaleSpeed;
            scale.y -= scaleSpeed;
            scale.z -= scaleSpeed;
            yield return new WaitForFixedUpdate();
        }
        
    }
}
