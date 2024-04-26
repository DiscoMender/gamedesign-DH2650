using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RubyCounter : MonoBehaviour
{
    public static RubyCounter instance;

    [SerializeField] private TMP_Text rubyText;
    [SerializeField] private int currentRubies = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rubyText.text = "RUBIES: " + currentRubies.ToString() + " / 5";
    }

    public void IncreaseRubies(int v)
    {
        currentRubies += v;
        rubyText.text = "RUBIES: " + currentRubies.ToString() + " / 5";
    }
}
