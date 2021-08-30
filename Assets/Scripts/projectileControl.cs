using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour
{
    public float bulletSpeed;

    Rigidbody2D bulletRB;

    // Start is called before the first frame update
    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
        bulletRB.AddForce(new Vector2(-1,0)*bulletSpeed, ForceMode2D.Impulse);
        else bulletRB.AddForce(new Vector2(1,0)*bulletSpeed, ForceMode2D.Impulse);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void forceRemoved(){
        bulletRB.velocity=new Vector2(0,0);
    }
}
