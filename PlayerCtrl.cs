using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float speedboost;
   
    public GameCtrl2 GameCtrl2;


    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator Anim;

    private bool isGrounded ;
    public Transform feetPos;
    public float checkRadius;
    public float JumpForce;
    public LayerMask whatIsGround;
    
    public int coincount;

    private int extraJumps;
    public int extraJumpsValue;

    public static int Coinnumtest = 0;
    public Text txtCoinnumtest;


    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;


    }

    void Awake()
    {
        if (Coinnumtest != 0)
            Coinnumtest = 0;
    }
    void Update()
    {

        float playspeed = Input.GetAxisRaw("Horizontal");
        

        
        playspeed *= speedboost;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround); // check ground

        if (playspeed != 0)
        {
            MoveHorizontal(playspeed);
        }
        else
        {
            StopMoving();
        }



        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {

            rb.velocity = Vector2.up * JumpForce;
            Jump(JumpForce);
        }
        if(isGrounded == true)
        {
            extraJumps = 1;
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps > 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }

        
    }

    public void MoveHorizontal(float playspeed)
    {
        rb.velocity = new Vector2(playspeed, rb.velocity.y);

        if (playspeed < 0)
        {
            sr.flipX = true;
        }


        if (playspeed > 0)
        {
            sr.flipX = false;
        }

        Anim.SetInteger("state", 1);
    }



    public void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        Anim.SetInteger("state", 0);
    }

    public void ATK()
    {
        Anim.SetInteger("state", 2);
    }
    public void DEAD()
    {
        Anim.SetInteger("state", 3);
    }
    public void Jump(float JumpForce)
    {
       
        Anim.SetInteger("state", 4);
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {

            print("COOOOOIN");
            Coinnumtest += 1;
            txtCoinnumtest.text = Coinnumtest.ToString();
            GameCtrl2.SaveData();
            GameCtrl2.UpdateCoinCount();
            Destroy(other.gameObject);

            //UpdateCoinCount();          
        }


        if (other.gameObject.tag == "Next State" )
        {
            if (Coinnumtest >=5)
            {                              
                print("Next level");
                GameCtrl2.SaveData();               
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
                
                
            }
            
        }

        if(other.gameObject.tag == "Enemy" )
        {
            DEAD();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Additive);
        }
    }
}

