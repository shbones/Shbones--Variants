using System;
using EntityStates.LemurianBruiserMonster;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace EntityStates.LemurianMonster.Adult
{
    public class AdultLemurianFireMegaFireball : BaseState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = FireMegaFireball.baseDuration / this.attackSpeedStat;
            this.fireDuration = FireMegaFireball.baseFireDuration / this.attackSpeedStat;
            base.PlayAnimation("Gesture, Additive", "FireMegaFireball", "FireMegaFireball.playbackRate", this.duration);
            Util.PlaySound(FireMegaFireball.attackString, base.gameObject);
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            string muzzleName = "MuzzleMouth";
            if (base.isAuthority)
            {
                int num = Mathf.FloorToInt(base.fixedAge / this.fireDuration * (float)projectileCount);
                var muzzleMouth = base.GetModelTransform().GetComponent<ChildLocator>().FindChild("MuzzleMouth");
                if (this.projectilesFired <= num && this.projectilesFired < projectileCount)
                {
                    if (FireMegaFireball.muzzleflashEffectPrefab)
                    {
                        EffectManager.SimpleMuzzleFlash(LemurianBruiserMonster.FireMegaFireball.muzzleflashEffectPrefab, base.gameObject, muzzleName, false);
                    }
                    Ray aimRay = base.GetAimRay();

                    float speedOverride = FireMegaFireball.projectileSpeed;
                    float bonusYaw = (float)Mathf.FloorToInt((float)this.projectilesFired - (float)(projectileCount - 1) / 2f) / (float)(FireMegaFireball.projectileCount - 1) * FireMegaFireball.totalYawSpread;
                    Vector3 forward = Util.ApplySpread(aimRay.direction, 0f, 0f, 1f, 1f, bonusYaw, 0f);
                    ProjectileManager.instance.FireProjectile(FireMegaFireball.projectilePrefab, muzzleMouth.position, Util.QuaternionSafeLookRotation(aimRay.direction), base.gameObject, this.damageStat * FireMegaFireball.damageCoefficient, FireMegaFireball.force, Util.CheckRoll(this.critStat, base.characterBody.master), DamageColorIndex.Default, null, speedOverride);
                    this.projectilesFired++;
                }
            }
            if (base.fixedAge >= this.duration && base.isAuthority)
            {
                this.outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

        public static GameObject projectilePrefab;

        public static GameObject muzzleflashEffectPrefab;

        public static int projectileCount = 3;

        public static float totalYawSpread = 5f;

        public static float baseDuration = 2f;

        public static float baseFireDuration = 0.2f;

        public static float damageCoefficient = 1.2f;

        public static float projectileSpeed;

        public static float force = 20f;

        public static string attackString;

        private float duration;

        private float fireDuration;

        private int projectilesFired;
    }
}
