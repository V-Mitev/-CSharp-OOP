using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		private int age;

		public virtual int Age
		{
			get { return age;}

			set
			{
				if (value > 0)
				{
					age = value;
				} 
			}
		}

		public string Name { get; set; }

		public override string ToString()
        {
			StringBuilder sb = new StringBuilder();

			sb.Append($"Name: {Name}, Age: {Age}");

			return sb.ToString().Trim();
        }
    }
}