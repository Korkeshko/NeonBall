using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarCollection : MonoBehaviour
{
    [SerializeField] private Star[] stars;
    [SerializeField] private TMP_Text starCounter;
    public int score = 0;

    private void Start()
    {
        foreach (var star in stars)
        {
            star.OnStarCollected.AddListener(StarCollected);
        }
    }

    private void StarCollected()
    {
        score++;
        starCounter.text = score.ToString();    
    }
}
