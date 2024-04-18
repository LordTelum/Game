using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //how fast the player moves
    
    public float moveSpeed = 10.0f;
	
	public GameManager theGM;
	
	public Rigidbody rb;
	
	public float jumpForce;

	public Transform modelHolder;
	
	public LayerMask whatIsGround;

	public bool onGround;

	public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		if(GameManager._canMove)
		{
            onGround = Physics.OverlapSphere(modelHolder.position, 0.2f, whatIsGround).Length > 0;

			if(onGround)
            {

				if(Input.GetMouseButtonDown(0))
				{
	        		//Make the player Jump
					rb.velocity = new Vector3(0f, jumpForce, 0f);
				}
			}
		}

		//Controll Animations
		anim.SetBool("walking", GameManager._canMove);
		anim.SetBool("jumping", !onGround);
    }
	
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hazard")
        {
            theGM.HitHazard();
			
			rb.constraints = RigidbodyConstraints.None; 
			rb.velocity = new Vector3(Random.Range(GameManager._worldSpeed * 0.5f, GameManager._worldSpeed * 0.5f), 2.5f , -GameManager._worldSpeed);
        }

	        if(other.tag == "Coin")
        {
            theGM.AddCoin();
	        Destroy(other.gameObject);
        }
    }
	
}
