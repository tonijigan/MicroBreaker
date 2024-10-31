using Enums;
using System.Linq;
using UnityEngine;

public class ChangeTemplate : MonoBehaviour
{
    private const int MinValue = 0;
    private const int MaxValue = 1;

    [SerializeField] private ObjectModification _objectModification;

    private Transform _transform;
    private Template[] _templates;

    private void Awake()
    {
        _transform = transform;
        Fill();
    }

    public void EnableCurrentTemplate(string name, int value)
    {
        bool isCanScale = true ? value == MaxValue : value == MinValue;

        Template currentTemplate = _templates.Where(template => template.Name == name).FirstOrDefault();

        if (name == string.Empty)
            currentTemplate = _templates[0];

        currentTemplate.gameObject.SetActive(true);

        if (isCanScale == false) return;

        _objectModification.SetNewScale(BoosterNames.Positive);
    }

    private void Fill()
    {
        _templates = new Template[_transform.childCount];

        for (int i = 0; i < _templates.Length; i++)
        {
            _transform.GetChild(i).TryGetComponent(out Template template);
            _templates[i] = template;
            _templates[i].gameObject.SetActive(false);
        }
    }
}