using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text liveText;


    void Update()
    {
        liveText.text = "Lives : " + PlayerStats.Lives;
    }
}
