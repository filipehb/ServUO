// **********
// ServUO - AgeUtils.cs
// **********

using System;
using System.Collections.Generic;
using Server.Custom.Race;
using Server.Mobiles;

namespace Server.Custom.System.Age
{
	public class AgeUtils
	{
		public static double AgeInDays(DateTime creationDate)
		{
			return (DateTime.UtcNow - creationDate).TotalDays;
		}

		public static double AgeInMonths(DateTime dataCriacao)
		{
			return Math.Truncate((AgeInDays(dataCriacao) % 365) / 30);
		}

		public static string GenerateDeath()
		{
			var random = new Random();
			var resultList = new List<string>
			{
				"Voce teve um infarto e morreu", "Voce teve um aneurisma e morreu",
				"Voce teve uma unha encravada infeccionada e morreu", "Voce faleceu de causas naturais"
			};
			int index = random.Next(resultList.Count);
			return resultList[index];
		}

		public static bool IsLifeLimit(PlayerMobile playerMobile)
		{
			switch (playerMobile.RaceCustom)
			{
				case RacesCustom.Anao:
					{
						//Criança 01-14
						//Jovem 15-29
						//Adulto 30-174
						//Velho 175-219
						//Idoso +220
						return AgeInMonths(playerMobile.CreationTime) >= 100;
					}
					break;
				case RacesCustom.Hobbit:
					{
						//Criança 01-09
						//Jovem 10-32
						//Adulto 33-79
						//Velho 80-90
						//Idoso +91
						return AgeInMonths(playerMobile.CreationTime) >= 100;
					}
					break;
				case RacesCustom.Humano:
					{
						//Criança 01-09
						//Jovem 10-15
						//Adulto 16-44
						//Velho 45-59
						//Idoso +55
						switch (AgeInMonths(playerMobile.CreationTime))
						{
							
						}
						return AgeInMonths(playerMobile.CreationTime) >= 100;
					}
					break;
				case RacesCustom.Elfo:
					{
						//Imortais para mortes naturais, talvez pensar em algo sobre isso
						return false;
					}
					break;
				// case RacesCustom.Orc:
				// 	{
				// 		return AgeInMonths(playerMobile.CreationTime) >= 100;
				// 	}
				// 	break;
				default:
					return false;
					break;
			}
		}
	}
}