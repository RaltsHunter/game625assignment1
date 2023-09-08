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
    public bool isEmpowered = false;
    public float timerReload = 10;
    private int acabMultiplier = 1;



    // Start is called before the first frame update
    void Start()
    {
        
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
            //destroy cop?
            score = score + (10 * acabMultiplier);
            acabMultiplier++;
            scoreCount.text = score.ToString();
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

    }
