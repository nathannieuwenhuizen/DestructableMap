using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// The countdowntimer shows ohw many time the timercount is left. 
/// If it reaches zero it calls the sceneloader to restart the scene.
/// </summary>
public class CountDownTimer : MonoBehaviour
{
    [SerializeField]
    private Text countDownText;
    [SerializeField]
    private float timerCount;
    [SerializeField]
    private SceneLoader sceneLoader;

    //starting to count.
    void Start()
    {
        StartCoroutine(Counting());
    }

    IEnumerator Counting ()
    {
        //if the count is above zero, it does the countdown-function.
        while (timerCount >0 )
        {
            Countdown();
            yield return new WaitForFixedUpdate();
        }
        //Shows time is up and restarts the scene.
        countDownText.text = " Time is up!";
        yield return new WaitForSeconds(1);
        sceneLoader.RestartScene();
    }

    //substracts the timercount with the time and updates the text.
    private void Countdown()
    {
        timerCount -= Time.deltaTime;
        var seconds = timerCount % 60;
        countDownText.text = string.Format(" {0:00}", seconds); 
    }
}