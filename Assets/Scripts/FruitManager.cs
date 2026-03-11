using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuitManager : MonoBehaviour
{
    public int FruitCount;
    public Text FruitText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FruitText.text="Score: "+FruitCount.ToString();
        // creste scorul cand jucatorul culege marul
    }
}
