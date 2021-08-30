using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    public float timeToBeAlive;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, timeToBeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
