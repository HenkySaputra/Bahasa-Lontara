using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kuis : MonoBehaviour
{

    // Konstanta untuk LCM
    private const int a = 1664525;
    private const int c = 1013904223;
    private const int m = int.MaxValue;
    private int seed;
    public Button button;
    public Image questionImage;
    private string[] imageNames = { "Kuis/ho", "Kuis/i", "Kuis/nge" };
    private int currentIndex = 0;

    void Start()
    {
        seed = System.DateTime.Now.Millisecond;

        ShuffleImages();
        SetImage();
        button.onClick.AddListener(ChangeImage);
    }

    void SetImage()
    {
        string randomImageName = imageNames[currentIndex];
        Sprite newSprite = Resources.Load<Sprite>(randomImageName);

        if (newSprite != null)
        {
            questionImage.sprite = newSprite;
        }
        else
        {
            Debug.Log("Failed to load image: " + randomImageName);
        }

         currentIndex++;
    }

    int LCM()
    {
        seed = (a * seed + c) % m;
        return seed;
    }

    void ShuffleImages()
    {
        for (int i = 0; i < imageNames.Length; i++)
        {
            int randomIndex = Mathf.Abs(LCM()) % imageNames.Length;
            // Swap images[i] dengan images[randomIndex]
            string temp = imageNames[i];
            imageNames[i] = imageNames[randomIndex];
            imageNames[randomIndex] = temp;
        }
    }

    void ChangeImage()
    {
        if (currentIndex < imageNames.Length)
        {
            SetImage();
        }

        string filePath = Path.Combine(Application.dataPath, "Data/kuis.json");

        GeneratorSoal generator = new GeneratorSoal(filePath);
        SoalBenarSalah[] randomizedQuestions = generator.GetSoalAcak();

        foreach (var question in randomizedQuestions)
        {
            Debug.Log($"pertanyaan: {question.pertanyaan}");
        }
    }
}
