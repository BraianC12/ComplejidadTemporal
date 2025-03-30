using System;

namespace unidad01
{
	class Program
	{
		public static void Main(string[] args)
		{
 			// Crear árbol original
            ArbolBinario<int> raiz = new ArbolBinario<int>(1);
            raiz.izquierdo = new ArbolBinario<int>(2);
            raiz.derecho = new ArbolBinario<int>(3);
            raiz.izquierdo.izquierdo = new ArbolBinario<int>(4);
            raiz.derecho.izquierdo = new ArbolBinario<int>(5);
            raiz.derecho.derecho = new ArbolBinario<int>(6);
            raiz.derecho.izquierdo.izquierdo = new ArbolBinario<int>(7);

            Ejercicio ejercicio = new Ejercicio();
            ArbolBinario<int> arbolNuevo = ejercicio.Nuevo(raiz);

            Console.Write("Árbol Original: ");
            ImprimirValores(raiz);

            Console.Write("\nÁrbol Resultante: ");
            ImprimirValores(arbolNuevo);

            Console.ReadKey(true);
        }

        public static void ImprimirValores(ArbolBinario<int> arbol)
        {
            if (arbol == null) return;

            Console.Write(arbol.valor + " ");
            ImprimirValores(arbol.izquierdo);
            ImprimirValores(arbol.derecho);
        }
    }

}
