#region

using System.Globalization;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

#endregion

namespace ModelView
{
    [StandardModule]
    internal sealed class modLocalize
    {
        // Methods
        public static void ForceRegionalSettings()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
        }
    }
}