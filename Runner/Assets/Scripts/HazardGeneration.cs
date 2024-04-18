using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGeneration : MonoBehaviour {

    public GameObject[] hazards;

    public float timeBetweenHazards;
    private float hazardGenCounter;

    public GameManager theGM;

	// Use this for initialization
	void Start () {
        hazardGenCounter = timeBetweenHazards;
	}
	
	// Update is called once per frame
	void Update () {

        if (theGM.canMove)
        {

            hazardGenCounter -= Time.deltaTime;

            if (hazardGenCounter <= 0)
            {

                int chosenHazard = Random.Range(0, hazards.Length);
                Instantiate(hazards[chosenHazard], transform.position, transform.rotation);

                hazardGenCounter = Random.Range(timeBetweenHazards * 0.75f, timeBetweenHazards * 1.25f);

                //increase difficulty
                hazardGenCounter = hazardGenCounter / theGM.speedMultiplier;

            }
        }

	}
}
