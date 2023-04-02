using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator anim;
    Rigidbody2D rb;
    Player player;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
        Player.onJump += JumpingAnimation;
    }


    private void OnDisable()
    {
        Player.onJump -= JumpingAnimation;
    }


    private void JumpingAnimation()
    {
        anim.SetBool("isJumping", true);
    }


    private void AnimationControl()
    {   
        if (rb.velocity.y < 0 && rb.velocity.y > -2f)
        {
            anim.SetBool("isAirborne", true);
            anim.SetBool("isJumping", false);
        }  
        else
        {
            anim.SetBool("isAirborne", false);
        }

        if (rb.velocity.y <= -2.1f)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }

        if (player.isGrounded)
        {
            anim.SetBool("isFalling", false);
            anim.SetBool("isGrounded", true);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || !player.isGrounded)
        {
            anim.SetBool("isGrounded", false);
        }

        if (player.stabCollider.isActiveAndEnabled)
        {
            anim.SetBool("isStabbing", true);
        }
        else
        {
            anim.SetBool("isStabbing", false);
        }
    }


    void Update()
    {
        AnimationControl();
    }
}