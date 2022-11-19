using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLerp : MonoBehaviour
{
    [SerializeField] GameObject Controller;
    [SerializeField] PlayerData PlayerData;
    float lerpSpeed;

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.baseHealth > PlayerData.maxbaseHealth) PlayerData.baseHealth = PlayerData.maxbaseHealth;

        lerpSpeed = 3f * Time.deltaTime;


        HealthBarLerp();
        ColorLerp();
    }

    void HealthBarLerp()
    {
        Slider slider = GetComponent<Slider>();
        float startHealth = slider.value;

        slider.value = Mathf.Lerp(startHealth, PlayerData.baseHealth / PlayerData.maxbaseHealth, lerpSpeed);
    }

    void ColorLerp()
    {
        Transform child = transform.GetChild(0);
        Image img = child.GetComponent<Image>();

        Color hpColor = Color.Lerp(Color.red, Color.green, (PlayerData.baseHealth / PlayerData.maxbaseHealth));

        img.color = hpColor;
    }

}
