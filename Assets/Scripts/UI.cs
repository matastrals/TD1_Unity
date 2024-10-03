using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject endWin;
    public GameObject endLose;
    void Start()
    {
        endWin.SetActive(false);
        endLose.SetActive(false);
    }

    public void ActiveEndWin()
    {
        endWin.SetActive(true);
    }

    public void DesactiveEndWin()
    {
        endWin.SetActive(false);
    }

    public void ActiveEndLose()
    {
        endLose.SetActive(true);
    }

    public void DesactiveEndLose()
    {
        endLose.SetActive(false);
    }

}
