using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; } // Variavel responsavel por tornar este script acessivel de qualquer outro script do projeto

    private int score; // Variavel responsavel por armazenar a pontuacao do jogador

    [SerializeField]
    private TMPro.TextMeshProUGUI textScore; // Variavel responsavel pelo texto da pontuacao do jogador na HUD

    [SerializeField]
    private GameObject _gameOverScren; // Variável responsável pelo menu de Game Over

    private int rank1;

    private int rank2;

    private int rank3;



    private void Awake()
    {
        if (instance != null && instance != this) // Implementando o padrao singleton
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        score = 0;
        UpdateScore(score);

        rank1 = PlayerPrefs.GetInt("rank1");
        rank2 = PlayerPrefs.GetInt("rank2");
        rank3 = PlayerPrefs.GetInt("rank3");
    }

    public void UpdateScore(int point) // Funcao responsavel por atualizar a pontuacao no HUD
    {
        score += point;
        textScore.text = score.ToString();
        Rank();

    }

    public void GameOver() 
    { 
        _gameOverScren.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() 
    {
        SceneManager.LoadScene("Meteor scape"); // Reiniciando a cena
        Time.timeScale = 1;
    }

    private void Rank() 
    {
        if(score > rank1) 
        {
            rank1 = score;
            PlayerPrefs.SetInt("rank1", rank1);
        }
        else if(score > rank2) 
        {
            rank2 = score;
            PlayerPrefs.SetInt("rank2", rank2);
        }
        else if(score > rank3)
        {
            rank3 = score;
            PlayerPrefs.SetInt("rank3", rank3);
        }
    }


}
