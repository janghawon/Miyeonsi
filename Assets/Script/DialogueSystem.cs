using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UIElements;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private float _textTurm;
    private UIDocument _uiDoc;
    private VisualElement _root;
    private VisualElement _panel;
    private Label _nameText;
    private Label _syntexText;

    private StringBuilder _syntexBuilder;
    private Coroutine _textCo;

    private bool isTexting;

    private void Awake()
    {
        _uiDoc = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _uiDoc.rootVisualElement;
        _panel = _root.Q<VisualElement>("text-panel");
        _nameText = _root.Q<Label>("name-text");
        _syntexText = _root.Q<Label>("syntex-text");
    }

    public void SetText(string name, string syntex)
    {
        if(isTexting)
        {
            StopCoroutine(_textCo);
            isTexting = false;
            return;
        }
        _nameText.text = name;
        _textCo = StartCoroutine(TextRendering(syntex));
    }

    IEnumerator TextRendering(string text)
    {
        isTexting = true;
        _syntexBuilder = new StringBuilder();
        _syntexText.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            _syntexBuilder.Append(text[i]);
            _syntexText.text = _syntexBuilder.ToString();
            yield return new WaitForSeconds(_textTurm);
        }
        isTexting = false;
    }
}
