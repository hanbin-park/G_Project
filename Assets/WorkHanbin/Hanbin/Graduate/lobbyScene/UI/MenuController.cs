using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void PlayButtonOnClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
     
   
}
