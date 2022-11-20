using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBehaviour : MonoBehaviour
{
    public NPCConversation conv;


    public void playAnim()
    {
        Transform background = conv.transform.Find("Background");
        Animator anim = background.GetComponent<Animator>();

        anim.Play("BackgroundFade");
    }

   IEnumerator Switch()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("GameScene");
    }

    public void switchScene()
    {
        Transform background = conv.transform.Find("Background");
        Animator anim = background.GetComponent<Animator>();

        anim.Play("BackgroundFadeBack");
        StartCoroutine(Switch());
    }

    void Start()
    {
        ConversationManager.Instance.StartConversation(conv);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
