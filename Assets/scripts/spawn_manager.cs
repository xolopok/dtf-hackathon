using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager : MonoBehaviour
{
    public int ran; //количество мобов в волне
    public  float period_spawn = 3f;//частота спавна в секундах
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
            var vec = new Vector3(Random.Range(-20,20),Random.Range(-10,10),0);
            var qec = new Quaternion(0,0,0,0);
            GameObject.Instantiate(enemy,vec,qec);               
       }

        }

   public float elaps = 5f;

    void AutoRun()
        {
            elaps-=Time.deltaTime;
        if(elaps<=0f)
            {
            ran = Random.Range(2, 6);  
             Spawn(ran);
            elaps=5f;
            }
        
        }

}
