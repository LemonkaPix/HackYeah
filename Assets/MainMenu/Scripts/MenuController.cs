using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MenuController : MonoBehaviour
{

    public GameObject SettingsScreen;
    public GameObject CreditsScreen;

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

    public void Play()
    {
    }

    public void Quit()
    {
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

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
