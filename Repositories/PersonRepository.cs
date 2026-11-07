using fushcasinaS5A.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fushcasinaS5A.Repositories
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLite.SQLiteConnection _conn;

        // Constructor
        public string StatusMessage { get; set; }
        public PersonRepository(string Path)
        {
            _dbPath = Path;
            
        }
        // Conexion a la base de datos y creacion de la tabla persona
        private void Init()
        {
            if (_conn is not null)
                return;
            _conn = new (_dbPath);
            _conn.CreateTable<Persona>();
        }

        // Metodo para agregar una persona a la base de datos insert
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona persona = new () { Name = name };
                result = _conn.Insert(persona);
                StatusMessage = string.Format("Dato ingresado");

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error:" +ex.Message);
            }
        }

        // Metodo para obtener todas las personas de la base de datos Select

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error:" + ex.Message);
            }
            return new List<Persona>();
        }

     
        // Metodo para actualizar el nombre de una persona Update
        // Se actualiza por Id, asi solo cambia la persona seleccionada
        public void UpdatePerson(int id, string name)
        {
            int result = 0;
            try
            {
                Init();
                if (id <= 0)
                    throw new Exception("Seleccione una persona");
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona persona = new () { Id = id, Name = name };
                result = _conn.Update(persona);
                if (result == 0)
                    throw new Exception("No se encontro la persona");
                StatusMessage = string.Format("Dato actualizado");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error:" + ex.Message);
            }
        }

        // Metodo para eliminar una persona de la base de datos Delete
        // Se elimina por Id, asi solo se borra la persona seleccionada
        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                Init();
                if (id <= 0)
                    throw new Exception("Seleccione una persona");
                result = _conn.Delete<Persona>(id);
                if (result == 0)
                    throw new Exception("No se encontro la persona");
                StatusMessage = string.Format("Dato eliminado");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error:" + ex.Message);
            }
        }

    }
}
