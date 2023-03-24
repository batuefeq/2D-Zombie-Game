using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    private Text tutorialText;
    private float timer;
    private bool shootBool = false;
    private bool stabBool = false;
    private bool jumpBool = false;
    Color col;


    private void Start()
    {
        tutorialText = GetComponent<Text>();
        col = tutorialText.color;
    }


    private void FadeOut()
    {
        if (col.a > 0)
        {
            col.a -= Time.deltaTime;
            tutorialText.color = col;
        }

        print("fade out");
    }


    private void FadeIn()
    {
        if(col.a < 256)
        {
            col.a += Time.deltaTime;
            tutorialText.color = col;
        }
    }



    private void ShootTutorial()
    {       
        tutorialText.text = "Use Left Mouse Button to shoot";
        
    }


    private void JumpTutorial()
    {
        tutorialText.text = "Use Spacebar to jump";      
    }

    
    private void StabTutorial()
    {
        tutorialText.text = "Use Right Mouse Button to Stab.";
        stabBool = true;
    }

    private void TextChanger()
    {
        timer += Time.deltaTime;
        bool inProgress = false;
        if (!Input.GetMouseButtonDown(0) && timer > 5f && !shootBool)
        {
            FadeIn();
            ShootTutorial();
            inProgress = true;
        }
        if (Input.GetMouseButtonDown(0) && !shootBool && inProgress)
        {
            FadeOut();
            timer = 0f;
            shootBool = true;
            inProgress = false;
        }

        if (!Input.GetKeyDown(KeyCode.Space) && timer > 4f && shootBool && !jumpBool)
        {
            FadeIn();
            JumpTutorial();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeOut();
                timer = 0f;
                jumpBool = true;
            }
        }

        if (!Input.GetMouseButtonDown(1) && timer > 3f && jumpBool)
        {
            FadeIn();
            StabTutorial();
            if (Input.GetMouseButtonDown(1))
            {
                FadeOut();
                timer = 0f;
            }
        }
    }


    void Update()
    {
        TextChanger();
    }
}
