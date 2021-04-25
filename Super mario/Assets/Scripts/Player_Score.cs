using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour
{
    public float timeLeft = 120;
    public int playerScore = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0.1f) {
            SceneManager.LoadScene ("SampleScene");
        }
    }
}
