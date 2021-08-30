using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//kills the player when they fall off platform 
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            playerHealth playerFall = other.GetComponent<playerHealth>();
            playerFall.makeDead();
        }
        else Destroy(other.gameObject);
    }
}
