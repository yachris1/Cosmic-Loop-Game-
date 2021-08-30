using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerControl : MonoBehaviour
{
  //movement varibles 
  public float maxSpeed;

  //jumping varibles 
  bool grounded = false;
  float groundCheckRadius = 0.2f;
  public LayerMask groundLayer;
  public Transform groundCheck;
  public float jumpHeight;

  private Rigidbody2D playerRB;
  private Animator playerAni;
  bool faceRight;
 
 //shooting varibles
  public Transform gunTrig;
  public GameObject bullet; 
  float fireRate = 0.25f; 
  float nextFire = 0f;

// Start is called before the first frame update
void Start(){
   playerRB = GetComponent<Rigidbody2D>();
   playerAni = GetComponent<Animator>();
   faceRight = true;
 }

// Update is called once per frame
void Update(){
  if(grounded && Input.GetAxis("Jump")>0){
    grounded = false;
    playerAni.SetBool("onGround",grounded);
    playerRB.AddForce(new Vector2(0, jumpHeight));
  }
  //player shooting 
  if(Input.GetAxisRaw("Fire1")>0) shootingBullet(); 
}

void FixedUpdate(){

  //check if we are grounded, if not then we are falling
  grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
  playerAni.SetBool("onGround",grounded);

   float move = Input.GetAxis("Horizontal");
   playerAni.SetFloat("speed", Mathf.Abs(move));


   playerRB.velocity = new Vector2(move*maxSpeed, playerRB.velocity.y);

   if(move>0&&!faceRight){
     flip();
   }
   else if(move<0&&faceRight){ 
     flip();
   }


 }

void flip(){
  faceRight = !faceRight;
  Vector3 Scale = transform.localScale;
  Scale.x *= -1;
  transform.localScale = Scale;
}

void shootingBullet(){
  if(Time.time > nextFire){
    nextFire = Time.time+fireRate;
    if(faceRight){
      Instantiate(bullet, gunTrig.position, Quaternion.Euler (new Vector3 (0,0,0)));
    }
    else if(!faceRight){
      Instantiate(bullet, gunTrig.position, Quaternion.Euler (new Vector3 (0,0,180f)));
    }
  }



}

}
