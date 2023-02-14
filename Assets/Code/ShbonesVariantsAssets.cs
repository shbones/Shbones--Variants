
using IL.RoR2;
using Moonstorm.Loaders;
using System.IO;
using UnityEngine;

namespace ShbonesVariants
{
    public class ShbonesVariantsAssets : AssetsLoader<ShbonesVariantsAssets>
    {
        public string AssemblyDir => System.IO.Path.GetDirectoryName(ShbonesVariantsMain.Instance.Info.Location);
        public override AssetBundle MainAssetBundle => _assetBundle;
        private AssetBundle _assetBundle;

        internal void Init()
        {
            var bundlePath = System.IO.Path.Combine(AssemblyDir, "assetbundles", "shbonesvariantsassets");
            _assetBundle = AssetBundle.LoadFromFile(bundlePath);

            FinalizeMaterialsWithAddressableMaterialShader(_assetBundle);
        }
    }
} 