using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Range : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
