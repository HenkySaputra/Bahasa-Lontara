using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanHome : MonoBehaviour
{
    public void TombolExit(){
        Application.Quit();
        Debug.Log("Game Close");
    }

    public void TombolHome(){
        SceneManager.LoadScene("HalamanHome");
    }

    public void TombolBermain(){
        SceneManager.LoadScene("HalamanBermain");
    }

    public void TombolBelajar(){
        SceneManager.LoadScene("HalamanBelajar");
    }

    public void TombolSejarah(){
        SceneManager.LoadScene("HalamanSejarah");
    }

    public void TombolSejarah2(){
        SceneManager.LoadScene("HalamanSejarah2");
    }

    public void TombolTentang(){
        SceneManager.LoadScene("HalamanTentang");
    }

    public void TombolSkor(){
        SceneManager.LoadScene("HalamanSkor");
    }

     public void TombolDaftarHuruf(){
        SceneManager.LoadScene("HalamanDaftarHuruf");
    }

     public void TombolTandaBaca(){
        SceneManager.LoadScene("HalamanTandaBaca");
    }

    public void TombolKataPengucapan(){
        SceneManager.LoadScene("HalamanKatadanPengucapan");
    }

    public void TombolKembali(){
        SceneManager.LoadScene("HalamanHome");
    }

    public void TombolKembaliSejarah(){
        SceneManager.LoadScene("HalamanSejarah");
    }

    public void TombolKembaliBelajar(){
        SceneManager.LoadScene("HalamanBelajar");
    }

    public void TombolKembaliDaftarHuruf(){
        SceneManager.LoadScene("HalamanDaftarHuruf");
    }

}
