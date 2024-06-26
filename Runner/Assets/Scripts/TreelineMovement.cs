using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreelineMovement : MonoBehaviour
{
    public Transform dissapearPoint;

    public Collider theCol;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager._canMove)
        {
            transform.position -= new Vector3(0f, 0f, GameManager._worldSpeed * Time.deltaTime);
        }

        if (transform.position.z < dissapearPoint.position.z)
        {
            transform.position += new Vector3(0f, 0f, theCol.bounds.size.z * 2);
        }
    }
}
