using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRicochet : MonoBehaviour
{
    [SerializeField] private float bulletLife = 3.0f;
    public LayerMask collision;
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit impact;

        if (Physics.Raycast(ray, out impact, Time.deltaTime + 0.05f, collision))
        {
            Vector3 ricochetDir = Vector3.Reflect(ray.direction, impact.normal);
            float rotation = 90 - Mathf.Atan2(ricochetDir.z, ricochetDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }

        GameObject bullet = this.gameObject;
        Destroy(bullet, bulletLife);

    }
}
