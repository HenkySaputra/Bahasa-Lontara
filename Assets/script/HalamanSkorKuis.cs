using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HalamanSkorKuis : MonoBehaviour
{
    public Text totalSkor;
    public void Start(){
        // Debug.Log("game finish");
        totalSkor.text = Skor.instance.totalSkor.ToString();
    }
}
