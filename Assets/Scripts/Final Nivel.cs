using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalNivel : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        FrontBed(other.gameObject);
    }

    private void FrontBed(GameObject target)
    {
        MainCharacter player = target.GetComponent<MainCharacter>();
        if (Input.GetKey(KeyCode.F))
        {
            PasarNivel();
        }
    }


    public void PasarNivel()
    {
        SceneManager.LoadScene(0);
    }
}