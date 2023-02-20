using EntityStates;
using RoR2;
using UnityEngine;
using EntityStates.BeetleQueenMonster;
using ShbonesVariants;
using System;
using UnityEngine.UIElements;
using VAPI;
using System.ComponentModel;

namespace EntityStates.FlyingVermin.Broodmother
{
    public class BroodlingSummon : BaseState
    {

        public static SpawnCard blindPestSpawnCard = Resources.Load<SpawnCard>("SpawnCards/CharacterSpawnCards/cscFlyingVermin");
        public static VariantDef broodling = ShbonesVariantsAssets.LoadAsset<VariantDef>("BroodlingPest");
        public static VariantDef[] variantBroodlings = { broodling };

        public bool isSummoning = false;
        public int summonsPerActivation = 3;
        public float baseDuration = 3f;
        private float duration;
        private int summonsForThisUsage = 0;
        private float summonInterval;
        private int activationNumber = 0;

        public override void OnEnter()
        {
            Log.Info("Start Summoning Pests " + ++activationNumber);
            base.OnEnter();
            this.summonsForThisUsage = 0;
            this.duration = this.baseDuration / base.attackSpeedStat;
            this.summonInterval = this.duration / this.summonsPerActivation;
            isSummoning = true;
        }

        public override void OnExit()
        {
            Log.Info("Exiting Summon " + activationNumber);
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.fixedAge >= this.duration && base.isAuthority)
            {
                this.outer.SetNextStateToMain();
                return;
            }
            if (base.fixedAge > summonInterval * summonsForThisUsage)
            {
                ++summonsForThisUsage;
                Util.PlaySound(ChargeSpit.attackSoundString, base.gameObject);
                base.AddRecoil(-5f, 5f, -5f, 5f);
                summonMob();
            }
        }
        public void summonMob() {
            var mySummon = new VariantSummon
            {
                masterPrefab = blindPestSpawnCard.prefab,
                position = base.transform.position + Vector3.down * 3,
                rotation = base.transform.rotation,
                summonerBodyObject = base.gameObject,
                ignoreTeamMemberLimit = true,
                variantDefs = variantBroodlings,
                supressRewards = true,
                teamIndexOverride = base.teamComponent.teamIndex,
                inventoryToCopy = base.characterBody.inventory,
            }
            .Perform();
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Death;
        }
    }
}
