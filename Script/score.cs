using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    public TextMeshProUGUI Score;
    int kills;
    
    public void enemyDead()
    {
        kills++;
        Score.text = "kills :" + kills;
    }
}
