using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject floatingPoints;
    [HideInInspector]
    private int dmg;
    private float time = 2.5f;
    void Awake()
    {
        PlayerPrefs.SetInt("DamageToBricks", 0);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            time = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null)
        {
            return;
        }

        float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;


        if(time==0)
        {
            if (damage >= 5)
            {
                FindObjectOfType<AudioManager>().Play("DestroyBrick");
            }

            if (damage >=1)
            {
                Health -= damage;
                dmg = (int)Math.Round(damage);
                GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = dmg.ToString();
            }
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);

            string BrickType = this.gameObject.name;
            if (BrickType.Contains("tall"))
            {
                PlayerPrefs.SetInt("DamageToBricks", PlayerPrefs.GetInt("DamageToBricks") + 70);
            }
            else if (BrickType.Contains("normal"))
            {
                PlayerPrefs.SetInt("DamageToBricks", PlayerPrefs.GetInt("DamageToBricks") + 90);
            }
            else if (BrickType.Contains("block"))
            {
                PlayerPrefs.SetInt("DamageToBricks", PlayerPrefs.GetInt("DamageToBricks") + 150);
            }
        }
    }
    public GameObject destroyEffect;
    public float Health = 70f;
}
