using System;
using System.Collections.Generic;

namespace Unidad03
{
	/// <summary>
	/// Description of TablaHash.
	/// </summary>
	public class TablaHash
	{
		private List<int>[] tabla;
        private int tamaño;

        public TablaHash(int tamaño)
        {
            this.tamaño = tamaño;
            
            tabla = new List<int>[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                tabla[i] = new List<int>();
            }
        }

        public void Insertar(int clave)
        {
            int indice = clave % tamaño;
            
            if (indice < 0){
            	indice=indice+tamaño;
            } 
            
            if (!tabla[indice].Contains(clave)){
                tabla[indice].Add(clave);
            }
        }

        public void Eliminar(int clave)
        {
            
            int indice = clave % tamaño;  
            if (indice < 0){
            	indice=indice+tamaño;
            } 
            
            tabla[indice].Remove(clave);
        }

        public void Mostrar()
        {
            for (int i = 0; i < tamaño; i++)
            {
                Console.Write(i + " ");
                foreach (var clave in tabla[i])
                {
                    Console.Write(clave + " ");
                }
                Console.WriteLine();
	        }	
		}
	}
}
