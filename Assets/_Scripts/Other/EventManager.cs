using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public void LoadNextBuildIndex(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadBackBuildIndex(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void LoadMainScene(){
        SceneManager.LoadScene("Main Scene");
    }
    public void LoadLevel(int index){
        SceneManager.LoadScene("Level " + index);
    }
    public void ExitWindow(){
        Application.Quit();
    }
}
