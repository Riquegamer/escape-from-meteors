using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public MeteorSkin [] skin;

    [SerializeField]
    private SpriteRenderer _sprite;

    [SerializeField]
    private float _speed;

    private void Start()
    {
        ChangeSkin();
    }
    private void Update()
    {
        transform.position += Vector3.down * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Point"))
        {
            GameController.instance.UpdateScore(1);
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void ChangeSkin() 
    {
        MeteorSkin newSkin = skin[(Random.Range(0, skin.Length))];

        _sprite.sprite = newSkin.sprite;
    }
}
