using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Automata
{
    public class AnalizadorLexico
    {

        #region Miembros Privados

        private TablaTransiciones m_tablaTransiciones;

        private string m_strCodigoFuente;
        private int m_intCantidadErrores;

        private List<string> m_lstLineasCodigo;
        private List<string> m_lstListaErrores;
        private List<string> m_lstListaIdentificadores;

        #endregion Miembros Privados

        #region Propiedades Publicas

        public string CodigoFuente
        {
            get { return m_strCodigoFuente; }
        }

        public int CantidadErrores
        {
            get { return m_intCantidadErrores; }
        }

        public List<string> ListaErrores
        {
            get { return m_lstListaErrores; }
            set { m_lstListaErrores = value; }
        }

        public List<string> ListaIdentificadores
        {
            get { return m_lstListaIdentificadores; }
            set { m_lstListaIdentificadores = value; }
        }

        #endregion Propiedades Publicas

        #region Constructores

        public AnalizadorLexico(TablaTransiciones tablaTransiciones)
        {
            this.m_tablaTransiciones = tablaTransiciones;
            this.m_strCodigoFuente = "";
            this.m_lstLineasCodigo = new List<string>();
            this.m_lstListaErrores = new List<string>();
            this.m_lstListaIdentificadores = new List<string>();
        }

        #endregion Constructores

        #region Metodos Publicos

        public void EstablecerCodigoFuente(string NuevoCodigoFuente)
        {
            /// Se almacena el codigo fuente en el analizador lexico.
            /// this.m_strCodigoFuente = NuevoCodigoFuente;
            
            /// Se divide por brinco de linea el codigo fuente, y se almacena en un arreglo de cadenas.
            string[] strLineasCodigo = NuevoCodigoFuente.Split('\n');

            /// Se almacena la cadena en una lista generica.
            int NumeroLineaCodigo = 0;
            foreach (string LineaCodigo in strLineasCodigo)
            {
                this.m_lstLineasCodigo.Add(LineaCodigo);
                this.m_strCodigoFuente += ++NumeroLineaCodigo + " " + LineaCodigo + "\n";
            }
        }

        public void EstablecerTablaTransiciones(TablaTransiciones NuevaTablaTransiciones)
        {
            this.m_tablaTransiciones = NuevaTablaTransiciones;
        }
        
        /// <summary>
        ///   Metodo para obtener el archivo de TOKENS por medio del codigo fuente proporcionado.
        /// </summary>
        /// <returns>Devuelve una cadena que representa el archivo de TOKENS.</returns>
        public string ObtenerArchivoTokens() 
        {
            string strArchivoTokens = "";
            /// Se procede en leer todo el codigo fuente, linea por linea.
            foreach (string LineaCodigo in this.m_lstLineasCodigo)
            {
                /// Se obtiene todas las cadenas de la linea de codigo y se itera todas
                /// las cadenas para obtener sus respectivos TOKENS.
                foreach (string cadena in _ObtenerCadenas(LineaCodigo))
                {
                    /// Se establece la cadena en la tabla de transiciones.
                    this.m_tablaTransiciones.EstablecerCadena(cadena);

                    /// Una vez que la tabla de transiciones lea la cadena, se procede en obtener su respectivo TOKEN.
                    string Token = m_tablaTransiciones.ObtenerToken();

                    /// Si el TOKEN es un identificador, asignar el numero del identificador de la tabla de simbolos.
                    if (Token == "ID")
                        Token += this._AnalizarIdentificador(cadena);

                    /// Se asigna el TOKEN al archivo de tokens.
                    strArchivoTokens += Token + " ";
                }
                strArchivoTokens += "\n";
            }
            return strArchivoTokens;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokensOpciones"></param>
        /// <returns></returns>
        public string ObtenerArchivoTokens(ArchivoTokensOpciones tokensOpciones)
        {
            switch (tokensOpciones)
            {
                case ArchivoTokensOpciones.Ninguno:
                    return this.ObtenerArchivoTokens();

                case ArchivoTokensOpciones.ConNumeroDeLinea:

                    int NumeroLinea = 0;
                    string strArchivoTokens = "";
                    /// Se procede en leer todo el codigo fuente, linea por linea.
                    foreach (string LineaCodigo in this.m_lstLineasCodigo)
                    {
                        /// Se obtiene todas las cadenas de la linea de codigo y se itera todas
                        /// las cadenas para obtener sus respectivos TOKENS.
                        strArchivoTokens += ++NumeroLinea + " ";
                        foreach (string cadena in _ObtenerCadenas(LineaCodigo))
                        {
                            /// Se establece la cadena en la tabla de transiciones.
                            this.m_tablaTransiciones.EstablecerCadena(cadena);

                            /// Una vez que la tabla de transiciones lea la cadena, se procede en obtener su respectivo TOKEN.
                            string Token = m_tablaTransiciones.ObtenerToken();

                            /// Si el TOKEN es un identificador, asignar el numero del identificador de la tabla de simbolos.
                            if (Token == "ID")
                                Token += this._AnalizarIdentificador(cadena);

                            /// Se asigna el TOKEN al archivo de tokens.
                            strArchivoTokens += Token + " ";
                        }
                        strArchivoTokens += "\n";
                    }
                    return strArchivoTokens;
                default:
                    throw new Exception();
            }
        }

        #endregion Metodos Publicos

        #region Metodos Privados

        /// <summary>
        ///   Metodo para obtener todas las cadenas que se encuentran en una linea de codigo.
        /// </summary>
        /// <param name="LineaCodigo"></param>
        /// <returns></returns>
        private List<string> _ObtenerCadenas(string LineaCodigo)
        {
            string[] saCadenas = Regex.Split(LineaCodigo.Replace("\t", ""), "(\")");

            List<string> ListaSubCadenas = new List<string>();
            string NuevaCadena = "";
            bool CadenaAbierta = false;

            for (int i = 0; i < saCadenas.Length; i++)
            {
                if (saCadenas[i] == "" || saCadenas[i] == " ")
                    continue;

                if (saCadenas[i].Contains("\""))
                {
                    if (!CadenaAbierta)
                    {
                        CadenaAbierta = true;
                        NuevaCadena += saCadenas[i];
                        continue;
                    }
                    else
                    {
                        CadenaAbierta = false;
                        NuevaCadena += saCadenas[i];
                        ListaSubCadenas.Add(NuevaCadena);
                        NuevaCadena = "";
                        continue;
                    }
                }
                else if (CadenaAbierta)
                {
                    NuevaCadena += saCadenas[i];
                }
                else
                {
                    ListaSubCadenas.Add(saCadenas[i]);
                }
            }

            /// Remueve cadenas vacias...
            foreach (string subcadena in ListaSubCadenas)
            {
                if (subcadena == "" || subcadena == " ")
                    ListaSubCadenas.Remove(subcadena);
            }


            List<string> ListaCadenas = new List<string>();
            int indice = 0;
            foreach (string cadena in ListaSubCadenas)
            {
                if (cadena.Contains("#"))
                {
                    string strComentario = "";
                    for (int i = indice; i < ListaSubCadenas.Count; i++)
                    { 
                        strComentario += ListaSubCadenas[i];
                    }
                    ListaCadenas.Add(strComentario.Replace(" ", ""));
                    break;
                }
                else if (cadena.Contains("\""))
                {
                    ListaCadenas.Add(cadena);
                }
                else
                {
                    string[] saSubCadenas = cadena.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string subcadena in saSubCadenas)
                        ListaCadenas.Add(subcadena);
                }
                indice++;
            }

            return ListaCadenas;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Identificador"></param>
        /// <returns></returns>
        private int _AnalizarIdentificador(string Identificador)
        {
            int indice = 1;
            foreach (string id in this.m_lstListaIdentificadores)
            {
                if (Identificador == id)
                    return indice;
                indice++;
            }
            m_lstListaIdentificadores.Add(Identificador);
            return indice;
        }

        #endregion Metodos Privados

    }
}
