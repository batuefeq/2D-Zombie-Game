using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAnimationScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource auSource;
    private Animator anim;
    private static float animSpeed = 0.3f;
    private float minAnimSpeed = 0.3f;
    private float maxAnimSpeed = 2.5f;
    private readonly float animSpeedRate = 0.0007f;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        auSource = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void AnimatorSpeedAdjuster()
    {
        if (animSpeed < maxAnimSpeed)
        {
            animSpeed += animSpeedRate;
        }
        else if (animSpeed >= maxAnimSpeed)
        {
            animSpeed = maxAnimSpeed;
        }
        anim.speed = animSpeed;
    }


    private void Step()
    {
        auSource.PlayOneShot(clips[Random.Range(0, 6)]);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        animSpeed = minAnimSpeed;
    }


    private void Update()
    {
        AnimatorSpeedAdjuster();
    }
}
