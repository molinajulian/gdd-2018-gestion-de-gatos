using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public static class Ordinales
    {

       public static Dictionary<string, int> UsuarioFields = new Dictionary<string, int>
                                                {
                                                    {"username", 0},
                                                    {"estado", 1},
                                                };
       public static Dictionary<string, int> CamposRol = new Dictionary<string, int>
                                                {
                                                    {"nombre", 0}
                                                };
       public static Dictionary<string, int> Cliente = new Dictionary<string, int>
                                                {   
                                                    {"nombre",0},
                                                    {"apellido",1},
                                                    {"tipoDocumento",2},
                                                    {"numeroDocumento",3},
                                                    {"cuil",4},
                                                    {"email",5},
                                                    {"telefono",6},
                                                    {"fechaNacimiento",7},
                                                    {"fechaCreacion",8},
                                                    

                                                };
       public static Dictionary<string, int> Direccion = new Dictionary<string, int> 
                                                 {
                                                 {"codigo",0}, 
                                                 {"numero",1},
                                                 {"departamento",2},
                                                 {"localidad",3},  
                                                 {"codPostal",4},
                                                 {"calle",5}

                                                                                               
                                                 };

       public static Dictionary<string, int> Tarjeta = new Dictionary<string, int> 
                                                    {
                                                    {"numero",0},
                                                    {"nombre",1},
                                                    {"fechaVencimiento",2},
                                                    {"ccv",3}
                                                    };
       public static Dictionary<string, int> Empresa = new Dictionary<string, int> 
                                                    {
                                                    {"razonSocial",0}, 
                                                    {"email",1},
                                                    {"telefono",2},
                                                    {"codPostal",3}, 
                                                    {"ciudad",4},
                                                    {"cuit  ",5}
                                                    
                                                    };
       public static Dictionary<string, int> Rubro = new Dictionary<string, int> 
                                                    {
                                                    {"codigo",0},
                                                    {"descripcion",1}
                                                    
                                                    };
       public static Dictionary<string, int> Publicacion = new Dictionary<string, int> 
                                                    {
                                                    {"codigo",0},
                                                    {"descripcion",1},
                                                    {"fechaPublicacion",2},
                                                    {"fechaFuncion",3}
                                                    };
       public static Dictionary<string, int> Ubicacion = new Dictionary<string, int> 
                                                    {
                                                    {"fila",0},
                                                    {"asiento",1},
                                                    {"tipo",3}
                                                    };
       public static Dictionary<string, int> Grado = new Dictionary<string, int> 
                                                    {
                                                    {"tipo",0},
                                                    {"comision",1},
                                                    {"descuento",3}
                                                    };
       public static Dictionary<string, int> EstadoPublicacion = new Dictionary<string, int> 
                                                    {
                                                    {"estado",0},
                                                    {"puedeCambiarDeEstado",1},
                                                    }; 
   }
    
}
