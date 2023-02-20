using RoR2;
using VAPI.Components;

namespace ShbonesVariants.Components
{
    public class MoveAdultLemurianAimOrigin : VariantComponent
    {
        public void Awake()
        {
            var muzzleMouthTransform = gameObject.GetComponentInChildren<ChildLocator>().FindChild("MuzzleMouth");
            var aimOriginTransform = gameObject.GetComponent<CharacterBody>().aimOriginTransform;
            aimOriginTransform.SetParent(muzzleMouthTransform, false);
            Destroy(this);
        }
    }
}