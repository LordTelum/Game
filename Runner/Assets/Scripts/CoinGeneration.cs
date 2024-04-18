using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    
    public float timeBetweenCoins;
    private float coinGenCounter;
    
    public GameObject[] coinGroups;
    public Transform topPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._canMove)
        {
            coinGenCounter -= Time.deltaTime;
            
            if (coinGenCounter <= 0)
            {
                
                bool goTop = Random.value > 0.5f;
                
                int chosenCoinGroup = Random.Range(0, coinGroups.Length);
                
                if (goTop)
                {
                    Instantiate(coinGroups[chosenCoinGroup], transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(coinGroups[chosenCoinGroup], topPos.position, transform.rotation);
                }
                
                coinGenCounter = Random.Range(timeBetweenCoins * 0.75f, timeBetweenCoins * 1.25f);
            }
        }
    }
}
