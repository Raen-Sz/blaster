using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 direction;
    public GameObject shot;
    public Transform shotSpawn;
    public float shotDelay;
    public int points;
    

    Rigidbody2D rb;
    BoxCollider2D playArea;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction.x = Random.Range(-direction.x, direction.x);
        rb.velocity = direction;

        playArea = GameObject.Find("Play_Bound").GetComponent<BoxCollider2D>();
        StartCoroutine(shoot());
    }

    void Update()
    {
        
        if (rb.position.x > playArea.bounds.max.x && rb.velocity.x > 0)
        {
            direction.x = -Mathf.Abs(direction.x);
            rb.velocity = direction;
        }
        else if (rb.position.x < playArea.bounds.min.x && rb.velocity.x < 0)
        {
            direction.x = Mathf.Abs(direction.x);
            rb.velocity = direction;
        }
    }

    IEnumerator shoot()
    {
        while (true)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            yield return new WaitForSeconds(shotDelay);
        }
        
    }

}
