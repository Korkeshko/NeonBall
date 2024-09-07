using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StarCollection : MonoBehaviour
{
    [SerializeField] private Star[] stars;
    [SerializeField] private TMP_Text starCounter;
    private int score = 0;
    public UnityEvent OnBlokMovement;

    public float CurrentScore => score;

    private void Start()
    {
        foreach (var star in stars)
        {
            star.OnStarCollected.AddListener(IncreaseScore);
        }
    }

    private void IncreaseScore()
    {
        score++;
        starCounter.text = score.ToString();    
    }

    public void DecreaseScore()
    {
        score--;
        starCounter.text = score.ToString();
        CheckScore();
    }

    private void CheckScore()
    {
        if (score < 0)
        {
            Debug.Log("ПОТРАЧЕНО");
            OnBlokMovement.Invoke();
        }
    }
}
