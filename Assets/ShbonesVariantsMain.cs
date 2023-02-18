/*
Generated from a ROR2EK Template. Feel free to remove this comment section.
0 = modName; 1 = Nicified mod name; 2 = authorName; 3 = using clauses; 4 = attributes; 
*/

using BepInEx;
using UnityEngine;
using Moonstorm;
using System.Security.Permissions;
using System.Security;
using R2API.Utils;

[assembly: HG.Reflection.SearchableAttribute.OptIn]

#pragma warning disable CS0618
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618
[module: UnverifiableCode]

namespace ShbonesVariants
{
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInDependency(VAPI.VAPIMain.GUID)]
    [BepInPlugin(GUID, MODNAME, VERSION)]
	public class ShbonesVariantsMain : BaseUnityPlugin
	{
		public const string GUID = "com.Shbones.ShbonesVariants";
		public const string MODNAME = "Shbones Variants";
		public const string VERSION = "0.0.1";

        public static ShbonesVariantsMain Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
            new Log(Logger);
            new ShbonesVariantsConfig().Init();
            new ShbonesVariantsAssets().Init();
            new ShbonesVariantsLang().Init();
            new ShbonesVariantsContent().Init();

            ConfigurableFieldManager.AddMod(this);
            Log.Info("Loaded ShbonesVariants");
        }
    }
}