using System;
using System.Collections.Generic;
namespace Unidad06
{
	class Program
	{
		public static void Main(string[] args)
		{
			Grafo<string> grafo=new Grafo<string>();
			
			Vertice<string> origen=new Vertice<string>("origen");
			Vertice<string> escuderia1=new Vertice<string>("Ferrari");
			Vertice<string> escuderia2=new Vertice<string>("McLaren");
			Vertice<string> escuderia3=new Vertice<string>("Mercedes");
			
			
			grafo.agregarVertice(origen);
			grafo.agregarVertice(escuderia1);
			grafo.agregarVertice(escuderia2);
			grafo.agregarVertice(escuderia3);
			
			origen.getAdyacentes().Add(new Arista<string>(escuderia1, 1));
			escuderia1.getAdyacentes().Add(new Arista<string>(escuderia2, 1));
			escuderia2.getAdyacentes().Add(new Arista<string>(escuderia3, 1));
			escuderia3.getAdyacentes().Add(new Arista<string>(origen, 2));
			
			MercadoDePilotos mercado=new MercadoDePilotos();
			List<string> caminoMasLargo=mercado.PilotoQuePasoPorMasEscuderias(grafo);
  
            foreach (var e in caminoMasLargo){
                Console.WriteLine(e);
            }
            
			Console.ReadKey(true);
		}
	}
}