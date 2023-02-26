using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrow;
    private float cooldownTimer;

    [Header("SFX")]
    [SerializeField] private AudioClip arrowSound;

    private void Attack()
    {
        cooldownTimer = 0;

        SoundManager.instance.PlaySound(arrowSound);
        arrow[FindArrow()].transform.position = firePoint.position;
        arrow[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrow.Length; i++)
        {
            if (!arrow[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
            Attack();
    }
}
