using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDeath : MonoBehaviour
{

    public int health;
    public Gradient gradient;
    public Gradient gradientbody;
    public Image fill;
    public int damagetoplayer;
    public GameObject EnemyDeathEffect;
    public GameObject SceneChanger;
    public AudioSource coronadeathsound;
    public Slider healthbar;
    private SpriteRenderer sp;
    private Animator animator;
    public Animator camerashake;
    public ParticleSystem viralfall;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        healthbar.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        viralfall.Play();
        healthbar.value = health;
        animator.SetTrigger("hurt");
        fill.color = gradient.Evaluate(healthbar.normalizedValue);
        sp.material.color = gradientbody.Evaluate(healthbar.normalizedValue);
    }
    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(EnemyDeathEffect, transform.position, Quaternion.identity);
            Instantiate(SceneChanger, transform.position, Quaternion.identity);
            Destroy(gameObject);
            coronadeathsound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collidedobj)
    {
        if (collidedobj.gameObject.CompareTag("Player"))
        {

            collidedobj.gameObject.GetComponent<playercontroller>().TakeDamage(damagetoplayer);

        }
        camerashake.SetTrigger("shake");
    }



}