using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 눌렀을 때 화염 발사 (길게)
public class SpawnProjectiles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject> ();
    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
