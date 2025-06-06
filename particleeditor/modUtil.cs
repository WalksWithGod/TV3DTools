using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modUtil
	{
		// Methods
		public static float ToNumeric (string sData)
		{
			if (Information.IsNumeric(sData))
			{
				return SingleType.FromString(sData);
			}
			return 0.00F;
		}
		
		public static bool IsPowerOf2 (int iData)
		{
			if ((iData != 1) && ((iData & (0 - iData)) == iData))
			{
				return true;
			}
			return false;
		}
		
		public static void SetBit (ref int iKey, object lBit)
		{
			if (BooleanType.FromObject(ObjectType.BitAndObj( ~iKey, lBit)))
			{
				iKey = IntegerType.FromObject(ObjectType.BitOrObj( iKey, lBit));
			}
		}
		
	}
}
