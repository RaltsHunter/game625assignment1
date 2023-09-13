using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemy;

    public Transform PlayerTarget;

    public Vector3 startPosition;
    public Vector3 currentPosition;
    public Vector3 offMap;


    PacmanScript ps;
    public GameObject player;


    private void Awake()
    {
        startPosition = transform.position;
        offMap = new Vector3(0, -10, 0);
        ps = player.GetComponent<PacmanScript>();
    }



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        currentPosition = transform.position;

        //going to player
        enemy.SetDestination(PlayerTarget.position);


        if (ps.isEmpowered == true)
        {
            enemy.SetDestination(currentPosition);
            //Debug.Log("Cop sees empowerment");
        }

        if (ps.isEmpowered == false)
        {
            enemy.SetDestination(PlayerTarget.position);
            //Debug.Log("Cops moving");
        }



        //resetting the game
        if (Input.GetKey("r"))
        {

            if (ps.lives <= 0)
            {
                // WOW, NOTHING
            }
            else
            {
                transform.position = startPosition;
                Debug.Log("Cops Reset.");
            }
        }

        if (GameObject.FindGameObjectsWithTag("pizza").Length <= 0)
        {
            enemy.SetDestination(currentPosition);
        }


    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        //hitting pizza
        if (other.CompareTag("Player"))
        {
            transform.position = offMap;
        }
    }
    */
}
