using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CannonUI : MonoBehaviour
{


    public Camera playerCamera;
    public GameObject crossHead;
    public AutoTargetedMonsterUI autoTargetedMonsterUI;
    private Image crossHeadImageComp;
    public Sprite crossHeadImage;
    public Sprite crossHeadCheckedImage;


    public float boxdistance = 1.0f;

    public GameObject Gun;

    private Cannon gun;
    private RectTransform crossHeadRect;
    public GameObject[] ammoUI;
    public GameObject targetGun;

    public LayerMask targetLayer;
    Cannon gunInfo;
    int currentAmmo;
    private Image image;





    public Image gaugeFillImage; // 게이지를 표시할 Image 컴포넌트
    public GameObject gaugeUI; // 게이지 UI 오브젝트

    private bool isMouseDown = false; // 마우스 버튼이 눌렸는지 여부
    private float holdDuration = 0f; // 버튼을 누른 지속 시간

    public float maxHoldDuration = 3f; // 게이지가 가득 차는 시간

    private Color originalColor; // 원래의 이미지 색상


    private bool isPlayingSound = false;
    public AudioSource gaugeUpSound;

    void Awake()
    {
        autoTargetedMonsterUI = GetComponent<AutoTargetedMonsterUI>();
        gun = Gun.GetComponent<Cannon>();
        crossHeadImageComp = crossHead.GetComponent<Image>();
        Cursor.visible = false;
        crossHeadRect = crossHead.GetComponent<RectTransform>();
        gunInfo = targetGun.GetComponent<Cannon>();
        currentAmmo = gunInfo.currentAmmo;
        originalColor = gaugeFillImage.color; // 원래의 이미지 색상 저장
        gaugeUI.SetActive(false); // 게이지 UI 초기에 비활성화
    }






    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        ChangeUI(mousePos);

        Guage();

    }


    private void ChangeUI(Vector3 mousePos)
    {
        Ray ray = playerCamera.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        bool isDetected = Physics.BoxCast(ray.origin, new Vector3(boxdistance, boxdistance, boxdistance), ray.direction, out hitInfo, Quaternion.identity, Mathf.Infinity, targetLayer);

        bool isDefaultLayer = (hitInfo.collider is not null) && (hitInfo.collider.gameObject.layer == targetLayer);
        //Debug.Log(isDefaultLayer);
        if (!isDefaultLayer && isDetected)
        {

            Debug.Log("checked!");
            gunInfo.IsMonsterInCrossHead = true;
            crossHeadImageComp.sprite = crossHeadCheckedImage;

            gunInfo.MonsterPos = hitInfo.collider.gameObject.transform.position;

            autoTargetedMonsterUI.targetedMonster = hitInfo.collider.gameObject.transform;


        }
        else
        {
            gunInfo.IsMonsterInCrossHead = false;
            crossHeadImageComp.sprite = crossHeadImage;
            autoTargetedMonsterUI.targetedMonster = null;
        }

        crossHeadRect.position = mousePos;
    }






    void Guage()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            holdDuration = 0f;
            gaugeUI.SetActive(true); // 마우스 버튼을 누를 때 게이지 UI 활성화
            PlaySound();
        }

        if (isMouseDown)
        {
            holdDuration += Time.deltaTime;

            // 게이지가 가득 찼을 때 특정 행동 수행
            if (holdDuration >= maxHoldDuration)
            {
                gaugeFillImage.color = Color.green;
                if (Input.GetMouseButtonUp(0))
                {
                    gunInfo.Shoot();
                    StopSound();
                }
            }

            // 게이지 채우기
            float fillAmount = holdDuration / maxHoldDuration;
            gaugeFillImage.fillAmount = fillAmount;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            gaugeFillImage.color = originalColor;
            gaugeUI.SetActive(false); // 마우스 버튼을 뗄 때 게이지 UI 비활성화
            StopSound();
        }
    }

    private void StopSound()
    {
        if (isPlayingSound)
        {
            gaugeUpSound.Stop();
            isPlayingSound = false;
        }
    }
    private void PlaySound()
    {
        if (!isPlayingSound)
        {
            gaugeUpSound.Play();
            isPlayingSound = true;
        }
    }

}
