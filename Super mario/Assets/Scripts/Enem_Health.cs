using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem_Health : MonoBehaviour
{
    // Start is called before the first frame update
        void Update()
    {
        if (gameObject.transform.position.y <-10){
            Destroy (gameObject);
        }

    }

}
