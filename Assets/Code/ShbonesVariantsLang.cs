using Moonstorm.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShbonesVariants
{
    public class ShbonesVariantsLang : LanguageLoader<ShbonesVariantsLang>
    {
        public override string AssemblyDir => ShbonesVariantsAssets.Instance.AssemblyDir;

        public override string LanguagesFolderName => "ShbonesVariantsLanguage";

        internal void Init()
        {
            LoadLanguages();
        }
    }
}