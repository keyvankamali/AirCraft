using System;
using System.ComponentModel.DataAnnotations;

namespace Aircraft.Models
{
	public class AirCraft {

		[Key]

		public string ModelName { get; set; }
		public int SerialNumber { get; set; }
		public int RegistrationNumber { get; set; }
		public string RegistrationStatus { get; set; }
		public DateTime RegistrationDate { get; set; }

    }
}

