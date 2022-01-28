using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            MakoController controller =
             collision.GetComponent<MakoController>();
            controller.Die();
        }

    }
}
