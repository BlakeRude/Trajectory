using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay  : MonoBehaviour
{
    public Text HP_displayed;

    void Update(){
        HP_displayed.text = "HP: " + Player.Health; // Display Health value from Noah's Player.cs
    }
}
