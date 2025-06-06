using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ParticleEditor
{
	public class PropSorter : ExpandableObjectConverter
	{
		// Constructors
		public PropSorter ()
		{
		}
		
		
		// Methods
		public override bool GetPropertiesSupported (ITypeDescriptorContext context)
		{
			return true;
		}
		
		public override PropertyDescriptorCollection GetProperties (ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptorCollection collection2 = TypeDescriptor.GetProperties(RuntimeHelpers.GetObjectValue(value), attributes);
			ArrayList list1 = new ArrayList();
			foreach (PropertyDescriptor descriptor1 in collection2)
			{
				Attribute attribute1 = descriptor1.Attributes[typeof(PropertyOrderAttribute)];
				if (attribute1 != null)
				{
					PropertyOrderAttribute attribute2 = (PropertyOrderAttribute) attribute1;
					list1.Add(new PropertyOrderPair(descriptor1.Name, attribute2.Order));
					continue;
				}
				list1.Add(new PropertyOrderPair(descriptor1.Name, 0));
			}
			list1.Sort();
			ArrayList list2 = new ArrayList();
			foreach (PropertyOrderPair pair1 in list1)
			{
				list2.Add(pair1.Name);
			}
			return collection2.Sort((string[]) list2.ToArray(typeof(string)));
		}
		
	}
}
