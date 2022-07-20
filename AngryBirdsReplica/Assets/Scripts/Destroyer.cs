using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Player" || tag == "Enemy" || tag == "Brick")
        {
            Destroy(col.gameObject);
        }
    }
}
