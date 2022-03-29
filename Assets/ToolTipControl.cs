using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipControl : MonoBehaviour
{
    RectTransform rect;
    [SerializeField] TMPro.TextMeshProUGUI tipText;
    [SerializeField] Image panel;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        rect.position = Input.mousePosition + new Vector3(0, 20);
    }

    public void Display(string text)
    {
        tipText.enabled = true;
        panel.enabled = true;

        tipText.text = text;
    }

    public void Hide()
    {
        tipText.enabled = false;
        panel.enabled = false;
    }
}
