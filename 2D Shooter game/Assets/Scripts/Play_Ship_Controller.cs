using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Play_Ship_Controller : MonoBehaviour
{
    public float speed;
    public BoxCollider2D playArea;
    public GameObject shot;
    public Transform shotSpawn;
    public float shotDelay;
    public GameObject GameOverPanel;
    public int lives;
    public float ImmunityLength;
    public Text livesText;

  
    bool canFire = true;
    bool CanBeHit = true;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveH, moveV);
        rb.velocity = move * speed;

        float clampX = Mathf.Clamp(rb.position.x, playArea.bounds.min.x, playArea.bounds.max.x);
        float clampY = Mathf.Clamp(rb.position.y, playArea.bounds.min.y, playArea.bounds.max.y);
        rb.position = new Vector2(clampX, clampY);

        if (Input.GetButtonDown("Jump"))
        {
            shoot();
        }

        if (Input.GetButton("Jump") && canFire)
        {
            shoot();
            StartCoroutine(ShotCooldown());
        }

    }
    void shoot()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    IEnumerator ShotCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(shotDelay);
        canFire = true;
    }

    private void OnDestroy()
    {
        GameOverPanel.SetActive(true);
    }

    public void LoseALife()
    {
        lives--;
        livesText.text = "";
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ImmunityCoolDown());

            
            for (int i = 0; i < lives; i++)
            {
                livesText.text = "A";
            }
                


        }
    }

    IEnumerator ImmunityCoolDown()
    {
        CanBeHit = false;
        yield return new WaitForSeconds(ImmunityLength);
        CanBeHit = true;
    }

}
