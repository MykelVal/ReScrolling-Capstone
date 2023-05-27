using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    public Text healthText;
    public Image stressBar;
    public Image[] stressPoints;

    float health, maxHealth = 100;
    float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health + "%";
        if (health > maxHealth) health = maxHealth;
        lerpSpeed = 3f * Time.deltaTime;

        stressBarFiller();
        ColorChanger();
    }

    void stressBarFiller()
    {
        stressBar.fillAmount = Mathf.Lerp(stressBar.fillAmount, (health / maxHealth), lerpSpeed);

        for (int i = 0; i < stressPoints.Length; i++)
        {
            stressPoints[i].enabled = !DisplayStressPoint(health, i);
        }
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        stressBar.color = healthColor;

    }
  
    bool DisplayStressPoint (float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }

    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
    }
}
