using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{

    public Camera cam;
   
    bool trigger;

    public GameObject uni;

   

  

    // Update is called once per frame
    void Update()
    {
      
        if (trigger)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(0, uni.transform.position.y-5, -10),Time.deltaTime*3);
            
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger = true;
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;


            cam.orthographicSize = 14;
        }
    }
    public bool isTigger()
    {
        return trigger;
    }
}
