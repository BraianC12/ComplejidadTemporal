
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
			if(arbol.esHoja()){
				return "Prediccion: " + arbol.getDatoRaiz() + "\n";
			}
			else{
				string caminoIzquierdo=arbol.getDatoRaiz().ToString() + " -> Si ->" + Consulta2(arbol.getHijoIzquierdo());
				string caminoDerecho=arbol.getDatoRaiz().ToString() + " -> no ->" + Consulta2(arbol.getHijoDerecho());
				return caminoIzquierdo + caminoDerecho;
			}

			
		}


		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			Queue<ArbolBinario<DecisionData>> cola=new Queue<ArbolBinario<DecisionData>>();
			
			int nivel=0;
			
			cola.Enqueue(arbol);
			string result = "";
			
			while(cola.Count !=0){
				int tamañoNivel=cola.Count;
				result=result + "Nivel " + nivel + ":\n";
				
				for(int i=0; i<tamañoNivel; i++){
					ArbolBinario<DecisionData> nodoActual=cola.Dequeue();
					result=result + nodoActual.getDatoRaiz() + "\n";
					
					if(nodoActual.getHijoIzquierdo() !=null){
						cola.Enqueue(nodoActual.getHijoIzquierdo());
					}
					if(nodoActual.getHijoDerecho() !=null){
						cola.Enqueue(nodoActual.getHijoDerecho());
					}
				}
				
				nivel++;				
			}
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