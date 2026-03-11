using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyArrowScript : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        // se stie pozitia caracterului


        if (player.transform.position.x > 30)
        {

            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y + 1).normalized * force;


            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
           
            transform.rotation = Quaternion.Euler(0, 0, rot - 5);

            // se fixeaza traseul sagetii si unghiul de tragere
        }

       

       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>10)
        {
            Destroy(gameObject);
            // daca trec 10 secunde si sageata nu 
            // a lovit nimic, aceasta dispare
            
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerHealth>().health -= 15;
            Destroy(gameObject);

            // cand sageata loveste cavalerul, acesta
            // pierde 15 puncte de viata
        }
    }
}
