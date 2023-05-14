using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireball_Point;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;
    private float timeToFireBall = 0;

    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스를 클릭하고 버튼이 눌려 있는지 확인. 
        if (Input.GetMouseButton(0) && Time.time >= timeToFireBall)   
        {
            timeToFireBall = Time.time + 1 / effectToSpawn.GetComponent<Fireball_Move>().fireball_Rate;
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        // 게임 개체 생성
        GameObject vfx;

        if (fireball_Point != null)
        {
            vfx = Instantiate(effectToSpawn, fireball_Point.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No FireBall Point");
        }
    }
}
