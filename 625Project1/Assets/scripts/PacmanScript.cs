using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanScript : MonoBehaviour
{
    public float mSpeed = 50;
    public float rSpeed = 10;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * mSpeed, Space.World);
        gameObject.transform.Rotate(0, rSpeed * Time.deltaTime * hAxis, 0);
    }
}
