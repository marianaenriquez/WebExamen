using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using ventasWeb.Models;
using System.Data;


namespace ventasWeb.Service
{
    class ClaseAccesoDatos
    {

        public List<Productos> ListadoProductos;
        public List<Ventas> ListadoVentas;

        public MySqlConnection conectar()
        {

            var connect = new MySqlConnection("Server= localhost;Database=ventasexamen;User ID= root;Password= '';");
            return connect;

        }

        public List<Ventas> ConsultaVentas(int IdProducto)
        {
            var dt = new DataTable();
            conectar();
            var cmd = new MySqlCommand("SELECT * FROM ventas v WHERE v.IDProductos='" + IdProducto + "'", conectar());
            conectar().Open();
            var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            ListadoVentas = new List<Ventas>();

            try
            {

                ListadoVentas = (from DataRow dr in dt.Rows
                                 select new Ventas()
                                 {
                                     IDVentas = int.Parse(dr["IDVentas"].ToString()),
                                     IDProductos = int.Parse(dr["IDProductos"].ToString()),
                                     CantidadVendida = int.Parse(dr["CantidadVendida"].ToString()),
                                     Fecha = dr["Fecha"].ToString(),
                                 }).ToList();


                conectar().Close();
                return ListadoVentas;
            }
            catch (MySqlException e)
            {
                conectar().Close();
                return ListadoVentas;
            }
        }
        public List<Productos> ConsultaPro(int IdProducto)
        {
            var dt = new DataTable();
            conectar();
            var cmd = new MySqlCommand("SELECT * FROM productos v WHERE v.IDProductos='" + IdProducto + "'", conectar());
            conectar().Open();
            var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            ListadoProductos = new List<Productos>();

            try
            {

                ListadoProductos = (from DataRow dr in dt.Rows
                                    select new Productos()
                                    {
                                        IDProductos = int.Parse(dr["IDProductos"].ToString()),
                                        Titulo = dr["Titulo"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        PrecioUnitario = double.Parse(dr["PrecioUnitario"].ToString()),
                                        Existencias = int.Parse(dr["Existencias"].ToString()),
                                    }).ToList();


                conectar().Close();
                return ListadoProductos;
            }
            catch (MySqlException e)
            {
                conectar().Close();
                return ListadoProductos;
            }
        }

        public List<Ventas> ConsultaTabla()
        {
            var ds = new DataTable();
            var cmd = new MySqlCommand("SELECT * FROM ventas ", conectar());
            conectar().Open();
            var da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            ListadoVentas = new List<Ventas>();
            try
            {

                ListadoVentas = (from DataRow dr in ds.Rows
                                 select new Ventas()
                                 {
                                     IDVentas = int.Parse(dr["IDVentas"].ToString()),
                                     IDProductos = int.Parse(dr["IDProductos"].ToString()),
                                     CantidadVendida = int.Parse(dr["CantidadVendida"].ToString()),
                                     Fecha = dr["Fecha"].ToString(),
                                 }).ToList();


                conectar().Close();
                return ListadoVentas;
            }
            catch (MySqlException e)
            {
                conectar().Close();
                return ListadoVentas;
            }


        }

        public List<Productos> ConsultaTablaP()
        {
            var ds = new DataTable();
            var cmd = new MySqlCommand("SELECT * FROM productos ", conectar());
            conectar().Open();
            var da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            ListadoProductos = new List<Productos>();
            try
            {

                ListadoProductos = (from DataRow dr in ds.Rows
                                    select new Productos()
                                    {
                                        IDProductos = int.Parse(dr["IDProductos"].ToString()),
                                        Titulo = dr["Titulo"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        PrecioUnitario = double.Parse(dr["PrecioUnitario"].ToString()),
                                        Existencias = int.Parse(dr["Existencias"].ToString()),
                                    }).ToList();


                conectar().Close();
                return ListadoProductos;
            }
            catch (MySqlException e)
            {
                conectar().Close();
                return ListadoProductos;
            }



        }

        public List<Ventas> ConsultaMasV()
        {
            var ds = new DataTable();
            var cmd = new MySqlCommand("SELECT v.IDVentas, v.IDProductos, sum(v.CantidadVendida) AS CantidadVendida, v.Fecha From ventas v GROUP  BY v.IDProductos ORDER BY CantidadVendida desc; ", conectar());
            conectar().Open();
            var da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            ListadoVentas = new List<Ventas>();
            try
            {

                ListadoVentas = (from DataRow dr in ds.Rows
                                 select new Ventas()
                                 {
                                     IDVentas = int.Parse(dr["IDVentas"].ToString()),
                                     IDProductos = int.Parse(dr["IDProductos"].ToString()),
                                     CantidadVendida = int.Parse(dr["CantidadVendida"].ToString()),
                                     Fecha = dr["Fecha"].ToString(),
                                 }).ToList();


                conectar().Close();
                return ListadoVentas;
            }
            catch (MySqlException e)
            {
                conectar().Close();
                return ListadoVentas;
            }


        }
    }
}
