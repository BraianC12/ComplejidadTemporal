
using System;
using System.Collections.Generic;
using tp1;
using tp2;

namespace tpfinal
{

	class Estrategia
	{

		public String Consulta1(ArbolBinario<DecisionData> arbol)
		{
			string resutl;
			if(arbol.esHoja()){
				resutl=arbol.getDatoRaiz().ToString();
			}
			
			else{
				resutl=Consulta1(arbol.getHijoIzquierdo());
				resutl=resutl+Consulta1(arbol.getHijoDerecho());
			}
			
			return resutl;
		}


		public String Consulta2(ArbolBinario<DecisionData> arbol)
		{

			return "Implementar";
		}


		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			string result = "Implementar";
			return result;
		}

		public ArbolBinario<DecisionData> CrearArbol(Clasificador clasificador)
		{
			ArbolBinario<DecisionData> arbolNuevo;
			if(clasificador.crearHoja()){
				arbolNuevo=new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerDatoHoja()));
			}
			else{
				arbolNuevo=new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerPregunta()));
				arbolNuevo.agregarHijoIzquierdo(CrearArbol(clasificador.obtenerClasificadorIzquierdo())); //rama izquierda
				arbolNuevo.agregarHijoDerecho(CrearArbol(clasificador.obtenerClasificadorDerecho())); //rama derecha
			}

			return arbolNuevo;
		}
	}
}