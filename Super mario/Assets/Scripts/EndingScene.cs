using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class EndingScene : MonoBehaviour
{

    public Rigidbody2D gameobject;
    public PlayableDirector director;

    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == ("Player"))
       director.Play();
    }
}
