using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalOpe
{
    public class Criterio
    {
        public int Id;
        public string Descricao;
        public double Peso;
        public double Desvio;
        public bool Ativo;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public Criterio() { }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id">Identificador do critério</param>
        /// <param name="descricao">Descrição do critério</param>
        /// <param name="peso">Valor do Peso</param>
        /// <param name="desvio">Calor do desvio</param>
        /// <param name="ativo">Indica se o critério está ativo</param>
        public Criterio (enumCriterios criterio, double peso, double desvio, bool ativo)
        {
            this.Id = (int)criterio;
            this.Descricao = criterio.EnumToString();
            this.Peso = peso;
            this.Desvio = desvio;
            this.Ativo = ativo;
        }

        public Criterio(enumCriteriosSubtransmissao criterio, double peso, double desvio, bool ativo)
        {
            this.Id = (int)criterio;
            this.Descricao = criterio.EnumToString();
            this.Peso = peso;
            this.Desvio = desvio;
            this.Ativo = ativo;
        }

        public Criterio(int id, string descricao, double peso, double desvio, bool ativo)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Peso = peso;
            this.Desvio = desvio;
            this.Ativo = ativo;
        }
    }

   
}
