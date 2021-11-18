using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    public TextMeshProUGUI waveDisplay;

    public void DisplayWave(int curWave)
    {
        waveDisplay.text = curWave.ToString() + " Wave";
    }

    private void OnEnable()
    {
        waveDisplay = GetComponentInChildren<TextMeshProUGUI>();

        WaveManager.OnWaveChanged += DisplayWave;
    }

    private void OnDisable()
    {
        WaveManager.OnWaveChanged -= DisplayWave;
    }
}
