using System;
using System.Collections.Generic;
using System.Text;

namespace Munchkin.Cards.Components
{
    public class EquipmentComponent : TreasureComponent
    {
        public required SlotType Slot { get; set; }
    }
}
