using System;

namespace Unidad03 
{
	class Program
	{
		public static void Main(string[] args)
		{
			TablaHash tabla = new TablaHash(10);
	
			for (int i = 1; i <= 10; i++)
			{
				tabla.Insertar(i * 3); // Insertamos múltiplos de 3
			}

			Console.WriteLine("Después de insertar:");
			tabla.Mostrar();

			
			// Eliminar los 10 elementos
			for (int i = 1; i <= 10; i++)
			{
				tabla.Eliminar(i * 3);
			}

			Console.WriteLine("\nDespués de eliminar:");
			tabla.Mostrar();
			Console.ReadKey(true);
		}
	}
}