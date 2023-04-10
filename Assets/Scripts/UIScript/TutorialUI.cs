using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialUI : MonoBehaviour
{
    private Text tutorialText;
    private bool isShot, isStab, isJump, isFading, isReload;
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
        str.Add("Use R to reload");
    }


    private void Awake()
    {
        SaveLoader();
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



    private void TutorialSaver()
    {
        if (isShot) PlayerPrefs.SetInt("isShot", 1);
        if (isStab) PlayerPrefs.SetInt("isStab", 1);
        if (isJump) PlayerPrefs.SetInt("isJump", 1);
        if (isReload) PlayerPrefs.SetInt("isReload", 1);
        PlayerPrefs.Save();
    }


    private void SaveLoader()
    {
        if (PlayerPrefs.GetInt("isShot") == 1) isShot = true;
        if (PlayerPrefs.GetInt("isStab") == 1) isStab = true;
        if (PlayerPrefs.GetInt("isJump") == 1) isJump = true;
        if (PlayerPrefs.GetInt("isReload") == 1) isReload = true;
       
    }


    private void TextChanger()
    {
        if (Input.GetMouseButtonDown(0)) isShot = true;
        if (Input.GetKeyDown(KeyCode.Space)) isJump = true;
        if (Input.GetMouseButtonDown(1)) isStab = true;
        if (Input.GetKeyDown(KeyCode.R)) isReload = true;

        if (!processing)
        {
            if (!isShot) StartCoroutine(TextShowTime());
            else if (!isJump) StartCoroutine(TextShowTime());
            else if (!isStab) StartCoroutine(TextShowTime());
            else if (!isReload) StartCoroutine(TextShowTime());                                  
        }       
        if (isShot)
        {
            StartCoroutine(TextTimerFirst());
        }
        TutorialSaver();
    }


    private IEnumerator TextTimerFirst()
    {
        if (tutorialText.text == str[0] && isShot) FadeOut();
        else if (tutorialText.text == str[1] && isJump) FadeOut();
        else if (tutorialText.text == str[2] && isStab) FadeOut();
        else if (tutorialText.text == str[3] && isReload) FadeOut();
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
            else if (!isReload) tutorialText.text = str[3];
        }
        FadeIn();
        yield return new WaitForSecondsRealtime(2f);
        processing = true;
    }


    private void Update()
    {
        TextChanger();
    }
}
