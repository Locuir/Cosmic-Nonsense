using UnityEngine;

public class PanalManger : MonoBehaviour
{


    public GameObject[] Panals;


    public void OpenPanal(int index)
    {
        for (int i = 0; i < Panals.Length; i++)
        {

            Panals[i].SetActive(i == index);

        }

    }

}
