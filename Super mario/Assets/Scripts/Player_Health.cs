using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public int health;
    
    public AudioSource DieSound;
    public AudioSource sus;
    
   void Start(){
       sus.Play();
   }
   
    void Update()
    {

        if (gameObject.transform.position.y <-100){
            SceneManager.LoadScene("RestartScene");        
            }

    }
}   