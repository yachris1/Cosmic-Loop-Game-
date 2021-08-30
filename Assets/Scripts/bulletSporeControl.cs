using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSporeControl : MonoBehaviour
{
    public float maxSporeSpeed;
    public float minSporeSpeed;
    public float sporeAngle; 
    public float sporeTorqueAngle;

    Rigidbody2D sporeRB;

    // Start is called before the first frame update
    void Start()
    {
        sporeRB = GetComponent<Rigidbody2D>();
        sporeRB.AddForce(new Vector2(Random.Range(-sporeAngle, sporeAngle), Random.Range(minSporeSpeed, maxSporeSpeed)), ForceMode2D.Impulse);
        sporeRB.AddTorque(Random.Range(-sporeTorqueAngle, sporeTorqueAngle));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
