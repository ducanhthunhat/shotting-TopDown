using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currentEnemy;
    [SerializeField]
    private int enegyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject spawnerEnemy;
    [SerializeField] private Image energyBar;
    private bool bossCaller = false;
    private bool spawnerCaller = true;

    private void Start()
    {
        currentEnemy = 0;
        boss.SetActive(false);
        UpdateEnergy();
    }

    public void AddEnegy()
    {
        if (bossCaller == true)
        {
            return;
        }
        currentEnemy += 1;
        UpdateEnergy();
        if (currentEnemy == enegyThreshold)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
        bossCaller = true;
        boss.SetActive(true);
        spawnerCaller = false;
        spawnerEnemy.SetActive(false);

    }

    public void UpdateEnergy()
    {
        energyBar.fillAmount = (float)currentEnemy / enegyThreshold;
    }
}
