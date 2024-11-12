using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BA
{
    public class Notas
    {
        private DataTable Lista;
        private const string NombreArchivo = "Notas.xml";

        public Notas()
        {
            Lista = new DataTable();
            Lista.TableName = "Notas";
            Lista.Columns.Add("Titulo");
            Lista.Columns.Add("Texto");
            Lista.Columns.Add("FechaHora");
            LeerArchivo();
        }

        public void Insert(Nota nota)
        {
            Lista.Rows.Add();
            int NuevoRenglon = Lista.Rows.Count - 1;
            Lista.Rows[NuevoRenglon]["Titulo"] = nota.Titulo;
            Lista.Rows[NuevoRenglon]["Texto"] = nota.Texto;
            Lista.Rows[NuevoRenglon]["FechaHora"] = nota.FechaHora;

            Lista.WriteXml(NombreArchivo);
        }

        public void Actualizar(string fechaHora, Nota nota)
        {
            foreach (DataRow row in Lista.Rows)
            {
                if (row["FechaHora"].ToString().Equals(fechaHora))
                {
                    row["Titulo"] = nota.Titulo;
                    row["Texto"] = nota.Texto;
                    row["FechaHora"] = nota.FechaHora;
                    break;
                }
            }
            Lista.WriteXml(NombreArchivo);
        }

        public void Eliminar(string fechaHora)
        {
            foreach (DataRow row in Lista.Rows)
            {
                if (row["FechaHora"].ToString().Equals(fechaHora))
                {
                    Lista.Rows.Remove(row);
                    break;
                }
            }
            Lista.WriteXml(NombreArchivo);
        }

        public Nota[] LeerTodas()
        {
            Nota[] Notas = new Nota[Lista.Rows.Count];
            int i = 0;

            foreach (DataRow nota in Lista.Rows)
            {
                Nota Nota = new Nota(nota["Titulo"].ToString(),
                                     nota["Texto"].ToString(),
                                     nota["FechaHora"].ToString());
                Notas[i] = Nota;
                i++;
            }
            return Notas;
        }

        private void LeerArchivo()
        {
            if (System.IO.File.Exists(NombreArchivo))
            {
                Lista.ReadXml(NombreArchivo);
            }
        }

        public int Size()
        {
            return Lista.Rows.Count;
        }
    }
}
