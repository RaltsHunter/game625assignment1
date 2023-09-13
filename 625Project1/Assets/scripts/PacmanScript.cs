using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PacmanScript : MonoBehaviour
{
    public float mSpeed = 50;
    public float rSpeed = 10;
    public Rigidbody rb;
    public float timer = 0;
    public float score = 0;
    public TMP_Text scoreCount;
    public TMP_Text uiText;
    public TMP_Text lifeCount;
    public bool isEmpowered = false;
    public float timerReload = 10;
    private int acabMultiplier = 1;
    public bool gameOver;
    //Renderer render;
    //public Material mat;
    //public Material defaultMat;
    public Vector3 startPosition;
    public float lives = 3;
    public bool copHit;
    
    private void Awake()
    {
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        copHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //player controls
        float hAxis = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * mSpeed, Space.World);
        gameObject.transform.Rotate(0, rSpeed * Time.deltaTime * hAxis, 0);
        //checking for empowered
        if (isEmpowered) empoweredTimerManager();
        
        //empowering conditions
        if (isEmpowered)
        {
            mSpeed = 4;
            rSpeed = 200;
            //render.material = mat;
        }
        else
        {
            mSpeed = 3;
            rSpeed = 150;
            //render.material = defaultMat;
        }

        //win text
        if (GameObject.FindGameObjectsWithTag("pizza").Length <= 0)
        {
            uiText.text = "You collected all the pizzas! You win!";
            gameOver = true;
        }

        //calling the gameEnd function
        gameEnd();

        //resetting the game
        if (Input.GetKeyDown ("r"))
        {
            if (lives <= 0)
            {
                // WOW, NOTHING
            }
            else {
                transform.position = startPosition;
                Debug.Log("Game Reset.");
                gameOver = false;
                uiText.text = "";
                lives --;
                copHit = false;
            }
        }

        //life text
        lifeCount.text = lives.ToString();
    }

    private void OnTriggerEnter(Collider other)
     {
        //hitting pizza
        if (other.CompareTag("pizza"))
         {
            Destroy(other.gameObject);
            score = score + 1;
            scoreCount.text = score.ToString();


         }
      
        if (other.CompareTag("gasCan"))
        {
            Destroy(other.gameObject);
            timer = timerReload;
            isEmpowered = true;
            score = score + 5;
            scoreCount.text = score.ToString();

        }
        if (isEmpowered && other.CompareTag("cop"))
        {
            Destroy(other.gameObject);
            //other.gameObject.transform.position = new Vector3(0, -10, 0);
            copHit = true;
            score = score + (10 * acabMultiplier);
            acabMultiplier++;
            scoreCount.text = score.ToString();
        }

        if (isEmpowered == false && other.CompareTag("cop"))
        {
            if (lives <= 0)
            {
                uiText.text = "Out of Lives! Game Over.";
                gameOver = true;
            }
            else
            {
                uiText.text = "Busted! Press R to Reset.";
                gameOver = true;
            }
        }

    }

    private void empoweredTimerManager()
     {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            isEmpowered = false;
            acabMultiplier = 1;

        }
     }

    private void gameEnd()
    {
        if (gameOver == true)
        {
            mSpeed = 0;
        }
    }



    }
