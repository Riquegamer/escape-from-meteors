using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; } // Variável responsável por tornar este script acessível de qualquer outro script do projeto

    private int score; // Variável responsável por armazenar a pontuação do jogador

    [SerializeField]
    private TMPro.TextMeshProUGUI _textScore; // Variável responsável pelo texto da pontuação do jogador na HUD

    [SerializeField]
    private GameObject _gameOverScren; // Variável responsável pelo menu de Game Over

    [SerializeField]
    private GameObject _RankScren;

    [SerializeField]
    private GameObject _recordScren;

    private int rank1;
    [SerializeField]
    private TMPro.TextMeshProUGUI _rankText1;


    private int rank2;
    [SerializeField]
    private TMPro.TextMeshProUGUI _rankText2;

    private int rank3;
    [SerializeField]
    private TMPro.TextMeshProUGUI _rankText3;

    private string _nameRank1;
    private string _nameRank2;
    private string _nameRank3;

    [SerializeField]
    private TMPro.TMP_InputField _inputName;

    private int _position;



    private void Awake()
    {
        if (instance != null && instance != this) // Implementando o padrão singleton
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        //PlayerPrefs.DeleteAll();

    }



    private void Start()
    {
        score = 0;
        UpdateScore(score);
    }

    public void UpdateScore(int point) // Função responsável por atualizar a pontuação no HUD
    {
        score += point;
        _textScore.text = score.ToString();

    }

    public void GameOver() 
    { 
        _gameOverScren.SetActive(true);
        Time.timeScale = 0;
        Rank();
    }

    public void Restart() 
    {
        SceneManager.LoadScene("Meteor scape"); // Reiniciando a cena
        Time.timeScale = 1;
    }

    public void Rank() 
    {
        // Obtendo as Player prefs
        rank1 = PlayerPrefs.GetInt("rank1");
        rank2 = PlayerPrefs.GetInt("rank2");
        rank3 = PlayerPrefs.GetInt("rank3");
        _nameRank1 = PlayerPrefs.GetString("nameRank1");
        _nameRank2 = PlayerPrefs.GetString("nameRank2");
        _nameRank3 = PlayerPrefs.GetString("nameRank3");

        // Atualizando o Texto do Ranque
        UpdateRankText();

        // Atualizando os valores do Ranque
        if (score > rank1) 
        {
            _position = 1;
            _recordScren.SetActive(true);
        }
        else if(score > rank2)
        {
            _position = 2;
            _recordScren.SetActive(true);
        }
        else if(score > rank3)
        {
            _position = 3;
            _recordScren.SetActive(true);
        }

    }

    private void UpdateRankText() 
    {
        // Atualizando as Player Prefs
        PlayerPrefs.SetInt("rank1", rank1);
        PlayerPrefs.SetInt("rank2", rank2);
        PlayerPrefs.SetInt("rank3", rank3);
        PlayerPrefs.SetString("nameRank1", _nameRank1);
        PlayerPrefs.SetString("nameRank2", _nameRank2 );
        PlayerPrefs.SetString("nameRank3", _nameRank3);

        // Atualizando o texto do ranking
        _rankText1.text = _nameRank1 + ": " + rank1.ToString();
        _rankText2.text = _nameRank2 + ": " + rank2.ToString();
        _rankText3.text = _nameRank3 + ": " + rank3.ToString();
    }

    public void NewRecord()
    {
        // Atualizando os nomes do ranque
       if(_position == 1) 
        {
             rank3 = rank2;
             rank2 = rank1;
             rank1 = score;
            _nameRank1 = _inputName.text;
            UpdateRankText() ;
            _RankScren.SetActive(true);
            _recordScren.SetActive(false);

        }else if(_position == 2) 
        {
            rank3 = rank2;
            rank2 = score;
            _nameRank2 = _inputName.text;
            UpdateRankText() ;
            _RankScren.SetActive(true);
            _recordScren.SetActive(false);
        }else if(_position == 3) 
        {
            rank3 = score;
            _nameRank3 = _inputName.text;
            UpdateRankText() ;
            _RankScren.SetActive(true);
            _recordScren.SetActive(false);
        }
        
    }


}
