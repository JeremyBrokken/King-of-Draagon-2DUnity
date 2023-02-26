using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Start")]
    [SerializeField] private GameObject startScreen;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake()
    {
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        //Pause control
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
            PauseGame(true);
        }
    }

    #region Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Game over functions
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startScreen.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit(); //Only works on build

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //exits playmode
        #endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        //activity control
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion
}
