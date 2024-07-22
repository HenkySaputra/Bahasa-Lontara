using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HalamanSkorKuis : MonoBehaviour
{ 
    public Text totalSkor;
    public Button buttonhome;
    public Button buttonmain;

    public void Start(){
        // Debug.Log("game finish");
        totalSkor.text = Skor.instance.totalSkor.ToString();
        buttonhome.onClick.AddListener(TombolKembaliHome);
        buttonmain.onClick.AddListener(TombolKembaliMain);

    }

     public void TombolKembaliHome(){
        SceneManager.LoadScene("HalamanHome");
    }

    public void TombolKembaliMain(){
        SceneManager.LoadScene("HalamanKuis");
    }
}
