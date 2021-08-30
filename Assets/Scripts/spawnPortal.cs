using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPortal : MonoBehaviour
{
    bool activated = false;
    public Transform spawnLocation;
    public GameObject portal; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !activated){
            activated = true;
            Instantiate(portal, spawnLocation.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
