using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using mroblesS5.Models;
using SQLite;

namespace mroblesS5.Repositories
{
    public class PersonaRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        public string statusMessage {  get; set; }

        public PersonaRepository(string dbPath)
        {
            this.dbPath = dbPath;
        }

        private void Init()
        {
            if(conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();
        }

        public void AddnewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona persona = new() { Name = name };
                result = conn.Insert(persona);
                statusMessage = string.Format("Dato Ingresado");
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Error "+ex.Message);
            }
        }

        public List<Persona> GetAllPersona()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Error " + ex.Message);
            }
            return new List<Persona>();
        }
    }
}
