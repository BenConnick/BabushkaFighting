using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public Image fill;
    private float percent = 1;
    public float Percent {
        get
        {
            return percent;
        }
        set
        {
            percent = value;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        fill.fillAmount = percent;
    }
}
