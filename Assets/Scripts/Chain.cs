using UnityEngine;
using UnityEngine.SceneManagement;

public class Chain : MonoBehaviour
{
    public void Destroyed()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
