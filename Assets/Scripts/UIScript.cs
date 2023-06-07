using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
   public Image SpeedRing;
   public Text SpeedText;
   public Text GearText;
   public Text LapNumberText;
   public Text TotalLapsText;
   public Text LapTimeMinutesText;
   public Text LapTimeSecondsText;
   public Text RaceTimeMinutesText;
   public Text RaceTimeSecondsText;
   public Text BestLapTimeMinutesText;
   public Text BestLapTimeSecondsText;
   public Text CheckPointTime;
   public GameObject CheckPointDisplay;
   private float DisplaySpeed;
   public int TotalLaps = 3;

   private void Start()
   {
      SpeedRing.fillAmount = 0;
      SpeedText.text = "0";
      GearText.text = "1";
      LapNumberText.text = "0";
      TotalLapsText.text = "/" + TotalLaps.ToString();
      CheckPointDisplay.SetActive(false);
   }

   private void Update()
   {
      #region Speedometer
      
      DisplaySpeed = SaveScript.Speed / SaveScript.TopSpeed;
      SpeedRing.fillAmount = DisplaySpeed;

      SpeedText.text = (Mathf.Round(SaveScript.Speed).ToString());
      GearText.text = (SaveScript.Gear + 1).ToString();
      
      #endregion

      #region LapNumber
      LapNumberText.text = SaveScript.LapNumber.ToString();
      #endregion

      #region LapTime
      if (SaveScript.LapTimeMinutes <= 9)
      {
         LapTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
      }
      else if (SaveScript.LapTimeMinutes >= 10)
      {
         LapTimeMinutesText.text = (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
      }
      
      if (SaveScript.LapTimeSeconds <= 9)
      {
         LapTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
      }
      else if (SaveScript.LapTimeSeconds >= 10)
      {
         LapTimeSecondsText.text = (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
      }
      #endregion

      #region RaceTime
      if (SaveScript.RaceTimeMinutes <= 9)
      {
         RaceTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
      }
      else if (SaveScript.LapTimeMinutes >= 10)
      {
         RaceTimeMinutesText.text = (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
      }
      
      if (SaveScript.RaceTimeSeconds <= 9)
      {
         RaceTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
      }
      else if (SaveScript.RaceTimeSeconds >= 10)
      {
         RaceTimeSecondsText.text = (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
      }
      #endregion

      #region Working out best Lap Time

      if (SaveScript.LastLapMinutes == SaveScript.BestLapTimeMinutes)
      {
         if (SaveScript.LastLapSeconds < SaveScript.BestLapTimeSeconds)
         {
            SaveScript.BestLapTimeSeconds = SaveScript.LastLapSeconds;
         }
      }
      
      if (SaveScript.LastLapMinutes < SaveScript.BestLapTimeMinutes)
      {
         SaveScript.BestLapTimeMinutes = SaveScript.LastLapMinutes;
         SaveScript.BestLapTimeSeconds = SaveScript.LastLapSeconds;
      }

      #endregion

      #region Display Best Lap Time

      if (SaveScript.BestLapTimeMinutes <= 9)
      {
         BestLapTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.BestLapTimeMinutes).ToString()) + ":";
      }
      else if (SaveScript.LapTimeMinutes >= 10)
      {
         BestLapTimeMinutesText.text = (Mathf.Round(SaveScript.BestLapTimeMinutes).ToString()) + ":";
      }
      
      if (SaveScript.BestLapTimeSeconds <= 9)
      {
         BestLapTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.BestLapTimeSeconds).ToString());
      }
      else if (SaveScript.BestLapTimeSeconds >= 10)
      {
         BestLapTimeSecondsText.text = (Mathf.Round(SaveScript.BestLapTimeSeconds).ToString());
      }

      #endregion

      #region CheckPoint working out for CheckPoint 1

      if (SaveScript.CheckPointPass1 == true)
      {
         SaveScript.CheckPointPass1 = false;
         CheckPointDisplay.SetActive(true);

         if (SaveScript.ThisCheckPoint1 > SaveScript.LastCheckPoint1)
         {
            CheckPointTime.color = Color.red;
            CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint1 - SaveScript.LastCheckPoint1).ToString();
            StartCoroutine(CheckPointOff());
         }
         
         if (SaveScript.ThisCheckPoint1 < SaveScript.LastCheckPoint1)
         {
            CheckPointTime.color = Color.green;
            CheckPointTime.text = "+" + (SaveScript.LastCheckPoint1 - SaveScript.ThisCheckPoint1).ToString();
            StartCoroutine(CheckPointOff());
         }
      }

      #endregion
      
      #region CheckPoint working out for CheckPoint 2

      if (SaveScript.CheckPointPass2 == true)
      {
         SaveScript.CheckPointPass2 = false;
         CheckPointDisplay.SetActive(true);

         if (SaveScript.ThisCheckPoint2 > SaveScript.LastCheckPoint2)
         {
            CheckPointTime.color = Color.red;
            CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint2 - SaveScript.LastCheckPoint2).ToString();
            StartCoroutine(CheckPointOff());
         }
         
         if (SaveScript.ThisCheckPoint2 < SaveScript.LastCheckPoint2)
         {
            CheckPointTime.color = Color.green;
            CheckPointTime.text = "+" + (SaveScript.LastCheckPoint2 - SaveScript.ThisCheckPoint2).ToString();
            StartCoroutine(CheckPointOff());
         }
      }

      #endregion
   }

   IEnumerator CheckPointOff()
   {
      yield return new WaitForSeconds(2);
      CheckPointDisplay.SetActive(false);
   }
}
