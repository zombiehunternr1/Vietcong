using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectileshooter : MonoBehaviour
{
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        var newProjectile = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newProjectile.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
