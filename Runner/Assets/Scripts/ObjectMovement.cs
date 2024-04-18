using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //how fast things move in the world
    //public float moveSpeed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the Z axis of an object negatively
        //transform.position -= new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
        
        if(GameManager._canMove)
        {
            transform.position -= new Vector3(0f, 0f, GameManager._worldSpeed * Time.deltaTime);
        }
        
        if(transform.position.z < -13f)
        {
            Destroy(gameObject);
        }
    }
}
