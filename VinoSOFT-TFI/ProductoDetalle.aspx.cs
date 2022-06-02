﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class ProductoDetalle : System.Web.UI.Page
    {
        BLL.BLL_Producto gestorProducto = new BLL.BLL_Producto();
        BE.BE_Producto producto = new BE.BE_Producto();
       

        protected void Page_Load(object sender, EventArgs e)
        {

                if (Request.QueryString["id"] != null || int.TryParse(Request.QueryString["id"], out _))
                {
                    int idProd = int.Parse(Request.QueryString["id"]);
                    producto = gestorProducto.listarProductoPorID(idProd);
                    if (producto == null)
                    {
                        Response.Redirect("/Productos.aspx", false);
                    }
                    else
                    {
                        completarPaginaConProducto();
                    }

                }
                else
                {
                    Response.Redirect("/Productos.aspx", false);
                }
            
        }

        protected void completarPaginaConProducto() {
            ltlPrecio.Text = producto.PRECIO.ToString();
            ltlTitulo.Text = producto.NOMBRE;
            ltlDescripcionCorta.Text = producto.DESCRIPCIONCORTA;
            completarComentarios();
        }

        protected void actualizarRepeaterComentarios() {
            producto.COMENTARIOS = gestorProducto.listarComentariosPorID(producto.IDPRODUCTO);
            completarComentarios();
            limpiarTxt();
        }

        protected void limpiarTxt()
        {
            txtAutor.Text = null;
            txtComentario.Text = null;

        }

        protected void completarComentarios()
        {
            if (producto.COMENTARIOS.Count > 0)
            {
                rptComentarios.Visible = true;
                rptComentarios.DataMember = "BE_ProductoComentario";
                rptComentarios.DataSource = producto.COMENTARIOS;
                rptComentarios.DataBind();


            }
            else
            {
                //ocultar div de comentarios.
            }
        }

        protected void btnGuardarComentario_Click(object sender, EventArgs e)
        {
            try {
                BE.BE_ProductoComentario comentario = new BE.BE_ProductoComentario();
                comentario.COMENTARIO = txtComentario.Text;
                comentario.FECHAHORA = DateTime.Now;
                comentario.ACTIVO = 1;
                comentario.IDPRODUCTO = producto.IDPRODUCTO;
                comentario.AUTOR = txtAutor.Text;

                gestorProducto.insertarComentario(comentario);

                //actualizarRepeaterComentarios();
                limpiarTxt();
                Response.Redirect("/ProductoDetalle.aspx?id=" + producto.IDPRODUCTO.ToString());

            }
            catch
            {

            }


        }
    }
    }