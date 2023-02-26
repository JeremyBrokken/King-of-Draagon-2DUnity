using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    private float appleCount;
    public Text appleText;

    private void Awake()
    {
        appleCount = 0;
    }
    private void Update()
    {
        appleText.text = "" + appleCount;
    }

    public void AddApple()
    {
        appleCount++;
    }
}