using BepInEx;
using Moonstorm.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShbonesVariants
{
    public class ShbonesVariantsConfig : ConfigLoader<ShbonesVariantsConfig>
    {
        public override BaseUnityPlugin MainClass => ShbonesVariantsMain.Instance;
        public override bool CreateSubFolder => true;

        internal void Init()
        {

        }
    }
}