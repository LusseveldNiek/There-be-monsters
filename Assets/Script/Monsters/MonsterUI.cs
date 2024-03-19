using UnityEngine;
using TMPro;

public class MonsterUI : MonoBehaviour
{
    public TextMeshProUGUI monsterText;
    public MonsterTestHP monster;
    private int health;
    private int maxHealth;
    void Start()
    {
        health = monster.health;
        maxHealth = monster.maxHealth;
        UpdateMonsterUI();
    }
    public void UpdateMonsterUI()
    {
        health = monster.health;
        maxHealth = monster.maxHealth;
        monsterText.text = monster.transform.name + " " + health.ToString() + "/" + maxHealth.ToString();
    }
}
