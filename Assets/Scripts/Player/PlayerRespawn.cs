using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //Checkpoint pickup sound
    private Transform currentCheckpoint; //Latest checkpoint
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        //Check checkpoint
        if(currentCheckpoint == null)
        {
            //Game over screen
            uiManager.GameOver();

            return; //Ignore rest
        }

        transform.position = currentCheckpoint.position; //Move to checkpoint
        playerHealth.Respawn(); //Restore health, reset animation

        //Move camera to new room(**checkpoint must = child of room object)
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    //Activate checkpoints
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //Save checkpoint location
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; //Deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
