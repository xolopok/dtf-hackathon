using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attacks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private Vector3  MousePos;
    // Update is called once per frame
    void Update()
    {
        //здесь получаем координаты мыши которые будут являться входными параметрами для функций атаки

        if (Input.GetKeyDown(KeyCode.Alpha1)) attack1();
        if (Input.GetKeyDown(KeyCode.Alpha2)) attack2();
        if (Input.GetKeyDown(KeyCode.Alpha3)) attack3();
        if (Input.GetKeyDown(KeyCode.Alpha4)) attack4();
        if (Input.GetKeyDown(KeyCode.Alpha5)) attack5();
        if (Input.GetKeyDown(KeyCode.Alpha6)) attack6();
        if (Input.GetKeyDown(KeyCode.Alpha7)) attack7();
        if (Input.GetKeyDown(KeyCode.Alpha8)) attack8();


    }
    int[] array2 = new int[] { 1, 3, 5, 7, 9 };
    public Button[] but = new Button[9];



    //в одну выбранную сторону (куда смотрит мышка)
  public  void attack1()
        {
       
        for(int i=1;i<=2;i++)
            but[i].GetComponent<Image>().color = Color.white;

        but[1].GetComponent<Image>().color = Color.red;




    }

    //в две стороны - вверх_И_вниз или влево_И_вправо
    public void attack2()
        {
        for (int i = 1; i <= 2; i++)
            but[i].GetComponent<Image>().color = Color.white;

        but[2].GetComponent<Image>().color = Color.red;
    }

    //ввер в выбранную сторону
    public void attack3()
        {
        for (int i = 3; i <= 5; i++)
            but[i].GetComponent<Image>().color = Color.white; 

        but[3].GetComponent<Image>().color = Color.red;
    }

    //расходящийся круг 
    public void attack4()
        {
        for (int i = 3; i <= 5; i++)
            but[i].GetComponent<Image>().color = Color.white;

        but[4].GetComponent<Image>().color = Color.red;
    }


    public void attack5()
    {
        for (int i = 3; i <= 5; i++)
            but[i].GetComponent<Image>().color = Color.white;

        but[5].GetComponent<Image>().color = Color.red;
    }

    public void attack6()
    {
        for (int i = 6; i <= 8; i++)
            but[i].GetComponent<Image>().color = Color.white;

        but[6].GetComponent<Image>().color = Color.red;
    }

    public void attack7()
    {
        for (int i = 6; i <= 8; i++)
            but[i].GetComponent<Image>().color = Color.white;

        but[7].GetComponent<Image>().color = Color.red;
    }
    public void attack8()
    {
        for (int i = 6; i <= 8; i++)
            but[i].GetComponent<Image>().color = Color.white;

        but[8].GetComponent<Image>().color = Color.red;
    }
}
