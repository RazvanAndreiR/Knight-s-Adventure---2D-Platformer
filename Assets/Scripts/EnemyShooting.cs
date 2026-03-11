using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject arrow;
    public Transform arrowPos;
    private GameObject player;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // se cauta pozitia cavalerului
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance=Vector2.Distance(transform.position,player.transform.position);
        // se determina distanta dintre arcas si cavaler

        if(distance <10 && player.transform.position.x<transform.position.x)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }

            // cavalerul trage cu arcul doar la intervale de timp
            // si doar daca jucatorul este suficient de aproape de el
        }    

       
    }

    void shoot()
    {
        Instantiate(arrow, arrowPos.position, Quaternion.identity);

        // este apelat algoritmul de tras cu arcul
    }
}
