﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
	public static class Extension
	{
		public static string GetDescription<T>(this T source)
		{
			FieldInfo fi = source.GetType().GetField(source.ToString());

			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0) return attributes[0].Description;
			else return source.ToString();
		}
	}
}
