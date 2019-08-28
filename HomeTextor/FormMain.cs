// HomeTextor
//
// Copyright(c) 2018 Guillermo A. Rodríguez
//
// Licencia MIT(https://es.wikipedia.org/wiki/Licencia_MIT)
//
// Se concede permiso, libre de cargos, a cualquier persona que obtenga una copia
// de este software y de los archivos de documentación asociados (el "Software"), 
// para utilizar el Software sin restricción, incluyendo sin limitación los derechos
// a usar, copiar, modificar, fusionar, publicar, distribuir, sublicenciar, y/o vender copias
// del Software, y a permitir a las personas a las que se les proporcione el Software a hacer
// lo mismo, sujeto a las siguientes condiciones:
//
// El aviso de copyright anterior y este aviso de permiso se incluirán en todas
// las copias o partes sustanciales del Software.
//
// EL SOFTWARE SE PROPORCIONA "TAL CUAL", SIN GARANTÍA DE NINGÚN TIPO, EXPRESA O IMPLÍCITA, 
// INCLUYENDO PERO NO LIMITADA A GARANTÍAS DE COMERCIALIZACIÓN, IDONEIDAD PARA UN PROPÓSITO PARTICULAR
// Y NO INFRACCIÓN.EN NINGÚN CASO LOS AUTORES O PROPIETARIOS DE LOS DERECHOS DE AUTOR SERÁN RESPONSABLES
// DE NINGUNA RECLAMACIÓN, DAÑOS U OTRAS RESPONSABILIDADES, YA SEA EN UNA ACCIÓN DE CONTRATO, AGRAVIO
// O CUALQUIER OTRO MOTIVO, DERIVADAS DE, FUERA DE O EN CONEXIÓN CON EL SOFTWARE O SU USO U OTRO TIPO
// DE ACCIONES EN EL SOFTWARE.


using Automata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTextor
{
    public partial class FormMain : Form
    {


        #region Constantes

        private const string NombreFuentePredeterminada = "Consolas";
        private const int TamanoFuentePredeterminada = 15;

        #endregion Constantes

        #region Miembros Privados

        private int m_intConteoPestanas = 0;
        private Font m_fontFuenteSeleccionada;

        private TablaTransiciones m_tablaTransiciones;
        private AnalizadorLexico m_analizadorLexico;
        private AnalizadorSintactico m_analizadorSintactico;

        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.m_fontFuenteSeleccionada = ObtenerFuentePredeterminado();
            tabControlMain.ContextMenuStrip = contextMenuStripMainPestana;

            AgregarPestana();
            ObtenerColeccionFuente();
            TamanosFuente();
        }

        #region Propiedades

        public RichTextBox ObtenerDocumentoActual
        {
            get { return (RichTextBox)tabControlMain.SelectedTab.Controls["Cuerpo"]; }
        }

        #endregion Propiedades

        #region Metodos

        #region Pestañas

        private void AgregarPestana()
        {
            RichTextBox Cuerpo = new RichTextBox();

            Cuerpo.Name = "Cuerpo";
            Cuerpo.AcceptsTab = true;
            Cuerpo.Dock = DockStyle.Fill;
            Cuerpo.ContextMenuStrip = contextMenuStripMainCuerpo;
            
            Cuerpo.Font = this.m_fontFuenteSeleccionada;

            TabPage NuevaPagina = new TabPage();
            this.m_intConteoPestanas++;

            string TextoDocumento = "Documento " + this.m_intConteoPestanas;
            NuevaPagina.Name = TextoDocumento;
            NuevaPagina.Text = TextoDocumento; 
            NuevaPagina.Controls.Add(Cuerpo);

            tabControlMain.TabPages.Add(NuevaPagina);
        }

        private void AgregarPestana(string Texto)
        {
            RichTextBox Cuerpo = new RichTextBox();

            Cuerpo.Name = "Cuerpo";
            Cuerpo.AcceptsTab = true;
            Cuerpo.Dock = DockStyle.Fill;
            Cuerpo.ContextMenuStrip = contextMenuStripMainCuerpo;
            Cuerpo.Text = Texto;

            Cuerpo.Font = this.m_fontFuenteSeleccionada;

            TabPage NuevaPagina = new TabPage();
            this.m_intConteoPestanas++;

            string TextoDocumento = "Documento " + this.m_intConteoPestanas;
            NuevaPagina.Name = TextoDocumento;
            NuevaPagina.Text = TextoDocumento;
            NuevaPagina.Controls.Add(Cuerpo);

            tabControlMain.TabPages.Add(NuevaPagina);
        }

        private void AgregarPestanaResultado(string TextoActual, string TextoResultado)
        {
            RichTextBox Cuerpo = new RichTextBox();

            Cuerpo.Name = "Cuerpo";
            Cuerpo.AcceptsTab = true;
            Cuerpo.Dock = DockStyle.Fill;
            Cuerpo.ContextMenuStrip = contextMenuStripMainCuerpo;
            Cuerpo.Text = TextoActual;
            
            // Cuerpo.Font = this.m_fontFuenteSeleccionada;

            RichTextBox Resultado = new RichTextBox();
            Resultado.Dock = DockStyle.Right;
            Resultado.Size = new Size(this.Size.Width / 2, this.Size.Height / 2);
            Resultado.ContextMenuStrip = contextMenuStripMainCuerpo;
            Resultado.Text = TextoResultado;

            // Resultado.Font = this.m_fontFuenteSeleccionada;

            TabPage NuevaPagina = new TabPage();
            
            string TextoDocumento = "Resultado";

            NuevaPagina.Name = TextoDocumento;
            NuevaPagina.Text = TextoDocumento;

            NuevaPagina.Controls.Add(Cuerpo);
            NuevaPagina.Controls.Add(Resultado);

            tabControlMain.TabPages.Add(NuevaPagina);
        }

        private void EliminarPestana()
        {
            if (tabControlMain.TabPages.Count != 1)
            {
                tabControlMain.TabPages.Remove(tabControlMain.SelectedTab);
            }
            else
            {
                tabControlMain.TabPages.Remove(tabControlMain.SelectedTab);
                this.m_intConteoPestanas = 0;
                AgregarPestana();
            }
        }

        private void EliminarTodasLasPestanas()
        {
            foreach (TabPage Page in tabControlMain.TabPages)
            {
                tabControlMain.TabPages.Remove(Page);
            }
            this.m_intConteoPestanas = 0;
            AgregarPestana();
        }

        private void EliminarTodasLasPestanasMenosEsta()
        {
            foreach (TabPage Page in tabControlMain.TabPages)
            {
                if (Page.Name != tabControlMain.SelectedTab.Name)
                {
                    tabControlMain.TabPages.Remove(Page);
                }
            }
        }

        #endregion Pestañas

        #region Guardar&Abrir

        private void Abrir()
        {
            openFileDialogMain.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialogMain.Filter = "Larva Files|*.la|Text Files|*.txt|Rich Text Files|*.rtf|VB Files|*.vb|C# Files|*.cs|All Files|*.* ";

            if (openFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialogMain.FileName.Length > 0)
                {
                    try
                    {
                        AgregarPestana();

                        tabControlMain.SelectedTab = tabControlMain.TabPages["Documento " + this.m_intConteoPestanas];

                        ObtenerDocumentoActual.LoadFile(openFileDialogMain.FileName, RichTextBoxStreamType.RichText);
                        string filename = Path.GetFileName(openFileDialogMain.FileName);
                        tabControlMain.SelectedTab.Text = filename;
                        tabControlMain.SelectedTab.Name = filename;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        private void Guardar()
        {
            saveFileDialogMain.FileName = tabControlMain.SelectedTab.Name;
            saveFileDialogMain.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialogMain.Filter = "Larva Files|*.la";
            saveFileDialogMain.Title = "Guardar";

            if (saveFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialogMain.FileName.Length > 0)
                {
                    try
                    {
                        ObtenerDocumentoActual.SaveFile(saveFileDialogMain.FileName, RichTextBoxStreamType.RichText);
                        string filename = Path.GetFileName(saveFileDialogMain.FileName);
                        tabControlMain.SelectedTab.Text = filename;
                        tabControlMain.SelectedTab.Name = filename;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        private void GuardarComo()
        {
            saveFileDialogMain.FileName = tabControlMain.SelectedTab.Name;
            saveFileDialogMain.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialogMain.Filter = "Larva Files|*.la|Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|All Files|*.*";
            saveFileDialogMain.Title = "Guardar como";

            if (saveFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialogMain.FileName.Length > 0)
                {
                    try
                    {
                        ObtenerDocumentoActual.SaveFile(saveFileDialogMain.FileName, RichTextBoxStreamType.RichText);
                        string filename = Path.GetFileName(saveFileDialogMain.FileName);
                        tabControlMain.SelectedTab.Text = filename;
                        tabControlMain.SelectedTab.Name = filename;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

        }

        #endregion Guardar&Abrir

        #region Texto

        private void Deshacer()
        {
            ObtenerDocumentoActual.Undo();
        }

        private void Rehacer()
        {
            ObtenerDocumentoActual.Redo();
        }

        private void Cortar()
        {
            ObtenerDocumentoActual.Cut();
        }

        private void Copiar()
        {
            ObtenerDocumentoActual.Copy();
        }

        private void Pegar()
        {
            ObtenerDocumentoActual.Paste();
        }

        private void SeleccionarTodo()
        {
            ObtenerDocumentoActual.SelectAll();
        }

        private void EstablecerEstiloFuente(FontStyle estiloFuente)
        {

        }

        #endregion Texto

        #region General

        private void ObtenerColeccionFuente()
        {
            InstalledFontCollection FuenteIns = new InstalledFontCollection();

            foreach (FontFamily item in FuenteIns.Families)
            {
                toolStripComboBoxFontFamily.Items.Add(item.Name);
            }

            toolStripComboBoxFontFamily.SelectedIndex = toolStripComboBoxFontFamily.FindString(NombreFuentePredeterminada);
        }

        private void TamanosFuente()
        {
            for (int i = 0; i <= 75; i++)
            {
                toolStripComboBoxFontSize.Items.Add(i);
            }
            toolStripComboBoxFontSize.SelectedIndex = TamanoFuentePredeterminada;
        }

        private Font ObtenerFuentePredeterminado()
        {
            return new Font(NombreFuentePredeterminada, TamanoFuentePredeterminada, FontStyle.Regular);
        }

        #endregion General

        #endregion Metodos

        #region menuStripMain Eventos

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarPestana();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void guardarcomoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deshacer();
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rehacer();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cortar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pegar();
        }

        private void seleccionartodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionarTodo();
        }

        #endregion ToolStripMenu Eventos

        #region toolStripTopMain Eventos

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            Font FuenteRegular = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Regular);
            Font FuenteNegrita = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Bold);

            if (ObtenerDocumentoActual.SelectionFont.Bold)
            {
                ObtenerDocumentoActual.SelectionFont = FuenteRegular;
            }
            else
            {
                ObtenerDocumentoActual.SelectionFont = FuenteNegrita;
            }
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            Font FuenteRegular = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Regular);
            
            Font FuenteItalica = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Italic);

            if (ObtenerDocumentoActual.SelectionFont.Italic)
            {
                ObtenerDocumentoActual.SelectionFont = FuenteRegular;
            }
            else
            {
                ObtenerDocumentoActual.SelectionFont = FuenteItalica;
            }
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            Font FuenteRegular = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Regular);

            Font FuenteSubrayado = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Underline);

            if (ObtenerDocumentoActual.SelectionFont.Underline)
            {
                ObtenerDocumentoActual.SelectionFont = FuenteRegular;
            }
            else
            {
                ObtenerDocumentoActual.SelectionFont = FuenteSubrayado;
            }
        }

        private void toolStripButtonStrikeout_Click(object sender, EventArgs e)
        {
            Font FuenteRegular = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Regular);

            Font FuenteTachado = new Font(ObtenerDocumentoActual.SelectionFont.FontFamily,
                ObtenerDocumentoActual.SelectionFont.SizeInPoints, FontStyle.Strikeout);

            if (ObtenerDocumentoActual.SelectionFont.Strikeout)
            {
                ObtenerDocumentoActual.SelectionFont = FuenteRegular;
            }
            else
            {
                ObtenerDocumentoActual.SelectionFont = FuenteTachado;
            }
        }

        private void toolStripButtonUppercase_Click(object sender, EventArgs e)
        {
            ObtenerDocumentoActual.SelectedText = ObtenerDocumentoActual.SelectedText.ToUpper();
        }

        private void toolStripButtonLowercase_Click(object sender, EventArgs e)
        {
            ObtenerDocumentoActual.SelectedText = ObtenerDocumentoActual.SelectedText.ToLower();
        }

        private void toolStripButtonFontIncrease_Click(object sender, EventArgs e)
        {
            float NuevoTamanoFuente = ObtenerDocumentoActual.SelectionFont.SizeInPoints + 2;

            Font NuevoTamano = new Font(ObtenerDocumentoActual.SelectionFont.Name,
                NuevoTamanoFuente, ObtenerDocumentoActual.SelectionFont.Style);

            this.m_fontFuenteSeleccionada = NuevoTamano;
            ObtenerDocumentoActual.SelectionFont = NuevoTamano;
        }

        private void toolStripButtonFontDecrease_Click(object sender, EventArgs e)
        {
            float NuevoTamanoFuente = ObtenerDocumentoActual.SelectionFont.SizeInPoints - 2;

            Font NuevoTamano = new Font(ObtenerDocumentoActual.SelectionFont.Name,
                NuevoTamanoFuente, ObtenerDocumentoActual.SelectionFont.Style);

            this.m_fontFuenteSeleccionada = NuevoTamano;
            ObtenerDocumentoActual.SelectionFont = NuevoTamano;
        }

        private void toolStripButtonForeColor_Click(object sender, EventArgs e)
        {
            if (colorDialogMain.ShowDialog() == DialogResult.OK)
            {
                ObtenerDocumentoActual.SelectionColor = colorDialogMain.Color;
            }
        }

        private void toolStripMenuItemHighlightNone_Click(object sender, EventArgs e)
        {
            ObtenerDocumentoActual.SelectionBackColor = Color.White;
        }

        private void toolStripMenuItemHighlightGreen_Click(object sender, EventArgs e)
        {
            ObtenerDocumentoActual.SelectionBackColor = Color.Green;
        }

        private void toolStripMenuItemHighlightOrange_Click(object sender, EventArgs e)
        {
            ObtenerDocumentoActual.SelectionBackColor = Color.Orange;
        }

        private void toolStripMenuItemHighlightYellow_Click(object sender, EventArgs e)
        {
            ObtenerDocumentoActual.SelectionBackColor = Color.Yellow;
        }

        private void toolStripComboBoxFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font NuevaFuente = new Font(toolStripComboBoxFontFamily.SelectedItem.ToString(),
                   ObtenerDocumentoActual.SelectionFont.Size, ObtenerDocumentoActual.SelectionFont.Style);

            this.m_fontFuenteSeleccionada = NuevaFuente;
            ObtenerDocumentoActual.SelectionFont = NuevaFuente;
        }

        private void toolStripComboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float NuevoTamano;

            float.TryParse(toolStripComboBoxFontSize.SelectedItem.ToString(), out NuevoTamano);

            Font NuevaFuente = new Font(ObtenerDocumentoActual.SelectionFont.Name, NuevoTamano,
                ObtenerDocumentoActual.SelectionFont.Style);

            this.m_fontFuenteSeleccionada = NuevaFuente;
            ObtenerDocumentoActual.SelectionFont = NuevaFuente;
        }

        #endregion toolStripTopMain Eventos

        #region toolStripLeftMain Eventos

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            AgregarPestana();
        }

        private void cerrarToolStripButton_Click(object sender, EventArgs e)
        {
            EliminarPestana();
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void cortarToolStripButton_Click(object sender, EventArgs e)
        {
            Cortar();
        }

        private void copiarToolStripButton_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void pegarToolStripButton_Click(object sender, EventArgs e)
        {
            Pegar();
        }

        #endregion toolStripLeftMain Eventos

        private void timerMain_Tick(object sender, EventArgs e)
        { 

            if (ObtenerDocumentoActual != null)
            {
                toolStripStatusLabelBottomMain.Text = ObtenerDocumentoActual.Text.Length.ToString();
                
                //toolStripButtonBold.Checked = ObtenerDocumentoActual.SelectionFont.Bold;
                //toolStripButtonItalic.Checked = ObtenerDocumentoActual.SelectionFont.Italic;
                //toolStripButtonUnderline.Checked = ObtenerDocumentoActual.SelectionFont.Underline;
                //toolStripButtonStrikeout.Checked = ObtenerDocumentoActual.SelectionFont.Strikeout;
            }
            else
            {
                toolStripStatusLabelBottomMain.Text = "";
            }
        }

        private void tablaDeTransicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogMain.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialogMain.Filter = "CSV Files|*.csv|Text Files|*.txt|All Files|*.* ";

            if (openFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialogMain.FileName.Length > 0)
                {
                    try
                    {
                        m_tablaTransiciones = new TablaTransiciones(openFileDialogMain.FileName);
                        // AgregarPestanaTabla(m_tablaTransiciones.ObtenerTablaDatos());
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show(f.Message);
                    }
                }
            }
        }

        private void iniciarAnalizadorLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ObtenerDocumentoActual == null)
            {
                MessageBox.Show("Por favor, seleccione el archivo ha analizar...");
            }
            else if (m_tablaTransiciones == null)
            {
                MessageBox.Show("Por favor, establezca una tabla de transiciones...");
            }
            else
            {
                m_analizadorLexico = new AnalizadorLexico(m_tablaTransiciones);
                m_analizadorLexico.EstablecerCodigoFuente(ObtenerDocumentoActual.Text);
                AgregarPestanaResultado(m_analizadorLexico.CodigoFuente, m_analizadorLexico.ObtenerArchivoTokens(ArchivoTokensOpciones.ConNumeroDeLinea));
            }
        }

        private void iniciarAnalizadorSintacticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (ObtenerDocumentoActual == null)
            //{
            //    MessageBox.Show("Por favor, seleccione el archivo ha analizar...");
            //}
            //else if (m_tablaTransiciones == null)
            //{
            //    MessageBox.Show("Por favor, establezca una tabla de transiciones...");
            //}
            //else
            //{
            //    m_analizadorLexico = new AnalizadorLexico(m_tablaTransiciones);
            //    m_analizadorLexico.EstablecerCodigoFuente(ObtenerDocumentoActual.Text);
            //    AgregarPestana(m_analizadorLexico.ObtenerArchivoTokens());
            //}
        }

        
    }
}
