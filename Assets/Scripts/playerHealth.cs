using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerHurtSound;
    public AudioClip playerDeathSound;
    public restartGame gameManager; 

    float currentHealth;

    PlayerController controlMovement; 

    AudioSource playerAS;

    //HUD Variables 
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverText;
    public Text youWinText;


    bool damaged = false;
    Color damagedColour = new Color(0f,0f,0f,0.5f);
    float smoothColour = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth=fullHealth;

        controlMovement = GetComponent<PlayerController>();

        //HUD Initalisation
        healthSlider.maxValue=fullHealth;
        healthSlider.value=fullHealth;

        //damaged = false;

        playerAS = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
       if (damaged){
           damageScreen.color = damagedColour;

       } 
       else {
           damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour*Time.deltaTime);
       }
       damaged = false; 
    }

    public void addDamage(float damage){
        if(damage<=0) return; 
        currentHealth-=damage;

        playerAS.clip = playerHurtSound;
        playerAS.Play();
      //playerAS.PlayOneShot(playerHurtSound);

        healthSlider.value = currentHealth;
        damaged = true;

        if(currentHealth<=0){
            makeDead();
        }
    }

    public void addHealth(float health){
         currentHealth += health;
         if(currentHealth>fullHealth) currentHealth=fullHealth;
         healthSlider.value = currentHealth;
    }

    public void makeDead(){
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        damageScreen.color = damagedColour;

        Animator gameOverAni = gameOverText.GetComponent<Animator>();
        gameOverAni.SetTrigger("gameOver");
        gameManager.gameRestart();
    }

    public void winGame(){
        Destroy(gameObject);
        gameManager.gameRestart();
        Animator youWinAni = youWinText.GetComponent<Animator>();
        youWinAni.SetTrigger("gameOver");
    }
}
