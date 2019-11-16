using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_enemy : MonoBehaviour
{
    float speed = 2f;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position,Player.transform.position, Time.deltaTime*speed);
    }

        void OnTriggerEnter2D(Collider2D col)
        {
           // if(other.tag == "Player")
           Debug.Log($"Столкновение");
            Destroy(gameObject);
        }

}
