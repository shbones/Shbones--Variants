# Shbones' Variants
Adds new monster variants to the game using Nebby's VarianceAPI.

## Variants

    Blind Pest Broodmother (2% Chance)
        - Tier: Legendary
        - Unique
        - Postfix: Broodmother
        - 500% Size
        - 2500% Health
        - +20 Armor
        - Cannot Spit. Spit is replaced with Spawn Brood
        - Spawn Brood
           - Over 3 Seconds, spawn 3 Blind Broodlings
           - Cooldown 4 seconds (beginning at end of 3 second cast time)
           - Broodlings inherit items (including elite modifier)
    Blind Broodling (0% Chance to spawn natively, exclusively spawns from Broodmother's "Spawn Brood" ability)
        - Tier: Minion (Custom Tier with 0 Reward Drops)
        - Name Replacement: Blind Broodling
        - 40% Size
        - 75% HP
        - 150% Speed
        - 100% Damage
    Adult Lemurian (6% Chance)
        - Tier: Uncommon
        - Name Prefix: Adult
        - 200% Size
        - 250% HP
        - 2x Range to start Fireball attack
        - Fireball Attack Replaced with 3 Elder Lemurian Fireballs fired in small spread pattern


These are my first monsters/variants, so the ability and stat tuning is likely off and will most likely change as I get feedback. Please ping me in the Modding Discord if you have any feedback at shbones#0085

## Known Issues
* When a Lemurian rolls both Flamethrower (from TheOriginal30) and Adult, it will begin using Flamethrower from 70 distance but flamethrower has a range of 40. Will address this soon. This is currently very unlikely due to these variants having a low chance of spawning together.
* None (other than potentially balance)

## Potential Future Work
* New Variants!
* Refining existing variants balance
* Open to Suggestions!

## Suggestions/Comments/Problems/CompatibilityIssues/AnythingElse
If you have anything to say, feel free to ping me in the Risk of Rain 2 Modding discord (shbones#0085)

## Credits
- Nebby for VarianceAPI, TO30 and Nebby's Wrath, MoonstormSharedUtils, and lots of help working through issues
- Twiner for Thunderkit
- Tony for the icon
- HeyImnoop for the Thunderkit tutorial video
- Rob for the original MonsterVariants
- Everyone in the Modding Discord
