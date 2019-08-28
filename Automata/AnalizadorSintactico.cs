using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata
{
    public class AnalizadorSintactico
    {
        #region Miembros Privados

        private TablaTransiciones m_tablaTransiciones;

        private string m_strArchivoTokens;
        private int m_intCantidadErrores;

        private List<string> m_lstLineasToken;
        private List<string> m_lstListaErrores;

        #endregion  Miembros Privados

        #region Propiedades

        public string ArchivoTokens
        {
            get { return m_strArchivoTokens; }
        }

        public int CantidadErrores
        {
            get { return this.m_intCantidadErrores; }
        }

        public List<string> ListaErrores
        {
            get { return this.m_lstListaErrores; }
        }

        #endregion Propiedades

        #region Constructores

        public AnalizadorSintactico(string strArchivoTokens)
        {
            this.m_strArchivoTokens = strArchivoTokens;
        }

        #endregion Constructores

        #region Metodos Publicos

        public void EstablecerArchivoTokens(string NuevoArchivoTokens)
        {
            this.m_strArchivoTokens = NuevoArchivoTokens;
        }
        
        public void EstablecerTablaTransiciones(TablaTransiciones NuevaTablaTransiciones)
        {
            this.m_tablaTransiciones = NuevaTablaTransiciones;
        }

        #endregion Metodos Publicos
    }
}
