using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementControl : MonoBehaviour
{
    public float enemySpeed;
    Animator enemyAni;

    //enemy facing directions 
    public GameObject enemyFaceGraphic; 
    bool itcanFlip = true;
    bool isfacingRight = false; 
    float flipTiming = 5f;
    float flipNext = 0f;

    //enemy attack
    public float attackTime;
    float startAttackTime;
    bool attacking; 
    Rigidbody2D enemyRB; 

    // Start is called before the first frame update
    void Start()
    {
        enemyAni = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > flipNext){
            if(Random.Range (0,10)>=5) facingFlip();
            flipNext = Time.time + flipTiming;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(isfacingRight && other.transform.position.x < transform.position.x) {
               facingFlip(); 
            }
            else if(!isfacingRight && other.transform.position.x > transform.position.x){
                facingFlip();
            } 
            itcanFlip = false;
            attacking = true; 
            startAttackTime = Time.time + attackTime;
        }
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if(startAttackTime < Time.time){
                if(!isfacingRight) enemyRB.AddForce(new Vector2(-1,0)*enemySpeed);
                else enemyRB.AddForce(new Vector2(1,0)*enemySpeed);
                enemyAni.SetBool("isAttacking", attacking);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            itcanFlip = true;
            attacking = false;
            enemyRB.velocity = new Vector2(0f,0f);
            enemyAni.SetBool("isAttacking", attacking);
        }
    }


    void facingFlip(){
        if(!itcanFlip) return;
        float facingX = enemyFaceGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyFaceGraphic.transform.localScale = new Vector3(facingX, enemyFaceGraphic.transform.localScale.y, enemyFaceGraphic.transform.localScale.z);
        isfacingRight = !isfacingRight;
    }
}
