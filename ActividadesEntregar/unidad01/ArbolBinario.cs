using System;

namespace unidad01
{
    public class ArbolBinario<T>
    {
        public T valor { get; set; }
        public ArbolBinario<T> izquierdo { get; set; }
        public ArbolBinario<T> derecho { get; set; }

        public ArbolBinario(T valor)
        {
            this.valor = valor;
            this.izquierdo = null;
            this.derecho = null;
        }
    }
}