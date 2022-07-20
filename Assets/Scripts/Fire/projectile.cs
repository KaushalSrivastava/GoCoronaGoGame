using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;

    public LayerMask whatIsEnemy;
    public GameObject destroyeffect;

    // Start is called before the first frame update
    void Start()
    {
        damage += GameDataManager.extradamage;
        Invoke("DestroyProjectile", lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsEnemy);
        if(hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                
                hitinfo.collider.GetComponent<c1death>().TakeDamage(damage);

            }
            if (hitinfo.collider.CompareTag("Enemy2"))
            {

                hitinfo.collider.GetComponent<c2death>().TakeDamage(damage);

            }
            if (hitinfo.collider.CompareTag("Enemy3"))
            {

                hitinfo.collider.GetComponent<c3death>().TakeDamage(damage);

            }

            if (hitinfo.collider.CompareTag("Boss"))
            {

                hitinfo.collider.GetComponent<BossDeath>().TakeDamage(damage);
            }
            
            DestroyProjectile();
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
