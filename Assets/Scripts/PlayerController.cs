using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRb;
    Animator PlayerAnimator;

    [SerializeField]
    public float jumpSpeed , jumpFrequency = 1f, nextJumpTime,moveSpeed ,fallSpeed;

    [SerializeField]
    Transform groundCheckPosition;

    [SerializeField]
    float groundCheckRadius;

    [SerializeField]
    LayerMask groundCheckLayer;

    bool facingRight = true;
    bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();
        if (PlayerRb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (PlayerRb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
        
                

    }

    void HorizontalMove()
    {
        PlayerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, PlayerRb.velocity.y); //yürüme. sað -> axis > 0 
        PlayerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerRb.velocity.x)); //playerspeed degerine anlýk hýzýnýn mutlak degeri atanýr
    }
    void Jump()
    {
        //PlayerRb.AddForce(new Vector2(0f, jumpSpeed));
        PlayerRb.velocity=Vector2.up * jumpSpeed;
        
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }


    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer); //deðerleri unity üzerinden seçiyoruz
        PlayerAnimator.SetBool("isGrounded", isGrounded);
    }


}
