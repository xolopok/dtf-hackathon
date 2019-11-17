using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager : MonoBehaviour
{
    public int ran; //количество мобов в волне
    public GameObject enemy; 

    void Start()
    {        
       Spawn(0);
    }

    void Update()
    {
        AutoRun();
    }

    void Spawn(int ran)
        {

     for (int i=1;i<=ran;i++)
       {
            float posx = Random.Range(-61, 61);
            float posy = Random.Range(-39, 39);
            
            var vec = new Vector3(posx, posy, 0);
            var qec = new Quaternion(0,0,0,0);


            GameObject.Instantiate(enemy,vec,qec);               
       }
    }

    float elaps = 5f;
    public float timer = 3f;//частота спавна в секундах

    void AutoRun()
        {
            elaps-=Time.deltaTime;
        if(elaps<= timer)
            {
            ran = Random.Range(2, 6);  
             Spawn(ran);
            elaps=5f;
            }
        
        }

}
