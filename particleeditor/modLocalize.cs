using Microsoft.VisualBasic.CompilerServices;
using System.Globalization;
using System.Threading;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modLocalize
	{
		// Methods
		public static void ForceRegionalSettings ()
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
		}
		
	}
}
