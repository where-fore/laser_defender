using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI myTextComponent = null;
    private DamageReceiver playerDamageReceiverScript = null;
    void Start()
    {
        playerDamageReceiverScript = FindObjectOfType<PlayerBehaviour>().GetComponent<DamageReceiver>();
        myTextComponent = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        string newHealthText = playerDamageReceiverScript.GetHealth().ToString();

        myTextComponent.text = newHealthText;
    }
}
