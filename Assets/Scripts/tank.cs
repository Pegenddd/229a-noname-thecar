using UnityEngine;

public class tank : MonoBehaviour
{
    [Header("Damage Amount")]
    public int damageValue = 20; 

    
    void OnCollisionEnter(Collision collision)
    {
        // เช็คว่าคนที่ชนคือรถของเรา (Player) ไหม
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gm = FindAnyObjectByType<GameManager>();
            if (gm != null)
            {
                gm.TakeDamage(damageValue);
            }
            
            
            Destroy(gameObject);
        }
    }
}