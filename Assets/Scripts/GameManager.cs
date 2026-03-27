using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; // ต้องมีตัวนี้เพื่อใช้ระบบหน่วงเวลา (Coroutine)

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hpText;
    
    [Header("End Game UI")]
    public GameObject endParentPanel; // ตัวแผ่น Panel ที่เราปิดไว้
    public TextMeshProUGUI statusText; // ตัวหนังสือที่จะเปลี่ยนคำพูด

    [Header("Player Stats")]
    public int score = 0;
    public int hp = 100;
    public int targetScore = 50;

    void Start()
    {
        
        if (endParentPanel != null) endParentPanel.SetActive(false);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
        if (score >= targetScore) StartCoroutine(EndGameRoutine("YOU WIN!", true));
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            StartCoroutine(EndGameRoutine("GAME OVER!", false));
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (hpText != null) hpText.text = "HP: " + hp;
    }

    
    IEnumerator EndGameRoutine(string message, bool isWin)
    {
        
        endParentPanel.SetActive(true);
        statusText.text = message;
        
        // Change the text color according to the result (win - green, lose - red).
        statusText.color = isWin ? Color.green : Color.red;

        // Pause for 3 seconds (to allow players to see the UI).
        yield return new WaitForSeconds(3f);

        // Change Scene
        if (isWin) SceneManager.LoadScene("CreditScene");
        else SceneManager.LoadScene("MenuScene");
    }
}