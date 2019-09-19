using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move1 : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveInput;





    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float scaley;
    public float scalex;

    public int extraJump;
    public Transform firePont;
    public GameObject BulletPrefab;
    public GameObject BulletPrefab2;

    public GameObject avatar1, avatar2;
    public float timebtwshot;
    public float starttimebtwshot;

    int whichon = 1;

    void Start()
    {
         
        
 
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);


        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (transform.localScale.x > 3)
            {
                gameObject.transform.localScale -= new Vector3(scalex, scaley, 0);

            }
            else
            {
                gameObject.transform.localScale += new Vector3(scalex, scaley, 0);
            }
        }

            if (timebtwshot > 0)
        {
            timebtwshot -= Time.deltaTime;
        }

        shoot2();
        switchavatar();
        shoot();
        jump();
        LeaveGame();
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;






    }
    private void FixedUpdate()
    {


        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


    }
    public void shoot2()
    {
        if (avatar2.active)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (timebtwshot <= 0)
                {
                    Instantiate(BulletPrefab, firePont.position, firePont.rotation);

                    timebtwshot = starttimebtwshot;
                }
            }
        }


    }

    public void jump()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            if (isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpforce;
            }


        }
    }
    public void shoot()
    {
        if (avatar1.active)
        {

            if (Input.GetButtonDown("Jump"))
            {


                Instantiate(BulletPrefab2, firePont.position, firePont.rotation);

            }
        }

    }
    public void LeaveGame()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void switchavatar()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            switch (whichon)
            {
                case 1:

                    whichon = 2;


                    avatar1.gameObject.SetActive(false);

                    avatar2.gameObject.SetActive(true);
                    avatar2.transform.position = avatar1.transform.position;
                    break;

                case 2:

                    avatar1.gameObject.SetActive(true);
                    avatar2.gameObject.SetActive(false);
                    avatar1.transform.position = avatar2.transform.position;

                    whichon = 1;
                    break;

            }
        }
    }
}
