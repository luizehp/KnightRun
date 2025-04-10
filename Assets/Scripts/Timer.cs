using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;
    float elapsedTime;
    // Update is called once per frame
    bool set = false;
    void Update()
    {
        if (!GameConstroller.GameOver || set == false)
        {
            timerText.text = CountTime();
            set = true;
        }

    }

    public string CountTime()
    {
        GameData.elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(GameData.elapsedTime / 60);
        int seconds = Mathf.FloorToInt(GameData.elapsedTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
