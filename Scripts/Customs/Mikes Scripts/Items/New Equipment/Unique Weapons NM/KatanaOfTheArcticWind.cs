using System;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;

public class KatanaOfTheArcticWind : Katana
{
    [Constructable]
    public KatanaOfTheArcticWind()
    {
        Name = "Katana of the Arctic Wind";
        Hue = Utility.Random(1, 3000);
        MinDamage = Utility.RandomMinMax(50, 90);
        MaxDamage = Utility.RandomMinMax(100, 250);
        Attributes.BonusStr = 10;
        Attributes.AttackChance = 25;
        Attributes.WeaponSpeed = 20;
        Slayer = SlayerName.WaterDissipation;
        WeaponAttributes.HitColdArea = 50;
        WeaponAttributes.ResistColdBonus = 20;
        SkillBonuses.SetValues(0, SkillName.Swords, 20.0);
        SkillBonuses.SetValues(1, SkillName.Tactics, 20.0);
        XmlAttach.AttachTo(this, new XmlLevelItem());
    }

    public KatanaOfTheArcticWind(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}
