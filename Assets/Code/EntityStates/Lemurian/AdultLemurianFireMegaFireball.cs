using System;
using EntityStates.LemurianBruiserMonster;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace EntityStates.LemurianMonster.Adult
{
    public class AdultLemurianFireMegaFireball : BaseState
    {
        public static GameObject projectilePrefab = FireMegaFireball.projectilePrefab;

        public static GameObject muzzleflashEffectPrefab = FireMegaFireball.muzzleflashEffectPrefab;

        public static int projectileCount = 3;

        public static float totalYawSpread = 5f;

        public static float baseDuration = 2f;

        public static float baseFireDuration = 0.2f;

        public static float damageCoefficient = 1.2f;

        public static float projectileSpeed = FireMegaFireball.projectileSpeed;

        public static float force = 20f;

        public static string attackString;

        private float duration;

        private float fireDuration;

        private int projectilesFired;

        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = baseDuration / this.attackSpeedStat;
            this.fireDuration = baseFireDuration / this.attackSpeedStat;
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
            if (base.isAuthority)
            {
                int num = Mathf.FloorToInt(base.fixedAge / this.fireDuration * (float)projectileCount);
                if (this.projectilesFired <= num && this.projectilesFired < projectileCount)
                {
                    if (FireMegaFireball.muzzleflashEffectPrefab)
                    {
                        EffectManager.SimpleMuzzleFlash(muzzleflashEffectPrefab, base.gameObject, "MuzzleMouth", false);
                    }
                    Ray aimRay = base.GetAimRay();

                    float speedOverride = projectileSpeed;
                    float bonusYaw = (float)Mathf.FloorToInt((float)this.projectilesFired - (float)(projectileCount - 1) / 2f) / (float)(projectileCount - 1) * totalYawSpread;
                    Vector3 forward = Util.ApplySpread(aimRay.direction, 0f, 0f, 1f, 1f, bonusYaw, 0f);
                    ProjectileManager.instance.FireProjectile(projectilePrefab, aimRay.origin, Util.QuaternionSafeLookRotation(forward), base.gameObject, this.damageStat * damageCoefficient, force, Util.CheckRoll(this.critStat, base.characterBody.master), DamageColorIndex.Default, null, speedOverride);
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
    }
}
