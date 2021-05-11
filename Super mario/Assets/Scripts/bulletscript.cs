using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float bulletspeed = 15f;
    public float bulletdamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletspeed;
    }

    private void kill()
    {
      Destroy(rb);
        
    }
    
  //private void OnCollisionEnter2D(Collision2D collision)
  void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag ("enemy")) {
             StartCoroutine("kill");
        }
    }
    
}
