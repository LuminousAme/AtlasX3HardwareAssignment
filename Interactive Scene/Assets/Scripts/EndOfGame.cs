using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfGame : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "You Got A Score Of " + PersistantScore.score + "\nWould You Like To Play Again?";
    }
}
