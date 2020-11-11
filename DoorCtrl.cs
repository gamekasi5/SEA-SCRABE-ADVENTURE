using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  DoorCtrl : MonoBehaviour
{
    [SerializeField] float longDistance;
    [SerializeField] Transform Player;

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
        DetectPlayer();
    }

    public void  DetectPlayer()
    {
        DistanceToPlayer = Vector3.Distance(Player.position, transform.position); // check Term and conditions of passing
        if (DistanceToPlayer <= longDistance && PlayerCtrl.Coinnumtest >= 5)
        {         
            anim.SetInteger("state", 1);            
        }

        else
        {
            anim.SetInteger("state", 0);
        }
    }
    private void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.black;  // draw Term
        Gizmos.DrawWireSphere(transform.position, longDistance);
    }
}
