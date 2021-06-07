using GR = BxlForm.GestContacts.Models.Global.Repositories;
using GS = BxlForm.GestContacts.Models.Global.Services;
using BxlForm.GestContacts.Models.Client.Data;
using BxlForm.GestContacts.Models.Client.Repositories;
using BxlForm.GestContacts.Models.Client.Services;
using BxlForm.Tools.Connections.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BxlForm.GestContacts.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestContacts;Integrated Security=True;");
            GR.ICategoriesRepository globalCategoriesRepository = new GS.CategoriesService(connection);
            ICategoriesRepository categoriesRepository = new CategoriesService(globalCategoriesRepository);

            GR.IContactsRepository globalContactsRepository = new GS.ContactsService(connection);
            IContactsRepository contactsRepository = new ContactsService(globalContactsRepository);

            #region • Affiche vos catégories
            {
                //IEnumerable<Category> categories = categoriesRepository.Get();
                //foreach (Category category in categories)
                //{
                //    Console.WriteLine($"{category.Id} : {category.Name}");
                //}
            }
            #endregion

            #region • Ajoute une catégorie « Autre »
            {
                //Category newCategory = new Category("Autre");
                //if(categoriesRepository.Insert(newCategory))
                //{
                //    Console.WriteLine("Insertion de la catégorie réussie");
                //}
            }
            #endregion

            #region • Récupère le nom de la catégorie dont l’identifiant est 2
            {
                //Category category = categoriesRepository.Get(2);
                //if (category is not null)
                //{
                //    Console.WriteLine($"{category.Id} : {category.Name}");
                //}
            }
            #endregion

            #region • Crée pour chaque catégories deux contacts
            {
                //List<Contact> contacts = new List<Contact>(
                //    new Contact[]{
                //        new Contact("Doe", "John", "john.doe@unknow.com", 1),
                //        new Contact("Doe", "Jane", "jane.doe@unknow.com", 1),
                //        new Contact("Moore", "Demi", "demi.moore@imdb.com", 2),
                //        new Contact("Willis", "Bruce", "bruce.willis@imdb.com", 2),
                //        new Contact("Kling", "Heidi", "casey.conway@mightyducks.ok", 3),
                //        new Contact("Estevez", "Emilio", "gordon.bombay@mightyducks.ok", 3),
                //    });

                //foreach(Contact contact in contacts)
                //{
                //    contactsRepository.Insert(contact);
                //}
            }
            #endregion

            #region • Affiche la liste de vos contacts
            {
                //IEnumerable<Contact> contacts = contactsRepository.Get();
                //foreach (Contact contact in contacts)
                //{
                //    Console.WriteLine($"{contact.Id} : {contact.LastName} {contact.FirstName} ({contact.Email} - {contact.CategoryId})");
                //}
            }
            #endregion

            #region • Affiche la liste de vos contacts pour chaque catégorie
            {
                //IEnumerable<Category> categories = categoriesRepository.Get();
                //foreach (Category category in categories)
                //{
                //    Console.WriteLine($"{category.Id} : {category.Name}");
                //    IEnumerable<Contact> contacts = contactsRepository.GetByCategory(category.Id);

                //    foreach (Contact contact in contacts)
                //    {
                //        Console.WriteLine($"--  {contact.Id} : {contact.LastName} {contact.FirstName} ({contact.Email})");
                //    }
                //    Console.WriteLine();
                //}
            }
            #endregion

            #region • Met à jour un contact de la catégorie « Personnel »
            {
                //Contact contact = contactsRepository.Get(1);
                //if (contact is not null)
                //{
                //    contact.LastName = "Morre";
                //    contact.FirstName = "Thierry";
                //    contact.Email = "thierry.morre@cognitic.be";

                //    if (contactsRepository.Update(contact.Id, contact))
                //    {
                //        Console.WriteLine("Mise à jour du contact réussie");
                //    }
                //}
            }
            #endregion

            #region • Supprime un contact de la catégorie « Autre »
            {
                //Contact contact = contactsRepository.Get(5);
                //if (contact is not null)
                //{
                //    if (contactsRepository.Delete(contact.Id))
                //    {
                //        Console.WriteLine("Suppression du contact réussie");
                //    }
                //}
            }
            #endregion
        }
    }
}
