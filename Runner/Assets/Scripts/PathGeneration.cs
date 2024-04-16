using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGeneration : MonoBehaviour
{
    public GameObject pathPiece;
    
    public Transform thresholdPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < thresholdPoint.position.z)
        {
            //copy the path piece & move forward
            //Instantiate(pathPiece, new Vector3(0, 0, transform.position.z + 10), Quaternion.identity);
            Instantiate(pathPiece, transform.position, transform.rotation);
            transform.position += new Vector3(0, 0, 2f);
        }
    }
}
