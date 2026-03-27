using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHelth;

    [Header("score")]
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.maxValue = playerHelth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHelth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("0000000000");
    }
}
