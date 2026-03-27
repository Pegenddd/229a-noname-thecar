using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Score Amount")]
    public int scoreValue = 10; // ได้กี่คะแนน

    // OnTriggerEnter จะทำงานเมื่อมีวัตถุวิ่งทะลุเข้ามา
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            GameManager gm = FindAnyObjectByType<GameManager>();
            if (gm != null)
            {
                gm.AddScore(scoreValue);
            }
            
            
            Destroy(gameObject); 
        }
    }
}