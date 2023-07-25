using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; } // Variavel responsavel por tornar este script acessivel de qualquer outro script do projeto

    private int score; // Variavel responsavel por armazenar a pontuacao do jogador

    [SerializeField]
    private TMPro.TextMeshProUGUI textScore; // Variavel responsavel pelo texto da pontuacao do jogador na HUD


    private void Awake()
    {
        if (instance != null && instance != this) // Implementando o padrao singleton
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        UpdateScore(score);
    }

    public void UpdateScore(int point) // Funcao responsavel por atualizar a pontuacao no HUD
    {
        score += point;
        textScore.text = score.ToString();

    }

}
