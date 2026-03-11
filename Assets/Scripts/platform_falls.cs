using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_falls : MonoBehaviour
{
    private float fallDelay = 1f;
    private float respawnDelay = 3f;

    [SerializeField] private Rigidbody2D rb;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(respawnDelay);

        rb.bodyType = RigidbodyType2D.Static;
        transform.position = initialPosition;
    }
}
