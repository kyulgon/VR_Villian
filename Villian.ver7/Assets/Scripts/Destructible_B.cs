using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_B : MonoBehaviour
{
    public GameObject destroyedVersion; // Reference to the shattered version of the object

    //If the player clicks on the object
    public void Destroyy()
    {
        //spawn a shattered object
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        //Remove the current object
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
