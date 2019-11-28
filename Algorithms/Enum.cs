using System;
using System.ComponentModel;

namespace Algorithms.Extensions
{

    /// <summary>
    /// Eu achei esse código na internet, ainda preciso verificar se é realmente o que quero.
    /// </summary>
    public static class EnumExtensions
	{
		public static string Description(this Enum val)
		{
			DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : string.Empty;
		}
	}
}
