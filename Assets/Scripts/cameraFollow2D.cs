using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2D : MonoBehaviour
{
    public Transform followTarget; //camera follows the target
    public float smoothing;  //the speed in which the camera moves 
    Vector3 offset; 
    float lowPoint;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - followTarget.position;
        lowPoint = transform.position.y;
    }

    
    void FixedUpdate()
    {
        Vector3 followCamPos = followTarget.position + offset;
        transform.position = Vector3.Lerp (transform.position, followCamPos, smoothing*Time.deltaTime);
        if(transform.position.y < lowPoint) transform.position = new Vector3 (transform.position.x, lowPoint, transform.position.z);
    }
}
