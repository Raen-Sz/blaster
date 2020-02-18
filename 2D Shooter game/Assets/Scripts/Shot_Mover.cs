using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Mover : MonoBehaviour
{
    public Vector2 direction;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
