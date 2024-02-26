using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterUI : MonoBehaviour
{
    public TextMeshProUGUI monsterText;
    public MonsterHealth monster;
    public int health;
    public int maxHealth;
    void Start()
    {
        monster = GetComponent<MonsterHealth>();
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
