using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveScript.LastLapMinutes = SaveScript.LastLapMinutes;
            SaveScript.LastLapSeconds = SaveScript.LastLapSeconds;
            SaveScript.LapNumber++;
            SaveScript.LapChange = true;
            if (SaveScript.LapNumber == 2)
            {
                SaveScript.BestLapTimeMinutes = SaveScript.LastLapMinutes;
                SaveScript.BestLapTimeSeconds = SaveScript.LastLapSeconds;
                SaveScript.NewRecord = true;
            }
            SaveScript.CheckPointPass1 = false;
            SaveScript.CheckPointPass2 = false;
            SaveScript.LastCheckPoint1 = SaveScript.ThisCheckPoint1;
            SaveScript.LastCheckPoint2 = SaveScript.ThisCheckPoint2;
        }
    }
}
