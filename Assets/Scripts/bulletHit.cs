using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    public float bulletDamage;

    projectileControl myPC; 

    public GameObject bulletEffect; 

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("shootable")){
            myPC.forceRemoved();
            Instantiate(bulletEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy"){
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(bulletDamage);
            }
        }
    
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("shootable")){
            myPC.forceRemoved();
            Instantiate(bulletEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy"){
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(bulletDamage);
            }
        }
    }
}
