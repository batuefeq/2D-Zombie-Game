using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialUI : MonoBehaviour
{
    private Text tutorialText;
    private int line = 0;
    private bool isShot, isStab, isJump;
    private bool processing = false;
    private List<string> str = new List<string>();
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
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
        }
        if (Input.GetMouseButtonDown(1) && !isStab)
        {
            isStab = true;
        }
    }


    private IEnumerator TextTimerFirst()
    {
        tutorialText.text = str[0];
        FadeIn();
        processing = true;
        // yield break
        yield return new WaitForSecondsRealtime(25f);
        if (isShot)
        {
            FadeOut();
        }        
    } 



    void Update()
    {
        TextChanger();
        TextTimerFirst();
    }
}
