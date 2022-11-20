using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(38f);
        SceneManager.LoadScene("Dialogue");
    }


    void Start()
    {
        StartCoroutine(nextScene());
    }
}