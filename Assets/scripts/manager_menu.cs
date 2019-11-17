using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class manager_menu : MonoBehaviour
{
    public GameObject bMenu,skillboxpanel, managerpoints;
    public Text TextRecord;
    // Start is called before the first frame update

    void Start()
    {
        bMenu.SetActive(true);
        skillboxpanel.SetActive(false);
        managerpoints = GameObject.Find("ManagerPoints");


        TextRecord.text = "Highest record - " + PlayerPrefs.GetInt("Record").ToString();

        Debug.Log(managerpoints.GetComponent<managerpoints>().points);
    }

    public void BStart()
    {
        bMenu.SetActive(false);
        skillboxpanel.SetActive(true);
    }

    public void BExit()
    {
        Application.Quit();
    }

  
}
