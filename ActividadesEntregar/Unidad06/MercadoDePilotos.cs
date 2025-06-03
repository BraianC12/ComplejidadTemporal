using System;
using System.Collections.Generic;
namespace Unidad06
{
	/// <summary>
	/// Description of MercadoDePilotos.
	/// </summary>
	   public class MercadoDePilotos
	   {
	   	private List<string>mejor;
	   	
	   	public List<string> PilotoQuePasoPorMasEscuderias(Grafo<string> escuderias){
	   		mejor = new List<string>();
	
	        Vertice<string> origen = null;
	        
	        foreach (var v in escuderias.getVertices())
	        {
	            if (v.getDato() == "origen")
	            {
	                origen = v;
	                break;
	            }
	        }
	
	        if (origen == null)
	            return mejor;
	
	        // Por cada piloto desde origen
	        foreach (var a in origen.getAdyacentes())
	        {
	            List<string> nuevoCamino = new List<string> { origen.getDato() };
	            DFS(a.getDestino(), a.getPeso(), nuevoCamino);
	        }
	
	        return mejor;
	    }
	
	    private void DFS(Vertice<string> actual, int piloto, List<string> camino)
	    {
	        camino.Add(actual.getDato());
	
	        if (camino.Count > mejor.Count)
	        {
	            mejor = new List<string>(camino);
	        }
	
	        foreach (var a in actual.getAdyacentes())
	        {
	            if (a.getPeso() == piloto)
	            {
	                DFS(a.getDestino(), piloto, camino);
	            }
	        }
	
	        camino.RemoveAt(camino.Count - 1);
	    }
	   	
        }
    }

