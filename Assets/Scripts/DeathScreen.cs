using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] UiController uiController;
    [SerializeField] TMP_Text score;
    bool active = false;

    public void Remove()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.baseHealth <= 0 && active == false)
        {
            active = true;
            score.text = uiController.roundTime.ToString();
            transform.Find("BlackBox").gameObject.SetActive(true);

            Animator anim = transform.Find("BlackBox").GetComponent<Animator>();
            anim.Play("ScreenFade");
            
        }
    }


}
