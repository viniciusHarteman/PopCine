using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCine
{
    public class Serie: EntidadeBase
    {
        //** ATRIBUTOS **
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private int Season { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        // ** METODOS **
        public Serie(int Id, Genero genero, string titulo, int season, string descricao, int ano, int id)
        {
            this.Id = Id;
            this.Genero = Genero;
            this.Titulo = Titulo;
            this.Season = Season; 
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false;
        }

        public Serie(int id, Genero genero, string titulo, int season, int ano, string descricao)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Season = season;
            Ano = ano;
            Descricao = descricao;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Temporada: " + this.Season + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
