using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private PlayerScript playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        score = playerScript.score;
        tmp.text = Convert.ToString(score);
    }
}
