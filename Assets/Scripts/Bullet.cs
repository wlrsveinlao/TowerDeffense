using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //ref of target and bulletEffect, but ref of target we will find in different class (turret)
    private Transform target;
    public GameObject BulletEffect;

    public float speed = 100f;

    public float explosionRadius = 0;
    //metod of bullet follow to target
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        // so when we will killed owr enemy, or something else, we are destroy bullet
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // is that default thing when we need to contact to object
        Vector3 dir = target.position - transform.position;

        //speed and fix lowFps-lowSpeed
        float distancePerFrame = speed * Time.deltaTime;

        //so its current distance of a bullet to enemty, and when "first <= second" its mean that we already hit the object
        if (dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        //is that metod to follow bullet ---> enemy 
        transform.Translate(dir.normalized * distancePerFrame, Space.World);
        transform.LookAt(target);

    }
    void HitTarget()
    {
        //we create GO effect becouse we should destroy effect and gameobj
        GameObject EffectBullet = (GameObject)Instantiate(BulletEffect, transform.position, transform.rotation);

        Destroy(EffectBullet, 5f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        
        Destroy(gameObject);

    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);

    }
    void Explode()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
}
