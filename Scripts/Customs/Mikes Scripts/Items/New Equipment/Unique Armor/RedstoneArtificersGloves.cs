using System;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;

public class RedstoneArtificersGloves : StuddedGloves
{
    [Constructable]
    public RedstoneArtificersGloves()
    {
        Name = "Redstone Artificer's Gloves";
        Hue = Utility.Random(1, 1000);
        BaseArmorRating = Utility.RandomMinMax(20, 70);
        AbsorptionAttributes.CastingFocus = 15;
        Attributes.SpellChanneling = 1;
        Attributes.BonusMana = 10;
        SkillBonuses.SetValues(0, SkillName.Tinkering, 20.0);
        SkillBonuses.SetValues(1, SkillName.Meditation, 10.0);
        ColdBonus = 10;
        EnergyBonus = 15;
        FireBonus = 10;
        PhysicalBonus = 10;
        PoisonBonus = 10;
        XmlAttach.AttachTo(this, new XmlLevelItem());
    }

    public RedstoneArtificersGloves(Serial serial) : base(serial)
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
