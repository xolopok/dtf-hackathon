using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move_enemy : MonoBehaviour
{
  public  float speed = 8f;
    public GameObject Player;
    public GameObject managerpoints;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        managerpoints = GameObject.Find("ManagerPoints");

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < Player.transform.position.x) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        if (gameObject.transform.position.x > Player.transform.position.x) gameObject.GetComponent<SpriteRenderer>().flipX = false;

        transform.position = Vector3.MoveTowards(gameObject.transform.position,Player.transform.position, Time.deltaTime*speed);
    }

    manager_menu manager_Menu = new manager_menu();
     
        void OnTriggerEnter2D(Collider2D col)
        {

            if (col.tag == "Player")
            {
            Debug.Log("Конец игры");
            managerpoints.GetComponent<managerpoints>().AddPoints(1);
            if (PlayerPrefs.GetInt("Record") < managerpoints.GetComponent<managerpoints>().points)
                PlayerPrefs.SetInt("Record", managerpoints.GetComponent<managerpoints>().points);
            PlayerPrefs.Save();
            manager_Menu.TextRecord.text = "Highest record - " + PlayerPrefs.GetInt("Record").ToString();

            Destroy(col);

             
        }

        if (col.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }


    

}
