﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPrograAvanzada
{
    class GrupoUsuarios
    {
        public static int CAPACITY = 9;
        private int idGrupo;
        private Usuario[] data;
        private int tamanio = 0;
        private int inicial = 0;
        private bool parlamentario;
        public GrupoUsuarios siguiente;
        public int posicion = 0;

        /// <summary>
        /// Método constructor que define el tamaño del arreglo
        /// y el ID del grupo de usuarios
        /// </summary>
        /// <param name="i">ID del grupo</param>
        public GrupoUsuarios(int i)
        {
            data = new Usuario[CAPACITY];
            idGrupo = i;
        }
        public int getIdGrupo()
        {
            return idGrupo;
        }

        /// <summary>
        /// Método para ver el tamaño del arreglo
        /// </summary>
        /// <returns>Tamaño del arreglo</returns>
        public int size()
        {
            return tamanio;
        }
        public void setPosicion(int pos)
        {
            this.posicion = pos;
        }
        public int getPosicion()
        {
            return posicion;
        }

        /// <summary>
        /// Método que indica si el arreglo está vacío o no
        /// </summary>
        /// <returns>True si está vacío el arrelo</returns>
        public bool isEmpty()
        {
            return tamanio == 0;
        }

        /// <summary>
        /// Método que modifica un usuario especifico
        /// </summary>
        /// <param name="i">id del usuario a cambiar</param>
        /// <param name="e">propiedades nuevas del usuario</param>
        /// <returns>usuario modificado</returns>
        public Usuario set(int i, Usuario e)
        {
            Usuario temp = null;
            for (int j = 0; j <= tamanio; j++)
            {
                if (data[j].getID() == i)
                {
                    temp = data[j];
                    data[j] = e;

                }
            }
            return temp;
        }

        /// <summary>
        /// Método para agregar un nuevo usuario
        /// </summary>
        /// <param name="e">datos del nuevo usuario</param>
        public void add(Usuario e)
        {
            if (tamanio == 0)
            {
                if (validarPuesto(e))
                {
                    e.setPuesto("asesor");
                }

                if (tamanio < data.Length)
                {
                    data[tamanio] = e;
                    tamanio++;
                }
                MessageBox.Show("Usuario Creado");
                e.posicion = 0;
            }
            else
            {
                e.posicion = data.Length;
                if (Buscar(e.getID()) == null)
                {
                    if (validarPuesto(e))
                    {
                        e.setPuesto("asesor");
                    }

                    if (tamanio < data.Length)
                    {
                        data[tamanio] = e;
                        tamanio++;
                    }
                    MessageBox.Show("Usuario Creado");
                }
                else if (e.getID() == Buscar(e.getID()).getID())
                {
                    MessageBox.Show("No puede repetir el id del usuario");
                }
            }

            }

        /// <summary>
        /// Método para validar el puesto del usuario (revisa para que solo
        /// haya un parlamentario)
        /// </summary>
        /// <param name="e">datos usuario</param>
        /// <returns></returns>
        public bool validarPuesto(Usuario e)
        {
            parlamentario = false;
            for (int j = 0; j < tamanio; j++)
            {
                if (data[j].getPuesto() == "parlamentario" || data[j].getPuesto() == "Parlamentario")
                {
                    parlamentario = true;
                }
            }

            return parlamentario;
        }

        /// <summary>
        /// Método para eliminar un usuario especifico
        /// </summary>
        /// <param name="i">id del usuario a eliminar</param>
        /// <returns></returns>
        public void remove(int i)
        {
           
            Usuario temp = null;
            int p=0;
            for (int k = 0; k < tamanio; k++)
            {
                if (data[k].getID() == i)
                {
                    temp = data[k];
                    data[k] = default(Usuario);
                    tamanio--;
                    p = k;
                }
            }
            AsignarPos(i,p);
            // return temp;
        }

        /// <summary>
        /// Método que imprime todos los usuarios del arreglo
        /// </summary>
        public String mostrarUsuarios()
        {
            string regresar = "";
            for (int i = 0; i < tamanio; i++)
            {
                regresar += "" + data[i].toString() + "\n";
            }
            return regresar;
        }
        public Usuario[] RecorrerUsuario()
        {

            return data;
        }
        public Usuario Buscar(int id)
        {
            Usuario retorno = null;
            for (int i = 0; i < tamanio; i++)
            {
                if (id == data[i].getID())
                {
                    retorno = data[i];
                }
            }
            return retorno;
        }
        public void AsignarPos(int n,int pos)
        {
            for (int i = pos; i < tamanio ; i++)
            {
                data[i] = data[i + 1];
            }
        }
    }
}
