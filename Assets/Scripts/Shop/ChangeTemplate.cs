using System.Linq;
using UnityEngine;

public class ChangeTemplate : MonoBehaviour
{
    private Transform _transform;
    private Template[] _templates;

    private void Awake()
    {
        _transform = transform;
        Fill();
    }

    public void EnambeCurrentTemplate(string name)
    {
        Template currentTemplate = _templates.Where(template => template.Name == name).FirstOrDefault();
        currentTemplate.gameObject.SetActive(true);

        if (name == "")
            _templates[0].gameObject.SetActive(true);
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