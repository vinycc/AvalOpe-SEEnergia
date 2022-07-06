using System.ComponentModel;
using System.Threading;

namespace AvalOpe
{
    public static class Enumeracoes
    {
        #region ENUMERAÇÕES
        public enum enumAcoes
        {
            [Description("Fechar")]
            Fechar = 1,
            [Description("Abrir")]
            Abrir = 2,
            [Description("Reconectar")]
            Reconectar = 3,
            [Description("Restaurar")]
            Restaurar = 4,
            [Description("Ligar")]
            Ligar = 5,
            [Description("Desligar")]
            Desligar = 6,
            [Description("Vazio")]
            Outro = 7
            #region INGLES
            /*[Description("Fechar")]
            Closed = 1,
            [Description("Abrir")]
            Open = 2,
            [Description("Reconectar")]
            Reconnect = 3,
            [Description("Restaurar")]
            Restore = 4,
            [Description("Ligar")]
            TurnOn = 5,
            [Description("Desligar")]
            TurnOff = 6,
            [Description("")]
            Empty = 7
            */
            #endregion
        }

        public enum enumObjetosManobra
        {
            [Description("Disjuntor")]
            DJ = 1,
            [Description("Chave Seccionadora")]
            CS = 2,
            [Description("Fusível")]
            FU = 3,
            [Description("Chave Faca")]
            CF = 4,
            [Description("Religador")]
            RE = 5,
            [Description("Transformador")]
            TR = 6
        }

        public enum enumColunas
        {
            [Description("Sequência de Manobras")]
            Sequencia = 1,
            [Description("Tempo")]
            Tempo = 2,
            [Description("Objeto")]
            Objeto = 3,
            [Description("Ação")]
            Acao = 4
        }
        #endregion

        public static string EnumToString(this enumColunas val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string EnumToString(this enumAcoes val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string EnumToString(this enumCriterios val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;

            //if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
            //{
            //    enumCriteriosEnglish v = new enumCriteriosEnglish();
            //    DescriptionAttribute[] attributes = (DescriptionAttribute[])v.GetType().GetField("criterio"+c).GetCustomAttributes(typeof(DescriptionAttribute), false);
            //    return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            //}
            //else
            //{
            //    DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            //    return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            //}
        }

        public static string EnumToString(this enumCriteriosSubtransmissao val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

}
