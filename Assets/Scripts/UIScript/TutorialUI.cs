using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialUI : MonoBehaviour
{
    private Text tutorialText;
    private bool isShot, isStab, isJump;
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
    }


    private void FadeOut()
    {
        if (col.a > 0)
        {
            col.a -= Time.deltaTime;
            tutorialText.color = col;
        }
    }


    private void FadeIn()
    {
        if(col.a < 256)
        {
            col.a += Time.deltaTime;
            tutorialText.color = col;
        }
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


        if (!processing)
        {
            if (!isShot)
            {
                StartCoroutine(TextShowTime());
            }
            else if (!isJump)
            {
                StartCoroutine(TextShowTime());
            }
            else if (!isStab)
            {
                StartCoroutine(TextShowTime());
            }
        }       
        if (isShot)
        {
            StartCoroutine(TextTimerFirst());
        }
    }


    private IEnumerator TextTimerFirst()
    {
        if (tutorialText.text == str[0] && isShot)
        {
            FadeOut();
        }
        else if (tutorialText.text == str[1] && isJump)
        {
            FadeOut();
        }
        else if (tutorialText.text == str[2] && isStab)
        {
            FadeOut();
        }
        else
        {
            yield break;
        }
        yield return new WaitForSecondsRealtime(2f);
        processing = false;
    } 

    private IEnumerator TextShowTime()
    {     
        FadeIn();
        print("upper side");
        yield return new WaitForSecondsRealtime(2f);
        processing = true;
        print("lower side");
    }


    void Update()
    {
        TextChanger();
    }
}
