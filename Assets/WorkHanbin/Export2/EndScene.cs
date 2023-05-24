using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class EndScene : MonoBehaviour
{
    public int targetValue = 10000;

    public TextMeshProUGUI textMeshPro;
    public float popDuration = 0.1f;
    public float popScale = 1.5f;
    public float duration = 3f;


    public TextMeshProUGUI gradeText;
    public float gradePopTime = 1.2f;

    public TextMeshProUGUI moveText;
    public float mentPopTime=2f;
    public float moveTime = 1f;
    public float transValue = 30f;







    public int veryLow;
    public int low;
    public int middle;
    public int high;

    private void Start()
    {
        targetValue = ScoreManager.Instance.score;
        int startValue = 0;

        DOTween.To(() => startValue, x => startValue = x, targetValue, duration)
            .SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                textMeshPro.text = startValue.ToString();
            })
            .OnComplete(() =>
            {
                textMeshPro.text = targetValue.ToString();
                PopText();
                Invoke("DisplayGradeText", gradePopTime);
                Invoke("PopGrade", gradePopTime);
                 Invoke("MoveText", mentPopTime);
            });
    }

    private void PopText()
    {
        textMeshPro.transform.DOScale(popScale, popDuration)
            .OnComplete(() =>
            {
                textMeshPro.transform.DOScale(1f, popDuration);

            });
    }


   private void PopGrade()
    {
        gradeText.transform.DOScale(popScale, popDuration)
            .OnComplete(() =>
            {
                gradeText.transform.DOScale(1f, popDuration);
            });
    }


    private void DisplayGradeText()
    {
        if (targetValue < veryLow)
        {
            gradeText.text = "B+";
        }
        else if (targetValue >= veryLow && targetValue < low)
        {
            gradeText.text = "A";
        }
        else if (targetValue >= low && targetValue < middle)
        {
            gradeText.text = "A+";
        }
        else if (targetValue >= middle && targetValue < high)
        {
            gradeText.text = "S";
        }
        else if (targetValue >= high)
        {
            gradeText.text = "S+";
        }
    }

    private void MoveText()
    {
        moveText.transform.DOMoveY(moveText.transform.position.y + transValue, moveTime);
    }
}
//퍼센트 표시할 텍스트

//     IEnumerator LoadScene(string sceneName)
//     {
//         Loading.SetActive(true); //로딩 화면을 띄움

//         AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
//         async.allowSceneActivation = false; //퍼센트 딜레이용

//         float past_time = 0;
//         float percentage = 0;

//         while (!(async.isDone))
//         {
//             yield return null;

//             past_time += Time.deltaTime;

//             if (percentage >= 90)
//             {
//                 percentage = Mathf.Lerp(percentage, 100, past_time);

//                 if (percentage == 100)
//                 {
//                     async.allowSceneActivation = true; //씬 전환 준비 완료
//                 }
//             }
//             else
//             {
//                 percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
//                 if (percentage >= 90) past_time = 0;
//             }
//             Loading_text.text = percentage.ToString("0") + "%"; //로딩 퍼센트 표기
//         }
//     }
// }
