using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeUI : MonoBehaviour
{

    private Image HealtBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    Player_Stat Player;
// Start is called before the first frame update
    void Start()
    {
        //Trouver l'image et mettre les parratre
        HealtBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player_Stat.lives;
        HealtBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
