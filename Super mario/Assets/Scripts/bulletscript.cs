using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class bulletscript : MonoBehaviour
{
    public float bulletspeed = 15f;
    public float bulletdamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletspeed;
    }

    private IEnumerator kill()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    
  private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("kill");
    }
}