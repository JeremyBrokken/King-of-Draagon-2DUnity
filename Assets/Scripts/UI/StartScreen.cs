using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit(); //Only works on build

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //exits playmode
#endif
    }
}
