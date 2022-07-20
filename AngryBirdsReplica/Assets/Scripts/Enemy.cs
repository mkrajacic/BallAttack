using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public int health = 300;
    public GameObject floatingPoints;
    [HideInInspector]
    private int dmg;
    private float time = 2.5f;

    void Awake()
    {
        PlayerPrefs.SetInt("DamageToEnemies", 0);
        PlayerPrefs.SetInt("ExtraLifes", 0);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
        }
    }

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        float damage = colInfo.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
        damage += colInfo.contacts[0].normal.y;

        if(time==0)
        {
            if (damage >=1)
            {
                dmg = (int)Math.Round(damage);
                GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = dmg.ToString();
                FindObjectOfType<AudioManager>().Play("HitEnemy");
                health -= dmg;
            }
        }

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        PlayerPrefs.SetInt("DamageToEnemies", PlayerPrefs.GetInt("DamageToEnemies")+dmg);

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        FindObjectOfType<AudioManager>().Play("DestroyEnemy");

        Destroy(gameObject);
    }

}
