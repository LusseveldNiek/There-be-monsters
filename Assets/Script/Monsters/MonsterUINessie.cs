using TMPro;
using UnityEngine;

public class MonsterUINessie : MonoBehaviour
{
    public TextMeshProUGUI monsterText;
    public MonsterTestHP monster;
    public int health;
    public int maxHealth;
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
