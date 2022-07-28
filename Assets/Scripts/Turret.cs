using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    // just ref to enemy prefab 
    public Transform target;

    [Header("General")]
    //varibal for range distance, and TurnSpeed, and enemyTag.. 
    public float range = 15f;

    [Header("Use Bullets (defoult)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float FireCountDown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public Light lightEffect;


    [Header("unity setup Fields")]
    public float TurretTurnSpeed = 10f;
    private string enemyTag = "Enemy";

    //ref to emptyobject which should rotate head.thing in our model of turret
    public Transform PartToRotate;

    public Transform FirePoint;

    
    // "start" need to call InvokeReapeting matod which calling to UpdateTarget every 0.5sec
    private void Start()
    {
        // metod which calling motod to find enemy object
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    // Is metod which finding on own area enemy Object, end when it will in area, turret will follow on target
    private void UpdateTarget()
    {
        // is many enemies of GemeObject with metod FindGameObjectsWithTag which search for obj who have "Enemy" tag 
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // variable for short distance to enemy object which realize with Mathf.Infinity metod 
        float shortestDistance = Mathf.Infinity;

        // defoult variable to finded near enemy (def = null)
        GameObject nearestEnemy = null;

        // enumeration of enemy
        foreach (GameObject enemy in enemies)
        {
            //variable of distance to enemy on Vector3 with metod Distance (own position, and enemy position)
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            //when distans of enemty smallest than shortest distance/ short = distance to enemy, and nearest = enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // if we find a near enemy and it in our range, then target=enemy
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        
        if(target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserEffect.Stop();
                    lightEffect.enabled = false;
                }
                    
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            //if count down will 0( fire cd) we shoot again
            if (FireCountDown <= 0f)
            {
                Shoot();
                FireCountDown = 1f / fireRate;
            }
            FireCountDown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        //if we want to follow the object, we need our position to subtract the position of the object
        Vector3 dir = transform.position - target.position;

        // LookRotation need to call LookRotaion of dir by vector3
        Quaternion LookRotation = Quaternion.LookRotation(dir);

        // rotation by quaternion.Lerp need to smooth rotate to another targe, by 3 thing(ref rotation, quaternion look metod, and speed of rotate)
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, LookRotation, TurretTurnSpeed * Time.deltaTime).eulerAngles;

        // idk ^)
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserEffect.Play();
            lightEffect.enabled = true;
        }
            
        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = FirePoint.position - target.position;

        laserEffect.transform.rotation = Quaternion.LookRotation(dir);

        laserEffect.transform.position = target.position + dir.normalized * 1.5f;
    }

    //shoot metod will show private target from this class to "Bullet" class
    void Shoot()
    {
        // we create bulletGObj for ref 
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

        //and there we are finder of component 
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //and if != null then we call Seek from Bullet and write "target"
        if (bullet != null)
            bullet.Seek(target);
    }

    //just for show of target area in unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
