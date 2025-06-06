using System;

namespace ParticleEditor
{
	public class PropertyOrderPair : IComparable
	{
        // Instance Fields
        private int _order;
        private string _name;

		// Constructors
		public PropertyOrderPair (string name, int order)
		{
			_order = order;
			_name = name;
		}
		
		
		// Methods
		public int CompareTo (object obj)
		{
			int num2 = ((PropertyOrderPair) obj)._order;
			if (num2 == _order)
			{
				string strB = ((PropertyOrderPair) obj)._name;
				return string.Compare(_name, strB);
			}
			if (num2 > _order)
			{
				return -1;
			}
			return 1;
		}
		
		
		// Properties
		public string Name
		{
			get
			{
				return _name;
			}
		}
	}
}
