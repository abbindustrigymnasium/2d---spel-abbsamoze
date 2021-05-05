using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public int health;
    public AudioSource StartSound;
    public AudioSource DieSound;
    
   void Start(){
       StartSound.Play();

   }
   
    void Update()
    {

        if (gameObject.transform.position.y <-100){
            SceneManager.LoadScene("RestartScene");        
            }

    }
}   