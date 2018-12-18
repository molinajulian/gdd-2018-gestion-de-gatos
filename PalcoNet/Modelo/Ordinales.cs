using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public static class Ordinales
    {
       public static Dictionary<string, int> camposGetTiposDoc = new Dictionary<string, int> 
                                               {
                                                   {"tipos_doc_id",0},
                                                   {"tipos_doc_descr",1}
                                               };
       public static Dictionary<string, int> campoSalidaAgregar = new Dictionary<string, int>
                                                {
                                                    {"salida",0}
                                                };
       public static Dictionary<string, int> camposUsuario = new Dictionary<string, int>
                                                {
                                                    {"id", 0},
                                                    {"username", 1},
                                                    {"estado", 2},
                                                    {"primer_logueo",3}
                                                };
       public static Dictionary<string, int> campoClienteExistente = new Dictionary<string, int>
                                                {
                                                    {"cantidad",0}
                                                };
       public static Dictionary<string, int> camposRol = new Dictionary<string, int>
                                                {
                                                    {"id", 0},
                                                    {"nombre", 1}
                                                };
       public static Dictionary<string, int> camposGetClientes = new Dictionary<string, int>
                                                {
                                                    {"tipo_doc_descr", 0},
                                                    {"cli_doc", 1},
                                                    {"cli_cuil", 2},
                                                    {"cli_nombre", 3},
                                                    {"cli_apellido", 4},
                                                    {"cli_mail", 5},
                                                    {"dom_calle", 6},
                                                    {"dom_nro_calle", 7},
                                                    {"dom_depto",8},
                                                    {"dom_piso",9},
                                                    {"dom_localidad", 10},
                                                    {"dom_cod_postal", 11},
                                                    {"habilitado",12}
                                                };
        public static Dictionary<string, int> camposGetCliente = new Dictionary<string, int>
                                                {
                                                    {"tipo_doc_id", 0},
                                                    {"cli_doc", 1},
                                                    {"cli_apellido", 2},
                                                    {"cli_nombre", 3},
                                                    {"cli_cuil", 4},
                                                    {"cli_fecha_nac", 5},
                                                    {"cli_fecha_creacion", 6},
                                                    {"cli_mail", 7},
                                                    {"cli_tel", 8},
                                                    {"cli_dom_id", 9},
                                                    {"cli_puntos", 10},
                                                    {"cli_usuario_id", 11},
                                                    {"cli_habilitado", 12}
                                                };
        public static Dictionary<string, int> camposFuncionalidad = new Dictionary<string, int>
                                                {
                                                    {"id", 0},
                                                    {"descripcion", 1}
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
       public static Dictionary<string, int> Domicilio = new Dictionary<string, int> 
                                                 {
                                                 {"id",0},
                                                 {"codPostal",1},
                                                 {"localidad",2},
                                                 {"piso",3},
                                                 {"departamento",4},
                                                 { "numero",5},
                                                 {"calle",6}
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
                                                    {"cuit",0},
                                                    {"razonSocial",1},
                                                    {"fechaCreacion",2},
                                                    {"email",3},
                                                    {"domicilioId",4},
                                                    {"usuarioId", 5},
                                                    {"telefono",6},
                                                    {"habilitada", 7}
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
                                                    {"fechaCreacion",2},
                                                    {"gradoCodigo",3},
                                                    {"especCodigo",4},
                                                    {"estadoId",5}
                                                    };
       public static Dictionary<string, int> Ubicacion = new Dictionary<string, int> 
                                                    {
                                                    {"fila",0},
                                                    {"asiento",1},
                                                    {"tipo",3}
                                                    };
        public static Dictionary<string, int> TipoUbicacion = new Dictionary<string, int>
                                                    {
                                                    {"Ubic_Tipo_Cod",0},
                                                    {"Ubic_Tipo_Descr",1}
                                                    };
        public static Dictionary<string, int> Grado = new Dictionary<string, int> 
                                                    {
                                                    {"codigo",0},
                                                    {"comision",1},
                                                    {"descripcion",2}
                                                    };
        public static Dictionary<string, int> ItemFactura = new Dictionary<string, int>
                                                    {
                                                    {"itemFact_Id",0},
                                                    {"itemFact_FactId",1},
                                                    {"itemFact_Cantidad",2},
                                                    {"itemFact_Monto",3 }
                                                    };
        public static Dictionary<string, int> Factura = new Dictionary<string, int>
                                                    {
                                                    {"Fact_Id",0},
                                                    {"Fact_Metodo_Pago",1},
                                                    {"Fact_Total",2},
                                                    {"Fact_Fecha",3 },
                                                    {"Fact_Empresa_Cuit",4 }
                                                    };
        public static Dictionary<string, int> Compra = new Dictionary<string, int>
                                                    {
                                                    {"Compra_Id",0},
                                                    {"Compra_Publicacion_Id",1},
                                                    {"Compra_Cliente_Documento",2},
                                                    {"Compra_TipoDoc",3 },
                                                    {"Compra_Fecha",4 }
                                                    };
        public static Dictionary<string, int> EstadoPublicacion = new Dictionary<string, int> 
                                                    {
                                                    {"id",0},
                                                    {"descripcion",1 },
                                                    {"editable",2},
                                                    };
       public static Dictionary<string, int> Espectaculo = new Dictionary<string, int> 
                                                    {
                                                    {"id",0},
                                                    {"descripcion",1 },
                                                    {"fecha",2},
                                                    {"hora",3},
                                                    {"fechaVencimiento",4},
                                                    {"idRubro",5},
                                                    {"idEmpresa",6},
                                                    {"idDomicilio",7}
                                                    };
        public static Dictionary<string, int> Premio = new Dictionary<string, int>
                                                    {
                                                    {"Premio_Id",0},
                                                    {"Premio_Desc",1},
                                                    {"Premio_Puntos",2}
                                                    };
    }

}
