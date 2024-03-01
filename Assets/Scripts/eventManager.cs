using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eventManager : MonoBehaviour
{
    public void loadLevel1(){
        SceneManager.LoadScene("Level 1");
    }
    public void loadMenuLevel(){
        SceneManager.LoadScene("Menu Level");
    }
    public void showAbout(){

    }
    public void exitWindow(){
        Application.Quit();
    }
}
