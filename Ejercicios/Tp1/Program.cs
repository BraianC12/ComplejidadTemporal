using System;
using System.Collections.Generic;

namespace Tp1
{
	class Program
	{
		public static void Main(string[] args)
		{
			ArbolBinario<int> raiz = new ArbolBinario<int>(10);
	        ArbolBinario<int> nodo5 = new ArbolBinario<int>(5);
	        ArbolBinario<int> nodo15 = new ArbolBinario<int>(15);
	        ArbolBinario<int> nodo3 = new ArbolBinario<int>(3);
	        ArbolBinario<int> nodo7 = new ArbolBinario<int>(7);
	        ArbolBinario<int> nodo12 = new ArbolBinario<int>(12);
	
	        raiz.agregarHijoIzquierdo(nodo5);
	        raiz.agregarHijoDerecho(nodo15);
	        nodo5.agregarHijoIzquierdo(nodo3);
	        nodo5.agregarHijoDerecho(nodo7);
	        nodo15.agregarHijoIzquierdo(nodo12);
	
	        Console.WriteLine("Recorrido inorden: ");
	        raiz.inorden();
			
	        Console.WriteLine("\nRecorrido preorden: ");
	        raiz.preorden();
	        
	        Console.WriteLine("\nRecorrido postorden: ");
	        raiz.postorden();
	        
	        Console.WriteLine("\nContar hojas: ");
	        Console.Write(raiz.contarHojas());
	        
	        Console.WriteLine("\nRecorrido por niveles: ");
	        raiz.recorridoPorNiveles();
	        
			Console.ReadKey(true);
		}
		
		public class ArbolBinario<T>{
		
	
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;
	
		
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo=hijo;
		}
	
		public void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho=hijo;
		}
	
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo=null;
		}
	
		public void eliminarHijoDerecho() {
			this.hijoDerecho=null;
		}
	
		public bool esHoja() {
			return this.hijoIzquierdo==null && this.hijoDerecho==null;
		}
		
		/*Actividad*/
		public void inorden() {
			if(hijoIzquierdo !=null){
				hijoIzquierdo.inorden();
			}
			
			Console.WriteLine(this.dato);
			
			if(hijoDerecho !=null){
				hijoDerecho.inorden();
			}
			
		}
		
		public void preorden() {
			Console.WriteLine(dato);
			if(hijoIzquierdo !=null){
				hijoIzquierdo.preorden();
			}
			if(hijoDerecho !=null){
				hijoDerecho.preorden();
			}
		}
		
		public void postorden() {
			if(hijoIzquierdo !=null){
				hijoIzquierdo.postorden();
			}
			
			if(hijoDerecho !=null){
				hijoDerecho.postorden();
			}
			
			Console.WriteLine(dato);
			
		}
		
			
		public int contarHojas() {
			if(hijoIzquierdo == null && hijoDerecho == null){
				return 1;
			}
			
			int hojasIzquierdas=0;
			int hojasDerechas=0;
			
			if(hijoIzquierdo != null){
				hojasIzquierdas=hijoIzquierdo.contarHojas();
			}
			
			if(hijoDerecho != null){
				hojasDerechas=hijoDerecho.contarHojas();
			}
			
			return hojasIzquierdas + hojasDerechas;
		}
		
		
		public void recorridoPorNiveles() {
			List<ArbolBinario<T>> lista = new List<ArbolBinario<T>>(); // Lista para simular la cola
		
			lista.Add(this); // Agregamos la raíz

    		int index = 0; // Índice manual para simular el desencolado
    		
    		while (index < lista.Count) // Mientras haya elementos en la "cola"
    		{
    			ArbolBinario<T> nodo = lista[index]; // Tomamos el nodo actual   		
		        Console.WriteLine(nodo.dato); // Imprimimos el dato
		        index++; // Avanzamos el índice
		
		        // Si tiene hijos, los agregamos a la lista
		        if (nodo.hijoIzquierdo != null)
		        {
		            lista.Add(nodo.hijoIzquierdo);
		        }
		        
		        if (nodo.hijoDerecho != null)
		        {
		            lista.Add(nodo.hijoDerecho);
		        }
    		}
    	}
			

		
		public void recorridoEntreNiveles(int n,int m) {
			
			
			
		}
		}
	}
}