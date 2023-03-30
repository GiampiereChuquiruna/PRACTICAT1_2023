using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 4, vCorrer = 4;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int SLIDE = 2;
    const int THROW = 3;
    const int GLIDE = 4; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            sr.flipX = false;
            rb.velocity = new Vector2(vCorrer, rb.velocity.y);
            ChangeAnimation(RUN);      
        }
        
        else if(Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
            rb.velocity = new Vector2(-vCorrer, rb.velocity.y);
            ChangeAnimation(RUN);      
        }
        else if(Input.GetKey("a")){   
                ChangeAnimation(SLIDE);
        }
        else if(Input.GetKey("c")){   
                ChangeAnimation(GLIDE);
        }
        
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(IDLE);
        }
    }
    
    private void ChangeAnimation (int a){
        animator.SetInteger("Estado", a);
    }
}
