using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialUI : MonoBehaviour
{
    private Text tutorialText;
    private bool isShot, isStab, isJump, isFading, isJumpStab;
    private bool processing = false;
    private readonly List<string> str = new();
    Color col;


    private void Start()
    {
        tutorialText = GetComponent<Text>();
        col = tutorialText.color;
        str.Add("Use Left Mouse Button to Shoot");
        str.Add("Use Spacebar to jump");
        str.Add("Use Right Mouse Button to stab");
        str.Add("Use Jump Stab to reset stab timer");
    }


    private void FadeOut()
    {
        if (col.a > 0)
        {
            col.a -= Time.deltaTime;
            tutorialText.color = col;
            isFading = true;
        }
        else isFading = false;
    }


    private void FadeIn()
    {
        if (col.a < 256)
        {
            col.a += Time.deltaTime;
            tutorialText.color = col;
            isFading = true;
        }
        else isFading = false;
    }


    private void TextChanger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShot = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            isStab = true;
        }
        if(Input.GetMouseButtonDown(1) && Input.GetKeyDown(KeyCode.Space)) isJumpStab = true;


        if (!processing)
        {
            if (!isShot) StartCoroutine(TextShowTime());
            else if (!isJump) StartCoroutine(TextShowTime());
            else if (!isStab) StartCoroutine(TextShowTime());
            else if (!isJumpStab) StartCoroutine(TextShowTime());                                  
        }       
        if (isShot)
        {
            StartCoroutine(TextTimerFirst());
        }
    }


    private IEnumerator TextTimerFirst()
    {
        if (tutorialText.text == str[0] && isShot) FadeOut();
        else if (tutorialText.text == str[1] && isJump) FadeOut();
        else if (tutorialText.text == str[2] && isStab) FadeOut();
        else if (tutorialText.text == str[3] && isJumpStab) FadeOut();
        else yield break;

        yield return new WaitForSecondsRealtime(2f);

        processing = false;
    } 

    private IEnumerator TextShowTime()
    {
        if (!isFading)
        {
            if (!isShot) tutorialText.text = str[0];
            else if (!isJump) tutorialText.text = str[1];
            else if (!isStab) tutorialText.text = str[2];                                      
            else if (!isJumpStab) tutorialText.text = str[3];
        }
        FadeIn();
        yield return new WaitForSecondsRealtime(2f);
        processing = true;
    }


    void Update()
    {
        TextChanger();
    }
}
