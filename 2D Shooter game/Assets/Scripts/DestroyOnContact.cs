using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public string tagToDestroy;
    public GameObject PlayerExplosion;
    public GameObject EnemyExplosion;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToDestroy))
        {
            
            Destroy(gameObject);

            if (tagToDestroy == "Enemy")
            {
                int points = other.GetComponent<Enemy>().points;
                GameObject.FindWithTag("GameController").GetComponent<GameController>().AddToScore(points);
                Instantiate(EnemyExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
            }
            else if (tagToDestroy == "Player")
            {
                Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
                other.GetComponent<Play_Ship_Controller>().LoseALife();
            }
        }
    }
}
