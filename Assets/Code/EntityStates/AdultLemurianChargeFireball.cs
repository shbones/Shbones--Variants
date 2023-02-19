using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityStates.LemurianMonster.Adult
{
    public class AdultLemurianChargeFireball : ChargeFireball
    {

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.fixedAge >= this.duration && base.isAuthority)
            {
                AdultLemurianFireMegaFireball nextState = new AdultLemurianFireMegaFireball();
                this.outer.SetNextState(nextState);
                return;
            }
        }
    }
}
