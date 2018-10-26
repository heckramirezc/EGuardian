using System;
using System.Threading.Tasks;
using EGuardian.Common.Resources;
using EGuardian.Controls;
using EGuardian.Data;
using EGuardian.Models.Eventos;
using Xamarin.Forms;

namespace EGuardian.ViewModels.Eventos
{
    public class EventoActionDTViewModel : ContentView
    {
        Boolean isSeleccionado = false;
        public EventoActionDTViewModel(eventos evento)
        {
            IconView vCita = new IconView
            {
                Source = Images.Cita,
                Foreground = evento.estadoColor,
                WidthRequest = 25
            };
            /*MessagingCenter.Subscribe<PacienteNuevo_EdicionVista>(this, "deseleccionar", (sender) =>
            {
                isSeleccionado = false;
            });*/
            IconView vPaciente = new IconView
            {
                Source = Images.Paciente,
                Foreground = evento.estadoColor,
                WidthRequest = 20
            };
            /*TapGestureRecognizer tapCita = new TapGestureRecognizer();
            TapGestureRecognizer tapPaciente = new TapGestureRecognizer();


            tapCita.Tapped += async (sender, e) =>
            {
                try
                {
                    vCita.Foreground = Color.Gray;
                    await Task.Delay(100);
                    vCita.Foreground = evento.estadoColor;
                    var stack = Navigation.NavigationStack;
                    if (this.IsEnabled && !Constants.PantallaAbierta && (stack[stack.Count - 1].GetType() != typeof(Indicador)) && (stack[stack.Count - 1].GetType() != typeof(PacienteNuevo_EdicionVista)) && (stack[stack.Count - 1].GetType() != typeof(CitaNueva_EdicionVista)))
                    {
                        this.IsEnabled = false;
                        Constants.PantallaAbierta = true;
                        //await Navigation.PushAsync(new CitaNueva_EdicionVista(Convert.ToDateTime(cita.fechaInicio), cita));
                        this.IsEnabled = true;
                    }
                    else
                        System.Diagnostics.Debug.WriteLine("Pantalla abierta");
                }
                catch (Exception er)
                {
                    System.Diagnostics.Debug.WriteLine(er);
                }
            };
            tapPaciente.Tapped += async (sender, e) =>
            {
                try
                {
                    vPaciente.Foreground = Color.Gray;
                    await Task.Delay(100);
                    vPaciente.Foreground = evento.estadoColor;
                    var stack = Navigation.NavigationStack;
                    if (this.IsEnabled && !Constants.PantallaAbierta /*&& (stack[stack.Count - 1].GetType() != typeof(Indicador)) && (stack[stack.Count - 1].GetType() != typeof(PacienteNuevo_EdicionVista)) && (stack[stack.Count - 1].GetType() != typeof(CitaNueva_EdicionVista))*/ /*&& !isSeleccionado)
                    {
                        this.IsEnabled = false;
                        Constants.PantallaAbierta = true;
                        if (evento.idPaciente != 0)
                        {
                            await Navigation.PushPopupAsync(new Indicador("Obteniendo datos de paciente.", Color.White));
                            var paciente = App.Database.GetPaciente(Convert.ToInt16(cita.Paciente.id));
                            SelectByID peticion = new SelectByID
                            {
                                PatientID = paciente.Patient_ID.ToString()
                            };
                            await App.ManejadorDatos.SelectByIDAsync(peticion);
                            paciente = App.Database.GetPaciente(Convert.ToInt16(cita.Paciente.id));
                            await Navigation.PushAsync(new PacienteNuevo_EdicionVista(paciente, MenuTipo.Agenda));
                        }
                        else
                        {
                            await Navigation.PushAsync(new PacienteNuevo_EdicionVista(new pacientes(), MenuTipo.Agenda));
                        }
                        this.IsEnabled = true;
                    }
                    else
                        System.Diagnostics.Debug.WriteLine("Pantalla abierta");

                }
                catch (Exception er)
                {
                    System.Diagnostics.Debug.WriteLine(er);
                }
            };

            vCita.GestureRecognizers.Add(tapCita);
            vPaciente.GestureRecognizers.Add(tapPaciente);*/

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.Center,
                RowSpacing = 0,
                ColumnSpacing = 5,
                RowDefinitions = {
                    new RowDefinition {  Height = new GridLength (1, GridUnitType.Auto) },
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Auto) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Auto) },
                }
            };
            grid.Children.Add(vCita, 0, 0);
            grid.Children.Add(vPaciente, 1, 0);
            Content = grid;
        }
    }
}