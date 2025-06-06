using System;

namespace ParticleEditor
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyOrderAttribute : Attribute
	{

        // Instance Fields
        private int _order;

		// Constructors
		public PropertyOrderAttribute (int order)
		{
			_order = order;
		}
		
		
		// Properties
		public int Order
		{
			get
			{
				return _order;
			}
		}
	}
}
