using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlPagoEmpleados
{
    public partial class Frm_Pago_Empleados : Form
    {
        double sueldo, movilidad;
        int cPersonal, cComision;
        double aPersonal, aComision;
        int cVentas, cMarketing, cLogistica, cPrestamos;
        double aVentas, aMarketing, aLogistica, aPrestamos;

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        DateTime fecha;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string condicion = comboBox2.Text;

            //asignacion de sueldo de acorde a la condicion

            if (condicion == "Personal") sueldo = 2500;
            if (condicion == "Comision") sueldo = 1100;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Captura de los datos

            string empleado = txtEmpleado.Text;
            string hijos = txtHijos.Text;
            string area = comboBox1.Text;
            string condicion = comboBox2.Text;

            // Conteo y acumulacion

            switch (condicion)
            {
                case "Jefe": cPersonal++; aPersonal += sueldo; break;
                case "Comision": cComision++; aComision += sueldo; break;
            }

            switch (area)
            {
                case "Ventas": cVentas++; aVentas += sueldo; break;
                case "Marketing": cMarketing++; aMarketing += sueldo; break;
                case "Logistica": cLogistica++; aLogistica += sueldo; break;
                case "Prestamos": cPrestamos++; aPrestamos += sueldo; break;

            }

            // Realizando Calculo

            double descuento = 0;

            if (sueldo > 2500) descuento = (sueldo * 17) / 100;
            if (sueldo > 1100) descuento = (sueldo * 17) / 100;


            double neto = sueldo //+ MOVILIDAD + ASIGNACION
                                 - descuento;

            // imprimiendo los resultados

            ListViewItem fila = new ListViewItem(empleado);
            fila.SubItems.Add(hijos);
            fila.SubItems.Add(area);
            fila.SubItems.Add(condicion);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(sueldo.ToString("C"));
            //fila.SubItems.Add(movilidad.ToString("m"));
            // fila.SubItems.Add(asignacion);
            fila.SubItems.Add(descuento.ToString("C"));
            fila.SubItems.Add(neto.ToString("C"));

            listView1.Items.Add(fila);

            // Imprimir estadisticas
            listView2.Items.Clear();
            string[] elementosFila = new string[4];
            ListViewItem row;

            //impresion de los datos de Ventas
            elementosFila[0] = "Ventas";
            elementosFila[1] = cVentas.ToString();
            elementosFila[2] = aVentas.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);

            //impresion de los datos de Marketing
            elementosFila[0] = "Marketing";
            elementosFila[1] = cMarketing.ToString();
            elementosFila[2] = aMarketing.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);

            //impresion de los datos de lOGISTICA
            elementosFila[0] = "Logistica";
            elementosFila[1] = cLogistica.ToString();
            elementosFila[2] = aLogistica.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);

            //impresion de los datos de prestamos
            elementosFila[0] = "Prestamos";
            elementosFila[1] = cPrestamos.ToString();
            elementosFila[2] = aPrestamos.ToString("C");
            row = new ListViewItem(elementosFila);
            listView2.Items.Add(row);



        }
        private void llenarAreas()
        {
            comboBox1.Items.Add("Ventas");
            comboBox1.Items.Add("Marketing");
            comboBox1.Items.Add("Logistica");
            comboBox1.Items.Add("Prestamos");
        }
        private void cargarCondicion() 
        {
            comboBox2.Items.Add("Personal");
            comboBox2.Items.Add("Comision");
        }
 
        public Frm_Pago_Empleados()
        {
            InitializeComponent();
        }

        private void Frm_Pago_Empleados_Load(object sender, EventArgs e)
        {
            llenarAreas();
            cargarCondicion();
           
        }
      
    }
}
