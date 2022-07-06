using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace AvalOpe
{
    class Manobra
    {
        [CsvColumn(FieldIndex = 1)]
        public string Sequencia { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string Tempo { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string Objeto { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public string DescricaoObjeto { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public string Acao { get; set; }
    }
}
