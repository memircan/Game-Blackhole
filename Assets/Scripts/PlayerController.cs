using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRb;
    Animator PlayerAnimator;

    public GameObject bulletPref;

    [SerializeField]
    private float jumpSpeed, Frequency = 1f, nextJumpTime, nextShotTime , moveSpeed, bulletSpeed, fallSpeed, groundCheckRadius;

    [SerializeField]
    Transform groundCheckPosition , muzzle;

    [SerializeField]
    LayerMask groundCheckLayer;

    bool facingRight = true;
    bool isGrounded = false;

    Joystick joystick;
    JumpButton jumpButton;
    ShotButton shotButton;
    

    // Start is called before the first frame update
    void Start()
    {
        jumpButton = FindObjectOfType<JumpButton>();
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        shotButton = FindObjectOfType<ShotButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
#if UNITY_EDITOR
        KeyboardControl();
        OnGroundCheck();      
#else
        JoystickControl();
        OnGroundCheck();
#endif

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

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + Frequency;
            Jump();
        }

        if(Input.GetMouseButtonDown(0) && (nextShotTime < Time.timeSinceLevelLoad))
        {
            nextShotTime = Time.timeSinceLevelLoad + Frequency;
            ShootBullet();
        }
    }
    void Jump()
    {
        //PlayerRb.AddForce(new Vector2(0f, jumpSpeed));
        PlayerRb.velocity = Vector2.up * jumpSpeed;

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

    void ShootBullet()
    {
        GameObject tempBullet;

        if (facingRight == false)
        {         
            tempBullet = Instantiate(bulletPref, muzzle.position, Quaternion.identity);
            tempBullet.transform.Rotate(0,0,180);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        }else
            tempBullet = Instantiate(bulletPref, muzzle.position, Quaternion.identity);
            tempBullet.transform.Rotate(0, 0, 0);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

    }
}
