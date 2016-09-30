using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Target.cs goes to the target object the tank must hit.
/// </summary>
public class Target : MonoBehaviour, ITagCollider {
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private GameObject countText;

    //interface function of ITagCollider.cs 
    public void OnCollision(CircleCollider2D cc)
    {
        //if the target is hit, it begins with the winning coroutine.
        StartCoroutine(Winning());
    }
    IEnumerator Winning()
    {
        //Makes the counting stop.
        Destroy(countText.GetComponent<CountDownTimer>());

        //updates the text.
        countText.GetComponent<Text>().text = "Victory!";
        Debug.Log("victory!");

        //slowmotion for effect.
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1f);
        
        //loads next scene.
        sceneLoader.LoadNextScene();
    }

}
