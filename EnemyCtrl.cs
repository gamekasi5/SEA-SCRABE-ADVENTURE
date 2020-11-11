using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] float closeDistance;
    [SerializeField] float longDistance;
    [SerializeField] Transform Player;

    public float speed;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private SpriteRenderer sr;
    Animator anim;

    float DistanceToPlayer = Mathf.Infinity;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
        DetectPlayer();
        
    }

    public void DetectPlayer()
    {
       
        DistanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if (DistanceToPlayer <= longDistance)
        {
            anim.SetInteger("state", 1);
        }
        if (DistanceToPlayer <= closeDistance)
        {
            anim.SetInteger("state", 2);
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
       
       else
        {
            anim.SetInteger("state", 0);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, longDistance);
    }
}
