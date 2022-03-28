using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace ETL_Transfero
{
    public class Program
    {
        static string transacoes = @"C:\Users\aluno 03\Downloads\transferoacademy_transações.csv";

        static void Main(string[] args)
        {
            DataTable transacao = CSVToDataTable(transacoes, ";");

            //var somaBTC = transacao.AsEnumerable().Where(row => row.Field<string>("Moeda que Entrou") == "USDT");

            var usdt = from row in transacao
                       where row["Moeda que Entrou"] == "USDT"
                       select row;
        }

        public static DataTable CSVToDataTable(string path, string delimiter)
        {
            DataTable csvDataTable = new DataTable();

            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(path))
                {
                    csvReader.SetDelimiters(new string[] { delimiter });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {
                        DataColumn dataColumn = new DataColumn(column);
                        dataColumn.AllowDBNull = true;
                        csvDataTable.Columns.Add(dataColumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                                fieldData[i] = "";

                            csvDataTable.Rows.Add(fieldData);
                        }
                    }

                    foreach (DataRow row in csvDataTable.Rows)
                    {
                        if (csvDataTable.AsEnumerable().All(dr => dr.IsNull("Column1")))
                            csvDataTable.Columns.Remove("Column1");
                    }
                }
            }
            catch { }
            return csvDataTable;
        }
    }
}