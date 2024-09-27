using DTO;
using System.Data.Entity.Validation;
using Transportes_API.Models;

namespace Transportes_API.Services
{
    public interface ICamiones
    {
        //es una estructura que define un contrato o conjunto de métodos y
        //propiedades que una clase debe implementar.
        //Una interfaz establece un conjunto de requisitos que cualquier clase
        //que la implemente debe seguir. Estos requisitos son declarados en la
        //interfaz en forma de firmas de métodos y propiedades,
        //pero la interfaz en sí misma no proporciona ninguna implementación
        //de estos métodos o propiedades.Es responsabilidad de las clases que
        //implementan la interfaz proporcionar las implementaciones concretas de
        //estos miembros.

        //Las interfaces son útiles para lograr la abstracción y la reutilización
        //de código en C#.


        //Get
        List<Camiones> GetCamiones();

        Camiones_DTO GetCamionbyID(int id);

        //Insert
        string InsertCamion(Camiones_DTO camion);

        //Update
        string UpdateCamion(Camiones_DTO camion);

        //Delete 
        string DeleteCamion(int id);
    
    }

    public class CamionesService : ICamiones
    { 
        //variable para el cotxto
    private readonly TransportesContext _context;

        //Constructor para inicializar el contexto 
        public CamionesService(TransportesContext context)
        {
            this._context = context; 
        }
        //Implementacion de métodos
        public string DeleteCamion(int id)
        {
            try
            {
                //busco en la bd si existe el elemento a eliminar (recupero el elemento)
                Camiones _camion = _context.Camiones.Find(id);
                
                if (_camion != null)
                {
                    try
                    {
                        //Intenta remover el camion mediante su ID 
                        _context.Camiones.Remove(_camion);
                        //Impacta la base de datos
                        _context.SaveChanges();
                        //Retorna mensaje 
                        return $"El camión {id} ha si eliminado";
                    }
                    catch (DbEntityValidationException ex)
                    {
                        string resp = "";
                        //Recorro todos los posibles errores de la entidad Referencial 
                        foreach (var error in ex.EntityValidationErrors)
                        {
                            //Recorro los detalles de cada error
                            foreach (var validationError in error.ValidationErrors)
                            {
                                resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                                resp += validationError.PropertyName;
                                resp += validationError.ErrorMessage;
                            }
                        }
                        return resp;
                    }
                }
                else
                {
                    return $"No se encontró el objeto con identificador {id}";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Camiones_DTO GetCamionbyID(int id)
        {
            Camiones_DTO respuesta = new Camiones_DTO();   
            Camiones _camion = _context.Camiones.Find(id);
                if (_camion != null)
                {
                    respuesta.ID_camiones = _camion.ID_camiones;
                    respuesta.matricula = _camion.matricula;
                    respuesta.capacidad = _camion.capacidad;
                    respuesta.tipo_camion = _camion.tipo_camion;
                    respuesta.urlfoto = _camion.urlfoto;
                    respuesta.marca = _camion.marca;
                    respuesta.modelo = _camion.modelo;
                    respuesta.kilometraje = _camion.kilometraje;
                respuesta.disponibilidad = _camion.disponibilidad;
                }
            return respuesta;
        }

        public List<Camiones> GetCamiones()
        {
            List<Camiones> lista_camiones = _context.Camiones.ToList(); //lleno mi lista usando LinQ
            return lista_camiones; //regreso mi lista
        }

        public string InsertCamion(Camiones_DTO camion)
        {
            try
            {
                //Creo  un camion del odelo original
                Camiones _camion = new Camiones();
                //asigno los valores que provienen del parámetro
                _camion.ID_camiones = camion.ID_camiones;
                _camion.matricula = camion.matricula;
                _camion.capacidad = camion.capacidad;
                _camion.tipo_camion = camion.tipo_camion;
                _camion.urlfoto = camion.urlfoto;
                _camion.marca = camion.marca;
                _camion.modelo = camion.modelo;
                _camion.kilometraje = camion.kilometraje;
                _camion.disponibilidad = camion.disponibilidad;

                try
                {
                    //añadimos el bjeto al contexto
                    _context.Camiones.Add(_camion);
                    _context.SaveChanges();
                    
                }
                catch (DbEntityValidationException ex)
                {

                    string resp = "";
                    //Recorro todos los posibles errores de la entidad Referencial 
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        //Recorro los detalles de cada error
                        foreach (var validationError in error.ValidationErrors)
                        {
                            resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                            resp += validationError.PropertyName;
                            resp += validationError.ErrorMessage;
                        }

                    }
                    return resp;
                }
                //Retorno la respues
                return "Camión agregado con éxito";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateCamion(Camiones_DTO camion)
        {
            try
            {
                //Creo  un camion del odelo original
                Camiones _camion = new Camiones();
                //asigno los valores que provienen del parámetro
                _camion.ID_camiones = camion.ID_camiones;
                _camion.matricula = camion.matricula;
                _camion.capacidad = camion.capacidad;
                _camion.tipo_camion = camion.tipo_camion;
                _camion.urlfoto = camion.urlfoto;
                _camion.marca = camion.marca;
                _camion.modelo = camion.modelo;
                _camion.kilometraje = camion.kilometraje;
                _camion.disponibilidad = camion.disponibilidad;

                try
                {
                    //añadimos el bjeto al contexto
                    _context.Entry(_camion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                }
                catch (DbEntityValidationException ex)
                {

                    string resp = "";
                    //Recorro todos los posibles errores de la entidad Referencial 
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        //Recorro los detalles de cada error
                        foreach (var validationError in error.ValidationErrors)
                        {
                            resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                            resp += validationError.PropertyName;
                            resp += validationError.ErrorMessage;
                        }

                    }
                    return resp;
                }
                //Retorno la respues
                return "Camión actualizado con éxito";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        //Implementacion de metodos


    }
}
