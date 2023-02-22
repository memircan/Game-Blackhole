using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRb;
    Animator PlayerAnimator;
    AudioSource audioSource;

    BulletPool bulletPool;
    InGameManager gameManager;

    Joystick joystick;
    JumpButton jumpButton;
    ShotButton shotButton;

    [SerializeField]
    private float jumpForce, moveSpeed, bulletSpeed,groundCheckRadius;

    float Frequency = 1f; //for shot and jump 
    float nextJumpTime, nextShotTime;

    [SerializeField]
    Transform groundCheckPosition, muzzle;

    [SerializeField]
    LayerMask groundCheckLayer;

    bool facingRight = true;
    bool isGrounded = false;


    void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();

        gameManager=FindObjectOfType<InGameManager>();
        bulletPool = FindObjectOfType<BulletPool>();
        
        jumpButton = FindObjectOfType<JumpButton>();
        shotButton = FindObjectOfType<ShotButton>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        OnGroundCheck();
        JoystickControl();
        KeyboardControl();
    }

    void JoystickControl()
    {
        PlayerRb.velocity = new Vector2(joystick.Horizontal * moveSpeed, PlayerRb.velocity.y); //yürüme. sað -> axis > 0 
        PlayerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerRb.velocity.x)); //playerspeed degerine anlýk hýzýnýn mutlak degeri atanýr

        if (PlayerRb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (PlayerRb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (jumpButton.keyDown == true && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + Frequency;
            Jump();
        }

        if (shotButton.keyDown == true && (nextShotTime < Time.timeSinceLevelLoad))
        {
            nextShotTime = Time.timeSinceLevelLoad + Frequency;
            ShootBullet();
            audioSource.Play();
        }
    }

    void KeyboardControl()
    {
        PlayerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, PlayerRb.velocity.y); //yürüme. sað -> axis > 0 
        PlayerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerRb.velocity.x)); //playerspeed degerine anlýk hýzýnýn mutlak degeri atanýr

        if (PlayerRb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (PlayerRb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + Frequency;
            Jump();
        }

        if (Input.GetMouseButtonDown(0) && (nextShotTime < Time.timeSinceLevelLoad))
        {
            nextShotTime = Time.timeSinceLevelLoad + Frequency;
            ShootBullet();
            audioSource.Play();
        }
    }
    void Jump()
    {
        PlayerRb.velocity = Vector2.up * jumpForce;
        //PlayerRb.AddForce(Vector2.up * 300f);
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
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        PlayerAnimator.SetBool("isGrounded", isGrounded);
    }

    void ShootBullet()
    {
        GameObject bullet = bulletPool.GetBullet(); 
        bullet.transform.position = muzzle.position;       
        bullet.GetComponent<Rigidbody2D>().velocity=muzzle.forward * bulletSpeed;
        if (facingRight == false)
        {
            bullet.transform.Rotate(0, 0, 180);
        }
        else
            bullet.transform.Rotate(0, 0, 0);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Failer" || collision.tag=="Rock") //player fall or hit rock
        {           
            gameManager.GameFail();
        }
    }


}
