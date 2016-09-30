using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed = 0.01f;
    
    private Vector3 scale;
    private Color temp;
    
    void Start()
    {
        scale = transform.localScale;
        StartCoroutine(FadeOver());
    }
    void Update()
    {
        transform.localScale = scale;
    }

    IEnumerator FadeOver()
    {
        while (scale.x > 0)
        {
            scale.x -= fadeSpeed;
            scale.y -= fadeSpeed;
            scale.z -= fadeSpeed;
            yield return new WaitForFixedUpdate();
        }
        
    }
}
