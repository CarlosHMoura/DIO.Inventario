using DIO.Inventario.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Inventario.Classes
{
    public class Inventario : EntidadeBase
    {
       
        public Tipo Tipo { get; set; }
        public string Modelo { get; set; }
        public string nSerie { get; set; }
        public string nPatrimonio { get; set; }
        public bool Excluido { get; set; }

        public Inventario(int id, Tipo tipo, string modelo, string nserie, string npatrimonio)
        {
            Id = id;
            Modelo = modelo;
            Tipo = tipo;
            nSerie = nserie;
            nPatrimonio = npatrimonio;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "ID: " + this.Id + Environment.NewLine;
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Número de Série: " + this.nSerie + Environment.NewLine;
            retorno += "Número Patrimonio: " + this.nPatrimonio + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornanSerie()
        {
            return this.nSerie;
        }

        public string retornaModelo()
        {
            return this.Modelo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }



    }
}
