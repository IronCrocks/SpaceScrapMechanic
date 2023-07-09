using TMPro;
using UnityEngine;

public class CrystalsCountText : MonoBehaviour
{
    private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = GameData.RelictCrystalsCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = GameData.RelictCrystalsCount.ToString();
    }
}
