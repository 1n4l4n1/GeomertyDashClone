using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;


public class RestartButtonText : MonoBehaviour
{

    public void Setup(){
        gameObject.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Game"); 
    }

    public void Exit(){
        SceneManager.LoadScene("StartMenu");
    }
    
}
