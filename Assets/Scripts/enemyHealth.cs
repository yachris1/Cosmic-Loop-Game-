using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth; 
    public GameObject enemyDeathFX;
    public Slider enemyHealthSlider;
    public AudioClip enemyHurtSound;
    public bool drops; 
    public GameObject theDrop; 

    float currentHealth;
    AudioSource enemyAS;
    public AudioClip enemyDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth=enemyMaxHealth;
        enemyHealthSlider.maxValue = currentHealth;
        enemyHealthSlider.value = currentHealth;

        enemyAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage){
        enemyHealthSlider.gameObject.SetActive(true);

        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;

        enemyAS.PlayOneShot(enemyHurtSound);

        if(currentHealth<=0) makeDead();
    }

    void makeDead(){
        Destroy(gameObject); //(gameObject.transform.parent.gameObject)
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if(drops) Instantiate(theDrop,transform.position, transform.rotation);
    }
}
