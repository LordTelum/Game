using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool canMove;
    static public bool _canMove;
    public float worldSpeed;
    static public float _worldSpeed;
    public int coinsCollected;
    private bool gameStarted;
    
    //speeding up
    public float timeToIncreaseSpeed;
    private float increaseSpeedCounter;
    public float speedMultiplier;
    private float targetSpeedMultiplier;
    public float acceleration;
    private float accelerationStore;
    public float speedIncreaseAmount;
    private float worldSpeedStore;
    
    public GameObject tapMessage;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI distanceText;
    private float distanceCovered;
    
    //death screen
    public GameObject deathScreen;
    public TextMeshProUGUI finalCoinsText;
    public TextMeshProUGUI finalDistanceText;
    public float deathScreenDelay;
    
    public string mainMenuName;
    public GameObject notEnoughCoinsScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("CoinsCollected", 0);
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            coinsCollected = PlayerPrefs.GetInt("CoinsCollected");
        }
        increaseSpeedCounter = timeToIncreaseSpeed;
        targetSpeedMultiplier = speedMultiplier;
        worldSpeedStore = worldSpeed;
        accelerationStore = acceleration;
        coinsText.text = "Coins: " + coinsCollected;
        distanceText.text = distanceCovered + "m";

    }

    // Update is called once per frame
    void Update()
    {
        _canMove = canMove;
        _worldSpeed = worldSpeed;

        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            canMove = true;
            _canMove = true;

            gameStarted = true;
            tapMessage.SetActive(false);
            
        }

        if (canMove)
        {
            increaseSpeedCounter -= Time.deltaTime;

            if (increaseSpeedCounter <= 0)
            {
                increaseSpeedCounter = timeToIncreaseSpeed;
                targetSpeedMultiplier = targetSpeedMultiplier * speedIncreaseAmount;
                
                timeToIncreaseSpeed = timeToIncreaseSpeed * .97f;
            }
            acceleration = accelerationStore * speedMultiplier;
            
            speedMultiplier = Mathf.MoveTowards(speedMultiplier, targetSpeedMultiplier, acceleration * Time.deltaTime);
            worldSpeed = worldSpeedStore * speedMultiplier;
            
            //updating ui
            distanceCovered += Time.deltaTime * worldSpeed;
            distanceText.text = Mathf.Floor(distanceCovered) + "m";
        }
        
    }

    public void HitHazard()
    {
        canMove = false;
        _canMove = false;
        
        PlayerPrefs.SetInt("CoinsCollected", coinsCollected);
        
        
        StartCoroutine(ShowDeathScreen());
        finalCoinsText.text = coinsCollected + " Coins!";
        finalDistanceText.text = Mathf.Floor(distanceCovered) + "m";
    }
    public IEnumerator ShowDeathScreen()
    {
        yield return new WaitForSeconds(deathScreenDelay);
        deathScreen.SetActive(true);
    }
    
    public void AddCoin()
    {
            coinsCollected++;
            coinsText.text = "Coins: " + coinsCollected;
    }

    public void ContinueGame()
    {
        if (coinsCollected >= 100)
        {
            coinsCollected -= 100;
            
            canMove = true;
            _canMove = true;
            deathScreen.SetActive(false);
            
        }
        else
        {
            notEnoughCoinsScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
    
}
