using CodeFirst.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace WPF_entity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class allContext
    {
        public Uzytkownicy Uzytkownicy { get; set; }
        public Projekty Projekty { get; set; }
        public Zadania Zadania { get; set; }
    }
    public partial class MainWindow : Window
    {
        SzpContext dataSzpContext = new SzpContext();
        allContext contextAll = new allContext();
        public MainWindow()
        {
            contextAll.Uzytkownicy = new Uzytkownicy();
            contextAll.Projekty = new Projekty();
            contextAll.Zadania = new Zadania();
            InitializeComponent();
            dataUser.ItemsSource = dataSzpContext.Uzytkownicy.ToList();
            dataProject.ItemsSource = dataSzpContext.Projekty.ToList();
            dataTasks.ItemsSource = dataSzpContext.Zadania.ToList();
            DataContext = contextAll;
        }

        private void DataUser_OnAutoGeneratingColumn(object? sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ProjektyCollection" || e.PropertyName == "ZadaniaCollection" || e.PropertyName == "WiadomosciCollection" || e.PropertyName == "RaportyCollection" || e.PropertyName == "PrzeznaczenieWiadomosciCollection" || e.PropertyName == "ZmianyUzytkownikaCollection" || e.PropertyName == "Projekt")
            {
                e.Cancel = true;
            }
        }

        private void DataProject_OnAutoGeneratingColumn(object? sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "KierownikProjektu" || e.PropertyName == "UzytkownicyCollection" || e.PropertyName == "ZadaniaCollection" || e.PropertyName == "ZasobyCollection")
            {
                e.Cancel = true;
            }
        }

        private void DataTasks_OnAutoGeneratingColumn(object? sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Projekty" || e.PropertyName == "Uzytkownicy")
            {
                e.Cancel = true;
            }
            
        }

        private void ButtonBaseAdd_OnClick(object sender, RoutedEventArgs e)
        {
            contextAll.Uzytkownicy.Id = 0;
            dataSzpContext.Uzytkownicy.Add(contextAll.Uzytkownicy);
            dataSzpContext.SaveChanges();
            dataUser.ItemsSource = dataSzpContext.Uzytkownicy.ToList();

        }

        private void ButtonBaseAdd_OnClick_projects(object sender, RoutedEventArgs e)
        {
            contextAll.Projekty.Id = 0;
            dataSzpContext.Projekty.Add(contextAll.Projekty);
            dataSzpContext.SaveChanges();
            dataProject.ItemsSource = dataSzpContext.Projekty.ToList();
        }

        private void ButtonBaseAdd_OnClick_tasks(object sender, RoutedEventArgs e)
        {
            contextAll.Zadania.Id = 0;
            dataSzpContext.Zadania.Add(contextAll.Zadania);
            dataSzpContext.SaveChanges();
            dataTasks.ItemsSource = dataSzpContext.Zadania.ToList();
        }

        private void ButtonBaseDelete_OnClick(object sender, RoutedEventArgs e)
        {
        var removeUser =  dataSzpContext.Uzytkownicy.FirstOrDefault(x => x.Id == int.Parse(remove_box.Text));
        dataSzpContext.Uzytkownicy.Remove(removeUser);
        dataSzpContext.SaveChanges();
        dataUser.ItemsSource = dataSzpContext.Uzytkownicy.ToList();
        }
        private void ButtonBaseDelete_OnClick_projects(object sender, RoutedEventArgs e)
        {
            var removeProject =  dataSzpContext.Projekty.FirstOrDefault(x => x.Id == int.Parse(remove_box_projects.Text));
            dataSzpContext.Projekty.Remove(removeProject);
            dataSzpContext.SaveChanges();
            dataProject.ItemsSource = dataSzpContext.Projekty.ToList();
        }
        private void ButtonBaseDelete_OnClick_tasks(object sender, RoutedEventArgs e)
        {
            var removeTasks =  dataSzpContext.Zadania.FirstOrDefault(x => x.Id == int.Parse(remove_box_tasks.Text));
            dataSzpContext.Zadania.Remove(removeTasks);
            dataSzpContext.SaveChanges();
            dataTasks.ItemsSource = dataSzpContext.Zadania.ToList();
        }

        private void ButtonBaseUpdate_onClick(object sender, RoutedEventArgs e)
        { var updateUser =  dataSzpContext.Uzytkownicy.FirstOrDefault(x => x.Id == int.Parse(update_box.Text));
            if(contextAll.Uzytkownicy.Imie != null)
            {
                updateUser.Imie = contextAll.Uzytkownicy.Imie;
            }
            if(contextAll.Uzytkownicy.Nazwisko != null)
            {
                updateUser.Nazwisko = contextAll.Uzytkownicy.Nazwisko;
            }
            if(contextAll.Uzytkownicy.Email != null)
            {
                updateUser.Email = contextAll.Uzytkownicy.Email;
            }
            if(contextAll.Uzytkownicy.login != null)
            {
                updateUser.login = contextAll.Uzytkownicy.login;
            }
            if(contextAll.Uzytkownicy.haslo != null)
            {
                updateUser.haslo = contextAll.Uzytkownicy.haslo;
            }if(contextAll.Uzytkownicy.typ != null)
            {
                updateUser.typ = contextAll.Uzytkownicy.typ;
            }

            if (contextAll.Uzytkownicy.id_projektu != null)
            {
                updateUser.id_projektu = contextAll.Uzytkownicy.id_projektu;
            }
            dataSzpContext.Entry(updateUser).State = EntityState.Modified;
            dataSzpContext.SaveChanges();
            dataUser.ItemsSource = dataSzpContext.Uzytkownicy.ToList();
        }

        private void ButtonBaseUpdate_onClick_projects(object sender, RoutedEventArgs e)
        {
            var updateProject =  dataSzpContext.Projekty.FirstOrDefault(x => x.Id == int.Parse(update_box_projects.Text));
            if(contextAll.Projekty.Nazwa != null)
            {
                updateProject.Nazwa = contextAll.Projekty.Nazwa;
            }
            if(contextAll.Projekty.Opis != null)
            {
                updateProject.Opis = contextAll.Projekty.Opis;
            }
            if(contextAll.Projekty.data_startu != null)
            {
                updateProject.data_startu = contextAll.Projekty.data_startu;
            }
            if(contextAll.Projekty.data_zakonczenia != null)
            {
                updateProject.data_zakonczenia = contextAll.Projekty.data_zakonczenia;
            }
            if(contextAll.Projekty.id_kierownika_projektu != null)
            {
                updateProject.id_kierownika_projektu = contextAll.Projekty.id_kierownika_projektu;
            }

            if (contextAll.Projekty.status != null)
            {
                updateProject.status = contextAll.Projekty.status;
            }
            
            dataSzpContext.Entry(updateProject).State = EntityState.Modified;
            dataSzpContext.SaveChanges();
            dataProject.ItemsSource = dataSzpContext.Projekty.ToList();
        }

        private void ButtonBaseUpdate_onClick_tasks(object sender, RoutedEventArgs e)
        {
            var updateTasks = dataSzpContext.Zadania.FirstOrDefault(x => x.Id == int.Parse(update_box_tasks.Text));
            
            if(contextAll.Zadania.Nazwa != null)
            {
                updateTasks.Nazwa = contextAll.Zadania.Nazwa;
            }
            if(contextAll.Zadania.Opis != null)
            {
                updateTasks.Opis = contextAll.Zadania.Opis;
            }
            if(contextAll.Zadania.data_startu != null)
            {
                updateTasks.data_startu = contextAll.Zadania.data_startu;
            }
            if(contextAll.Zadania.data_zakonczenia != null)
            {
                updateTasks.data_zakonczenia = contextAll.Zadania.data_zakonczenia;
            }
            if(contextAll.Zadania.id_projektu != null)
            {
                updateTasks.id_projektu = contextAll.Zadania.id_projektu;
            }
            if(contextAll.Zadania.id_uzytkownika != null)
            {
                updateTasks.id_uzytkownika = contextAll.Zadania.id_uzytkownika;
            }
            if(contextAll.Zadania.status != null)
            {
                updateTasks.status = contextAll.Zadania.status;
            }
            
            dataSzpContext.Entry(updateTasks).State = EntityState.Modified;
            dataSzpContext.SaveChanges();
            dataTasks.ItemsSource = dataSzpContext.Zadania.ToList();
        }
        
    }
}
