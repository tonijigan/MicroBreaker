using CounterLogic;
using Enums;
using LocationLogic;
using SaveLogic;
using Shop;
using UnityEngine;

namespace Roots
{
    public class RootSceneGame : Root
    {
        [SerializeField] private LocationCreate _locationCreate;
        [SerializeField] private ChangeTemplate _changeTemplateBall;
        [SerializeField] private ChangeTemplate _changeTemplatePlatform;
        [SerializeField] private Counter _counter;

        private void Update() => _counter.UpdateTime();

        protected override void OnInit()
        {
            _locationCreate.Init(SaveService.LevelData);
            _changeTemplateBall.EnableCurrentTemplate(SaveService.GetCurrentProduct(ObjectsName.Ball),
                                                      SaveService.GetScale(ObjectsName.Ball));
            _changeTemplatePlatform.EnableCurrentTemplate(SaveService.GetCurrentProduct(ObjectsName.Platform),
                                                          SaveService.GetScale(ObjectsName.Platform));
            SaveService.SaveScale(false, ObjectsName.Ball);
            SaveService.SaveScale(false, ObjectsName.Platform);
        }
    }
}