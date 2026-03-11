using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thief_movement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

   


    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("IsDead") == false)
        {

            anim.SetBool("isRunning", true);
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }

        }
/*
        if(transform.position.y<-10)
        {
            gameObject.SetActive(false);
        }

        */
    }
}
