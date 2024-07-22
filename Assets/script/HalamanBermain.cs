using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanBermain : MonoBehaviour
{
    public void TombolKuis(){
        SceneManager.LoadScene("HalamanKuis");
    }

    public void TombolKataPengucapan(){
        SceneManager.LoadScene("HalamanKata");
    }

    public void TombolKembali(){
        SceneManager.LoadScene("HalamanHome");
    }

}
