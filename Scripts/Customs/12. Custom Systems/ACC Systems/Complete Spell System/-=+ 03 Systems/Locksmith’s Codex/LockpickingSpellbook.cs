using System;
using Server.Items;
using Server.Spells;

namespace Server.ACC.CSS.Systems.LockpickingMagic
{
	public class LockpickingSpellbook : CSpellbook
	{
		public override School School{ get{ return School.LocksmithsCodex; } }

		[Constructable]
		public LockpickingSpellbook() : this( (ulong)0, CSSettings.FullSpellbooks )
		{
		}

		[Constructable]
		public LockpickingSpellbook( bool full ) : this( (ulong)0, full )
		{
		}

		[Constructable]
		public LockpickingSpellbook( ulong content, bool full ) : base( content, 0xEFA, full )
		{
			Hue = 2000;
			Name = "Locksmiths Codex";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.AccessLevel == AccessLevel.Player )
			{
				//Container pack = from.Backpack;
				//if( !(Parent == from || (pack != null && Parent == pack)) )
				//{
					//from.SendMessage( "The spellbook must be in your backpack [and not in a container within] to open." );
					//return;
				//}
				//else
				if( SpellRestrictions.UseRestrictions && !SpellRestrictions.CheckRestrictions( from, this.School ) )
				{
					return;
				}
			}

			from.CloseGump( typeof( LockpickingSpellbookGump ) );
			from.SendGump( new LockpickingSpellbookGump( this ) );
		}

		public LockpickingSpellbook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}