using Moonstorm.Loaders;
using R2API.ScriptableObjects;
using VAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityStates;

namespace ShbonesVariants
{
    public class ShbonesVariantsContent : ContentLoader<ShbonesVariantsContent>
    {
        public override string identifier => ShbonesVariantsMain.GUID;
        public override R2APISerializableContentPack SerializableContentPack { get; protected set; } = ShbonesVariantsAssets.LoadAsset<R2APISerializableContentPack>("ShbonesVariantsContentPack");
        public override Action[] LoadDispatchers { get; protected set; }
        private VariantPackDef variantPack;

        public override void Init()
        {
            base.Init();
            LoadDispatchers = new Action[]
            {
                () =>
                {
                    Log.Info("Adding Variants");
                    variantPack = ShbonesVariantsAssets.LoadAsset<VariantPackDef>("ShbonesVariantPack");
                    variantPack.variants = ShbonesVariantsAssets.LoadAllAssetsOfType<VariantDef>();
                    VariantPackCatalog.AddVariantPack(variantPack, ShbonesVariantsMain.Instance.Config);
                },
                () =>
                {
                    Log.Info("Adding EntityStates");
                    SerializableContentPack.entityStateTypes = GetType().Assembly
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(EntityState)) && !t.IsAbstract)
                    .Select(t => new SerializableEntityStateType(t))
                    .ToArray();
                },
                () =>
                {
                    Log.Info("Adding SkillDefs");
                    SerializableContentPack.skillDefs = ShbonesVariantsAssets.LoadAllAssetsOfType<RoR2.Skills.SkillDef>();
                }
            };
        }
    }
}