using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreUI : MonoBehaviour
{
    private TMP_Text starScore;

    private void Start()
    {
        starScore = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        // receive the current star count and show it as a string in UI.
        starScore.text = staticCoinNumber.instance.getScore().ToString(); 
    }
}
