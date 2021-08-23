using DIO.Inventario.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Inventario.Classes
{
    public class InventarioRepositorio : IRepositorio<Inventario>
    {
        private List<Inventario> listaInventario = new List<Inventario>();
        public void Atualiza(int id, Inventario obj)
        {
            listaInventario[id] = obj;
        }

        public void Exclui(int id)
        {
            listaInventario[id].Excluir();
        }

        public void Insere(Inventario obj)
        {
            listaInventario.Add(obj);
        }

        public List<Inventario> Lista()
        {
            return listaInventario;
        }

        public int ProximoId()
        {
            return listaInventario.Count;
        }

        public Inventario RetornaPorId(int id)
        {
            return listaInventario[id];
        }
    }
}
