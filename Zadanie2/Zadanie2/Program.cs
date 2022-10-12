using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
	class Program
	{
		class Pozicia
		{
			public int r; //riadok
			public int s; //stlpec

			public Pozicia()
			{
				r = 0; s = 0;
			}

			public Pozicia(int aR, int aS)
			{
				r = aR;
				s = aS;
			}

			public static bool jePoziciaVZozname(int r, int s, List<Pozicia> list)
			{
				for (int i = 0; i < list.Count; i++)
					if (list[i].r == r && list[i].s == s)
						return true;

				return false;
			}
		}

		class Budova
		{
			int rozmer; //rozmer strany stvorca
			int[,] planBudovy = null; //plan budovy

			Pozicia pozicia; //aktualna pozicia

			public Budova(int n, List<Pozicia> rozsvieteneMiestnosti)
			{
				//throw new NotImplementedException();
				rozmer = n;
				planBudovy = new int[rozmer, rozmer];

				for (int i = 0; i < rozmer; i++)
					for (int j = 0; j < rozmer; j++)
						planBudovy[i, j] = Pozicia.jePoziciaVZozname(i+1,j+1,rozsvieteneMiestnosti) ? 1 : 0; 
			}

			public void ZobrazBudovu()
			{
				//throw new NotImplementedException();
				for (int i = 0; i < rozmer; i++)
				{
					for (int j = 0; j < rozmer; j++)
						Console.Write((planBudovy[i,j] == 0 ? "X" : "O")+"\t");
					Console.WriteLine();
				}
			}

			public List<Pozicia> najdiPozicieNaDalsomRiadku(Pozicia aktPozicia)
			{
				throw new NotImplementedException();
			}
		}

		static void Main(string[] args)
		{
			int rozmer = 2;
			List<Pozicia> zoznamRozsvietenych = new List<Pozicia>();
			// Precitanie vstupu s osetrenim zleho zadania cez try-catch
			try
			{
				string[] vstup = Console.ReadLine().Split(' ');
				int.TryParse(vstup[0], out int n);
				int.TryParse(vstup[1], out int p);

				for (int i = 0; i < p; i++)
				{
					vstup = Console.ReadLine().Split(' ');
					Pozicia poz = new Pozicia();
					int.TryParse(vstup[0], out poz.r);
					int.TryParse(vstup[1], out poz.s);

					zoznamRozsvietenych.Add(poz);
				}

				rozmer = n;
			}
			catch (Exception e)
			{
				Console.WriteLine("Chyba pri vstupe [{0}]", e.Message);
			}

			Budova budova = new Budova(rozmer, zoznamRozsvietenych);
			budova.ZobrazBudovu();
			Console.ReadLine();
		}
	}
}
