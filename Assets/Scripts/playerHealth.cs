using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        // cavalerul incepecu viata maxima
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        // modifica lumgimea barii de viata

        if (transform.position.y < -10)
        {
            health = 0;
            // daca cavalerul cade de pe platforma
            // jocul reincepe
        }

        if (health <= 0)
        {
            

            SceneManager.LoadSceneAsync("level 1");
            // daca cavalerul este invins, jocul reincepe
        }

        if (health > 100)
        {
            health = 100;
            //cavalerul nu poate avea mai mult de 
            // 100 de puncte de viata
        }
    }
}
