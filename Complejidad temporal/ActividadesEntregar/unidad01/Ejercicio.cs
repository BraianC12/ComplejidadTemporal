using System;

namespace unidad01
{
	public class Ejercicio
	{		
		public ArbolBinario<int> Nuevo(ArbolBinario<int> arbol)
        {
			if(arbol ==null){
				return null;
			}
			
			ArbolBinario<int> arbolNuevo = new ArbolBinario<int>(arbol.valor);

		    if (arbol.izquierdo != null)
		    {
		        arbolNuevo.izquierdo = new ArbolBinario<int>(arbol.izquierdo.valor + arbol.valor);
				arbolNuevo.izquierdo.izquierdo = new ArbolBinario<int>(arbol.izquierdo.izquierdo.valor + arbol.izquierdo.valor);		        
		        arbolNuevo.izquierdo.derecho = Nuevo(arbol.izquierdo.derecho);
		    }
		    
		    arbolNuevo.derecho = Nuevo(arbol.derecho);
		
		    return arbolNuevo;
        }
	}
}