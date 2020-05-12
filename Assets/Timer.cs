using UnityEngine;

public class Timer : MonoBehaviour
{
  [Header("Parametre")]
  [SerializeField] float time;
  [SerializeField] float timeActual;
  public bool isStart = false;
  public bool isPlaying = false;
  [SerializeField] string format = "#0:00.000";
  public int count = 1;

  [Header("Temps formatée")]
  public string formattedTime;
  public string formattedTimeActual;

  static public Timer instance;

  private void Awake()
  {
    if (instance == null)
    {
      DontDestroyOnLoad(gameObject);
      instance = this;
    } else
    {
      Destroy(this);
    }
    StartTimer();
  }


  void Update()
  {
    if (isStart)
    {
      if (isPlaying)
      {
        time += Time.deltaTime;
        timeActual += Time.deltaTime;

        formattedTime = FloatToTime(time, format);
        formattedTimeActual = FloatToTime(timeActual, format);
      }
    }
  }





  [ContextMenu("▶ Start")]
  public void StartTimer()
  {
    isStart = true;
    isPlaying = true;
  }

  [ContextMenu("█ █ Pause")]
  public void PauseTimer()
  {
    isPlaying = false;
  }

  [ContextMenu("█ ► Unpause")]
  public void UnpauseTimer()
  {
    isPlaying = true;
  }

  [ContextMenu("↩ Restart")]
  public void RestartTimer()
  {
    timeActual = 0;

    formattedTimeActual = FloatToTime(0f, format);

    count++;

  }


  public string FloatToTime(float toConvert, string format)
  {
    switch (format)
    {
      case "00.0":
        return string.Format("{0:00}:{1:0}",
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 10) % 10));//miliseconds

      case "#0.0":
        return string.Format("{0:#0}:{1:0}",
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 10) % 10));//miliseconds

      case "00.00":
        return string.Format("{0:00}:{1:00}",
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 100) % 100));//miliseconds

      case "00.000":
        return string.Format("{0:00}:{1:000}",
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

      case "#00.000":
        return string.Format("{0:#00}:{1:000}",
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

      case "#0:00":
        return string.Format("{0:#0}:{1:00}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60);//seconds

      case "#00:00":
        return string.Format("{0:#00}:{1:00}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60);//seconds

      case "0:00.0":
        return string.Format("{0:0}:{1:00}.{2:0}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 10) % 10));//miliseconds

      case "#0:00.0":
        return string.Format("{0:#0}:{1:00}.{2:0}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 10) % 10));//miliseconds

      case "0:00.00":
        return string.Format("{0:0}:{1:00}.{2:00}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 100) % 100));//miliseconds

      case "#0:00.00":
        return string.Format("{0:#0}:{1:00}.{2:00}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 100) % 100));//miliseconds

      case "0:00.000":
        return string.Format("{0:0}:{1:00}.{2:000}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

      case "#0:00.000":
        return string.Format("{0:#0}:{1:00}.{2:000}",
            Mathf.Floor(toConvert / 60),//minutes
            Mathf.Floor(toConvert) % 60,//seconds
            Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

    }
    return "error";
  }

#if UNITY_EDITOR
  private void OnGUI()
  {
    GUI.Label(new Rect(10, 10, 100, 20), formattedTime);
  }
#endif
}
