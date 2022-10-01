using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour {
    [SerializeField] private CoinPicker _coinPicker;
    [SerializeField] private Text _text;

    private void OnEnable() {
        _coinPicker.ScoreChange += OnChangeScore;
    }
    private void OnDisable() {
        _coinPicker.ScoreChange -= OnChangeScore;
    }

    private void OnChangeScore(int value) {
        _text.text = $"Score: {value}";
    }
}