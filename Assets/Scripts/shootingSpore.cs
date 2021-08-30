using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingSpore : MonoBehaviour
{

    public GameObject theProjectile; 
    public float shootTime;
    public int shootChance; 
    public Transform shootFrom; 

    float nextShootTime;
    Animator cannonAni; 

    // Start is called before the first frame update
    void Start()
    {
        cannonAni = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player" && nextShootTime<Time.time){
            nextShootTime = Time.time+shootTime;
            if(Random.Range(0, 10)>=shootChance){
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
                cannonAni.SetTrigger("CannonShoot");
            }
        }
    }



}
