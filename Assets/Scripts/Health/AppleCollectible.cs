using UnityEngine;

public class AppleCollectible : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Collectibles>().AddApple();
            gameObject.SetActive(false);
        }
    }
}
