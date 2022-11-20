using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject SettingsScreen;
    public GameObject CreditsScreen;
    public AudioSource audio;

    IEnumerator ChangeState(int type)
    {
        if(type == 0)
        {
            Animator anim = CreditsScreen.GetComponent<Animator>();
            anim.Play("MoveBack");
            yield return new WaitForSecondsRealtime(0.25f);
            CreditsScreen.SetActive(false);
        }
        else
        {
            Animator anim = SettingsScreen.GetComponent<Animator>();
            anim.Play("MoveBack");
            yield return new WaitForSecondsRealtime(0.25f);
            SettingsScreen.SetActive(false);
        }
    }


    IEnumerator PlayIEnum()
    {
        transform.Find("BlackScreen").GetComponent<Animator>().Play("ScreenFade");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Intro");
    }

    public void Play()
    {
        StartCoroutine(PlayIEnum());
    }

    public void Quit()
    {
        transform.Find("BlackScreen").GetComponent<Animator>().Play("ScreenFade");
        Application.Quit();
    }

    public void Settings()
    {
        SettingsScreen.SetActive(true);
        Animator anim = SettingsScreen.GetComponent<Animator>();
        anim.Play("Move");
    }

    public void Credits()
    {
        CreditsScreen.SetActive(true);
        Animator anim = CreditsScreen.GetComponent<Animator>();
        anim.Play("Move");
    }

    public void CloseMenu(int type)
    {
        StartCoroutine(ChangeState(type));
    }

    public void playSound()
    {
        audio.Play();
    }
}
