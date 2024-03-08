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
    public void loadLevel(int index){
        SceneManager.LoadScene("Level " + index);
    }
    public void exitWindow(){
        Application.Quit();
    }
}
