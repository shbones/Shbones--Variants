using RoR2.CharacterAI;

using VAPI.Components;

namespace ShbonesVariants.Components
{
    public class ExtendAdultLemurianRange : VariantComponent
    {
        public void Awake()
        {
            var baseAI = gameObject.GetComponent<BaseAI>();
            var currentAISkillDrivers = baseAI.skillDrivers;
            foreach (AISkillDriver skillDriver in currentAISkillDrivers)
            {
                if (skillDriver.customName.Equals("StrafeAndShoot") || skillDriver.customName.Equals("StrafeIdley"))
                {
                    skillDriver.maxDistance *= 2f;
                }
            }
            Destroy(this);
        }
    }
}