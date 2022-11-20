using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] KeyCode key;
    [SerializeField] Animator anim;
    [SerializeField] Animator Settinganim;
    [SerializeField] GameObject settingmenu;
    public GameObject menu;
    public bool isOpened = false;
    bool debounce = false;
    bool settingsOpened = false;


    // Enumerators
    IEnumerator CloseMenu()
    {
        debounce = true;
        Time.timeScale = 1.0f;
        isOpened = false;
        anim.Play("Close");
        yield return new WaitForSecondsRealtime(0.42f);
        menu.SetActive(false);
        debounce = false;
    }

    IEnumerator OpenMenu()
    {
        debounce = true;
        Time.timeScale = 0;
        isOpened = true;
        menu.SetActive(true);
        anim.Play("Open");
        yield return new WaitForSecondsRealtime(0.42f);
        debounce = false;
    }
    IEnumerator CloseSettings()
    {
        debounce = true;
        Settinganim.Play("SizeOut");
        yield return new WaitForSecondsRealtime(0.35f);
        settingmenu.SetActive(false);
        settingsOpened = false;
        debounce = false;

    }
    IEnumerator OpenSettings()
    {
        debounce = true;
        settingsOpened = true;
        settingmenu.SetActive(true);
        Settinganim.Play("SizeIn");
        yield return new WaitForSecondsRealtime(0.35f);
        debounce = false;
    }

    // Wrappers
    public void ClosePauseWrapper() // Wrapper for the UI button
    {
        if (!debounce) StartCoroutine(CloseMenu());
    }

    public void OpenPauseWrapper()
    {
        if (!debounce && !isOpened)
        {
            StartCoroutine(OpenMenu());
        }
        else if (!debounce) StartCoroutine(CloseMenu());
    }

    public void CloseSettingsWrapper()
    {
        if (!debounce) StartCoroutine(CloseSettings());
    }

    // Functions
    public void OpenSettingsWrapper()
    {
        if (!debounce) StartCoroutine(OpenSettings());
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (settingsOpened && !debounce) StartCoroutine(CloseSettings());
            else if (!isOpened && !debounce)
            {
                StartCoroutine(OpenMenu());
            }
            else if (!debounce)
            {
                StartCoroutine(CloseMenu());
            }
        }
    }
}