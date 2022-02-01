using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public StateMachine stateMachine;
    public HealthBarController healthbar;
    public GameObject healthbarText;
    public float maxHp;
    public float currentHp;
    public GameObject abilityNameText;
    public GameObject abilityDescriptionText;

    public List<EnemyAbility> abilities;
    public EnemyAbility currentAbility;

    void Start()
    {
        currentHp = maxHp;

        abilities = new List<EnemyAbility>();
        abilities.Add(new Bite());
        abilities.Add(new Claw());
        abilities.Add(new Recover());

        SetNewEnemyAbility();
    }


    void Update()
    {
        healthbar.SetHealth(currentHp, maxHp);
        healthbarText.GetComponent<Text>().text = $"{currentHp}/{maxHp}";

        abilityNameText.GetComponent<Text>().text = currentAbility.name;
        abilityDescriptionText.GetComponent<Text>().text = currentAbility.description;
    }

    public void OnDamageReceived(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            //stateMachine.ChangeState(stateMachine.victoryState);
            SceneManager.LoadScene("WinComicScene", LoadSceneMode.Single);
        }
        if (currentHp > maxHp) currentHp = maxHp;
    }

    public void SetNewEnemyAbility()
    {
        if (abilities == null) return;
        var randomAbilityIndex = Random.Range(0, 3);
        currentAbility = abilities[randomAbilityIndex];
    }
}
