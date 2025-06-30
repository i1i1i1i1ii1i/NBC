using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject rain;
    public static GameManager Instance;
    public Text totalScoreTxt;
    public Text timeText;
    public GameObject Endpanel;

    int totalScore = 0;
    float totalTime = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0.0f;
            Endpanel.SetActive(true);
            totalTime = 0.0f;
        }
        timeText.text = totalTime.ToString("N2");
    }

    void MakeRain()
    {
        Debug.Log("비를 내려라!");
        Instantiate(rain);
    }

   

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
    }

    public void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }
}
