using TMPro;
using UnityEngine;

public class CrystalsManager : MonoBehaviour
{
    public TMP_Text RelictCrystalsText;
    public CanvasGroup FadedRelictCrystalsCountText;

    private int _relictCrystalsCount;

    // Start is called before the first frame update
    void Start()
    {
        LoadRelictCrystals();
    }

    public void AddOne()
    {
        AddRelictCrystals(1);
    }

    public void AddTen()
    {
        AddRelictCrystals(10);
    }

    public void Subtract(int value)
    {
        _relictCrystalsCount -= value;

        ChangeRelictCrystalsCount();
        LoadRelictCrystals();
    }

    private void LoadRelictCrystals()
    {
        _relictCrystalsCount = Progress.Instance.PlayerInfo.RelictCrystalsCount;
        RelictCrystalsText.text = _relictCrystalsCount.ToString();
    }

    private void AddRelictCrystals(int count)
    {
        _relictCrystalsCount += count;

        RelictCrystalsText.text = _relictCrystalsCount.ToString();

        SetFading(count);
        ChangeRelictCrystalsCount();
    }

    private void SetFading(int count)
    {
        var fadedText = FadedRelictCrystalsCountText.GetComponentInParent<TMP_Text>();
        fadedText.text = "+" + count;
        FadedRelictCrystalsCountText.alpha = 1;

        InvokeRepeating(nameof(Fade), 0, 0.05f);
    }

    private void Fade()
    {
        FadedRelictCrystalsCountText.alpha -= 0.05f;

        if (FadedRelictCrystalsCountText.alpha <= 0)
        {
            CancelInvoke(nameof(Fade));
        }
    }
    
    private void ChangeRelictCrystalsCount()
    {
        Progress.Instance.PlayerInfo.RelictCrystalsCount = _relictCrystalsCount;
    }
}
