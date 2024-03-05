using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eventManager : MonoBehaviour
{
    public void loadNextBuildIndex(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadBackBuildIndex(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void loadMainScene(){
        SceneManager.LoadScene("Main Scene");
    }
    public void loadMenuLevel(){
        SceneManager.LoadScene("Menu Level");
    }
    public void loadLevel1(){
        SceneManager.LoadScene("Level 1");
    }
    public void loadLevel2(){
        SceneManager.LoadScene("Level 2");
    }
    public void loadLevel3(){
        SceneManager.LoadScene("Level 3");
    }
    public void openFB(){
        Application.OpenURL("https://www.facebook.com/TrungKien25102k3");
    }
    public void exitWindow(){
        Application.Quit();
    }
}
