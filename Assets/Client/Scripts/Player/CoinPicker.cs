using UnityEngine;
using UnityEngine.Events;

public class CoinPicker : MonoBehaviour
{
    private int _count;
    public event UnityAction<int> ScoreChange;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out Point point)) {
            _count += point.Score;
            ScoreChange?.Invoke(_count);
            Destroy(point.gameObject);
        }
    }
}