using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed; // Variavel responsavel pela velocidade

    [SerializeField]
    private Rigidbody2D _rig; // Variavel responsavel por controlar as propriedades do componente Rigidbody2D

    [SerializeField]
    private GameObject _rocket;

    // Variavel responsavel por controlar as propriedades do componente animator

    void Update()
    {
            _rig.velocity = new Vector3(Input.acceleration.x * _speed, 0, 0); // Movendo o player no eixo x baseado no acelerometro

            if (Input.acceleration.x < 0)
            {
                _rocket.transform.Rotate(0, 1, 0);
            }
            else if (Input.acceleration.x > 0)
            {
                _rocket.transform.Rotate(0, -1, 0);

            }
        

    }

   

}
