using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class df : MonoBehaviour
{
    public float moveSpeed = 10f; // 이동 속도
    public float rotateSpeed = 50f; // 회전 속도

    void Update()
    {
        // 회전 입력 처리
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        transform.Rotate(0f, rotation, 0f);

        // 이동 입력 처리
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
