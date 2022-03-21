using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public Animator anim;
    public float jumpforce;
    public float speed;
    public Text score;
    public Text lives;
    private float vertMovement;
    private float hozMovement;
    private int liveValue = 3;
    private int scoreValue = 0;
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    private bool facingRight = true;
    private int lvl = 1;
    private int temp;
    public AudioClip music;
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        lives.text = "Lives: " + liveValue.ToString();
        score.text = "Fishies Freed: " + scoreValue.ToString();
        anim = GetComponent<Animator>();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        temp = 1;
        musicSource.clip = music;
        musicSource.Play();
    }
    void Flip()
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }
    // Update is called once per frame
    void FixedUpdate()
    {
        hozMovement = Input.GetAxis("Horizontal");
        vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);
        if (facingRight == false && hozMovement > 0)
            {
             Flip();
            }
            else if (facingRight == true && hozMovement < 0)
                {
                 Flip();
                }
        if (isOnGround == false)
        {
            anim.SetInteger("State", 2);
        }
    }
    void Update()
    {

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(isOnGround == true)
            {
                anim.SetInteger("State", 1);
            }
        }
    if (!(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            if(isOnGround == true)
            {
                anim.SetInteger("State", 0);
            }  
        }      
    if (scoreValue == 4 && lvl==1)
        {
            lvl = 2;
            transform.position = new Vector3(15.95f, 2f, 0);       
        }

    if (scoreValue == 8)
        {
        winTextObject.SetActive(true);
        transform.position = new Vector3(55f, 2f, 0);
        }
    if (liveValue == 0)
        {
        loseTextObject.SetActive(true);
        transform.position = new Vector3(55f, 2f, 0);

        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 1;
            score.text = "Fishies Freed: " + scoreValue.ToString();
        }
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            liveValue -= 1;
            lives.text = "Lives: " + liveValue.ToString();
        }
        if (collision.collider.tag == "Water")
        {
            if (lvl==1)
                rd2d.transform.position = new Vector3(-1.47f, -.77f, 0);
            if (lvl==2)
                rd2d.transform.position = new Vector3(15.95f, 2f, 0);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)   
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }
        }
    }
}
