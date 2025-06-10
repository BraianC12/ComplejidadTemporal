
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
			Cola<ArbolBinario<DecisionData>> cola=new Cola<ArbolBinario<DecisionData>>();
			int nivel=0;
			cola.encolar(arbol);
			
			string result = "";
			
			while(!cola.esVacia()){
				int tamañoNivel=cola.cantidadElementos();
				result=result + "Nivel " + nivel + ":\n";
				
				for(int i=0; i<tamañoNivel; i++){
					ArbolBinario<DecisionData> nodoActual=cola.desencolar();
					result=result + nodoActual.getDatoRaiz() + "\n";
					
					if(nodoActual.getHijoIzquierdo() !=null){
						cola.encolar(nodoActual.getHijoIzquierdo());
					}
					if(nodoActual.getHijoDerecho() !=null){
						cola.encolar(nodoActual.getHijoDerecho());
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