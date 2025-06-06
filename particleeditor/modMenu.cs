using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Windows.Forms;

namespace ParticleEditor
{
	[StandardModule]
	internal sealed class modMenu
	{
		// Methods
		public static void DisableMenuItem (string sItem, bool bEnable)
		{
			modMenu.DisableMenuItem(modMain.fMain._menuContext.MenuItems, sItem, bEnable);
			modMenu.DisableMenuItem(modMain.fMain._menuMain.MenuItems, sItem, bEnable);
		}
		
		public static void DisableMenuItem (Menu.MenuItemCollection mMenu, string sItem, bool bEnable)
		{
			IEnumerator enumerator1;
			try
			{
				enumerator1 = mMenu.GetEnumerator();
				while (enumerator1.MoveNext())
				{
					MenuItem item1 = (MenuItem) enumerator1.Current;
					if (StringType.StrCmp(item1.Text, sItem, false) == 0)
					{
						item1.Enabled = bEnable;
					}
					if (item1.MenuItems.Count > 0)
					{
						modMenu.DisableMenuItem(item1.MenuItems, sItem, bEnable);
					}
				}
			}
			finally
			{
				
			}
		}
		
	}
}
