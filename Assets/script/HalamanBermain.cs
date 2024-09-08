using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanBermain : MonoBehaviour
{
    public void TombolKuis(){
        SceneManager.LoadScene("HalamanKuis");
    }

    public void TombolLengkapiKata(){
        SceneManager.LoadScene("HalamanLengkapiKata");
    }

    public void TombolKembali(){
        SceneManager.LoadScene("HalamanHome");
    }

    public void TombolKembaliBermain(){
        Skor.instance.ResetSkor();
        SceneManager.LoadScene("HalamanBermain");
    }

}
